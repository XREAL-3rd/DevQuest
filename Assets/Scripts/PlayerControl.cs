using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    private static float HEIGHT = 2f;
    //간단한 fsm state방식으로 동작하는 Player Controller입니다. Fsm state machine에 대한 더 자세한 내용은 세션 3회차에서 배울 것입니다!
    //지금은 state가 3개뿐이지만 3회차 세션에서 직접 state를 더 추가하는 과제가 나갈 예정입니다.
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float jumpAmount = 4f;

    public enum State {
        none,
        idle,
        jump
    }

    [Header("Debug")]
    public State state = State.none;
    public State nextState = State.none;
    private float stateTime;

    public PlayerRenderer animator;
    public Animator anim;

    public bool landed = false, moving = false;
    //1회차 과제에서 공격 애니메이션을 추가하고 싶다면, 공격 중에는 animator.rangeAttack를 참으로 설정하거나, 공격 시작시 animator.MeleeAttack()을 호출하세요.
    //전자는 참일 동안 원거리 공격 애니메이션을, 후자는 호출 시 근거리 공격 애니메이션을 재생합니다.
    //구현 자체는 PlayerRenderer.cs를 참조하세요.
    public Quaternion rotation = Quaternion.identity;
    private Rigidbody rigid;
    private Collider col;
    private Transform camt;

    private void Start() {
        camt = FindObjectOfType<Camera>().transform;
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        state = State.none;
        nextState = State.idle;
        stateTime = 0f;
        rotation = transform.rotation;
    }

    private void Update() {

        //0. 글로벌 상황 판단
        stateTime += Time.deltaTime;
        CheckLanded();
        //insert code here...

        //1. 스테이트 전환 상황 판단
        if (nextState == State.none) {
            switch (state) {
                case State.idle:
                    if (landed) {
                        if (Input.GetKey(KeyCode.Space)) {
                            nextState = State.jump;
                        }
                    }
                    break;
                case State.jump:
                    if (landed) nextState = State.idle;
                    break;
                //insert code here...
            }
        }


        //2. 스테이트 초기화
        if (nextState != State.none) {
            state = nextState;
            nextState = State.none;
            switch (state) {
                case State.jump:
                    Vector3 vel = rigid.velocity;
                    vel.y = jumpAmount;
                    rigid.velocity = vel;
                    animator.Jump();
                    break;
                //insert code here...
            }
            stateTime = 0f;
        }

        //3. 글로벌 & 스테이트 업데이트
        UpdateInput();
        //insert code here...
    }

    //땅에 닿았는지 여부를 확인하고 landed를 설정해주는 함수
    private void CheckLanded() {
        //발 위치에 작은 구를 하나 생성에 그 구에 땅이 닿는지 검사한다.
        //1 << 6은 Ground의 레이어가 6이기 때문.
        landed = Physics.CheckSphere(new Vector3(col.bounds.center.x, col.bounds.center.y - ((HEIGHT - 1f) / 2 + 0.15f), col.bounds.center.z), 0.45f, 1 << 6, QueryTriggerInteraction.Ignore);
    }

    //WASD 인풋을 처리하는 함수
    private void UpdateInput() {
        Vector3 move = Vector3.zero;
        moving = false;
        if (Input.GetKey(KeyCode.W)) {
            move += ForwardVector() * 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            move += ForwardVector() * -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            move += RightVector() * 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            move += RightVector() * -1;
        }
        if (move.x != 0 || move.z != 0) {
            rotation = Quaternion.LookRotation(move);
            moving = true; // 여기에서 animator를 move로 바꾸어주자
            /* 애니메이션 바꾸기 */
            anim.SetBool("walking", true);

        }

        rigid.MovePosition(transform.position + move.normalized * Time.deltaTime * moveSpeed);
    }

    //카메라 기준으로 앞과 우측 벡터를 계산해주는 함수
    private Vector3 ForwardVector() {
        Vector3 v = camt.forward;
        v.y = 0;
        v.Normalize();
        return v;
    }

    private Vector3 RightVector() {
        Vector3 v = camt.right;
        v.y = 0;
        v.Normalize();
        return v;
    }
}
