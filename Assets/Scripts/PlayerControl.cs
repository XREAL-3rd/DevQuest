using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour 
{
    private static float HEIGHT = 2f;

    //간단한 fsm state방식으로 동작하는 Player Controller입니다. Fsm state machine에 대한 더 자세한 내용은 세션 3회차에서 배울 것입니다!
    //지금은 state가 3개뿐이지만 3회차 세션에서 직접 state를 더 추가하는 과제가 나갈 예정입니다.

    [Header("Settings")]
    public static float moveSpeed = 20f;

    [SerializeField] 
    private float jumpAmount = 4f;

    public enum State 
    {
        none,
        idle,
        jump,
        horray
    }

    [Header("Debug")]
    public State state = State.none;
    public State nextState = State.none;
    private float stateTime;

    public PlayerRenderer animator;

    private bool start = true;
    public bool landed = false, moving = false, killing = false;
    public Animator anim;

    //1회차 과제에서 공격 애니메이션을 추가하고 싶다면, 공격 중에는 animator.rangeAttack를 참으로 설정하거나, 공격 시작시 animator.MeleeAttack()을 호출하세요.
    //전자는 참일 동안 원거리 공격 애니메이션을, 후자는 호출 시 근거리 공격 애니메이션을 재생합니다.
    //구현 자체는 PlayerRenderer.cs를 참조하세요.

    public Quaternion rotation = Quaternion.identity;
    private Rigidbody rigid;
    private Collider col;
    private Transform camt;


    //각종 변수
    int animalListBaby, animalListBabycompare;


    private void Start() 
    {
        camt = FindObjectOfType<Camera>().transform;
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        state = State.none;
        nextState = State.idle;
        stateTime = 0f;
        rotation = transform.rotation;
    }

    private void Update() 
    {
        //0. 글로벌 상황 판단
        stateTime += Time.deltaTime;
        CheckLanded();
        CheckKilling();
        //insert code here...

        //1. 스테이트 전환 상황 판단
        if (nextState == State.none) // 만약 다음 state가 없으면 
        {
            switch (state) 
            {
                case State.idle: // idle 일때
                    if (!landed) // 점프로 가봐
                    {
                        if (Input.GetKey(KeyCode.Space)) 
                        {
                            nextState = State.jump;
                        }
                    }

                    if (killing) // horray로 가봐
                    {
                        nextState = State.horray;
                    }
                    break;

                case State.jump:
                    if (!landed) // 점프 중이면
                    {
                        nextState = State.idle; // 다시 되돌아가 
                    }
                    break;
                //insert code here...

                case State.horray:
                    if (killing) // killing 중이면
                    {
                        nextState = State.idle; // 다시 되돌아가 
                    }
                    break;

            }
        }


        //2. 스테이트 초기화
        if (nextState != State.none) 
        {
            state = nextState;
            nextState = State.none;
            switch (state) 
            {
                case State.jump: // 점프이면 뭐할건데?
                    Vector3 vel = rigid.velocity;
                    vel.y = jumpAmount;
                    rigid.velocity = vel;
                    animator.Jump();
                    break;
                //insert code here...

                case State.horray: // Horray면 뭐할건데?
                    animator.Horray(); // 애니메이션 달아주기 
                    break;


            }
            stateTime = 0f;
        }

        //3. 글로벌 & 스테이트 업데이트
        UpdateInput();
        //insert code here...
    }

    //땅에 닿았는지 여부를 확인하고 landed를 설정해주는 함수
    private void CheckLanded() 
    {

        //발 위치에 작은 구를 하나 생성에 그 구에 땅이 닿는지 검사한다.
        //1 << 6은 Ground의 레이어가 6이기 때문.
        //landed = Physics.CheckSphere(new Vector3(col.bounds.center.x, col.bounds.center.y - ((HEIGHT - 1f) / 2 + 0.15f), col.bounds.center.z), 0.45f, 1 << 6, QueryTriggerInteraction.Ignore);

        //landed = Physics.CheckSphere(new Vector3(col.bounds.center.x, col.bounds.center.y+35.0F, col.bounds.center.z), 0.45f, 1 << 6, QueryTriggerInteraction.Ignore);
    }
    
    //Ox 죽였는거 성공했는지 처리해주는 함수
    private void CheckKilling()
    {
        animalListBaby = GameObject.Find("AnimalList").transform.childCount; // 자식오브젝트 수 넣어주고

        if (start == true)
        {
            animalListBabycompare = animalListBaby - 1; // 하나 낮은것도 해줬음. 
            start = false;

        }

        print(animalListBaby );

        if (animalListBaby == animalListBabycompare) // 같아지면 
        {
            
            killing = true; // 하나 죽인게 되고 
            animalListBabycompare--; // 하나 줄여주기 
            anim.SetTrigger("horray");
            print("킬링" + killing);
        }


        killing = false; // 기본적으로는 false임
        anim.SetTrigger("idle");

   
     }

    //WASD 인풋을 처리하는 함수 
    private void UpdateInput() 
    {
 
        Vector3 move = Vector3.zero;
        moving = false;
        anim.SetBool("moving", false);
        if (Input.GetKey(KeyCode.W)) 
        {
            move += ForwardVector() * 1;
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            move += ForwardVector() * -1;
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            move += RightVector() * 1;
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            move += RightVector() * -1;
        }
        if (move.x != 0 || move.z != 0) 
        {
            rotation = Quaternion.LookRotation(move);
            moving = true;
            anim.SetBool("moving",true);
        }
        rigid.MovePosition(transform.position + move.normalized * Time.deltaTime * moveSpeed);
    }

    //카메라 기준으로 앞과 우측 벡터를 계산해주는 함수
    private Vector3 ForwardVector() 
    {
        Vector3 v = camt.forward;
        v.y = 0;
        v.Normalize();
        return v;
    }

    private Vector3 RightVector() 
    {
        Vector3 v = camt.right;
        v.y = 0;
        v.Normalize();
        return v;
    }
}
