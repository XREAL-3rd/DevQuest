using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerControl : MonoBehaviour {
    private static float HEIGHT = 2f;
    public GameObject clickparticle;
    public GameObject shootparticle;
    public GameObject bullet;
    public GameObject bomb;

    bool Rclick = true;
    public GameObject SkillOn;
    public GameObject SkillCool;
    public Image SkillFill;

    

    //������ fsm state������� �����ϴ� Player Controller�Դϴ�. Fsm state machine�� ���� �� �ڼ��� ������ ���� 3ȸ������ ��� ���Դϴ�!
    //������ state�� 3���������� 3ȸ�� ���ǿ��� ���� state�� �� �߰��ϴ� ������ ���� �����Դϴ�.
    [Header("Settings")]
    [SerializeField] public float moveSpeed = 6f;
    [SerializeField] public float jumpAmount = 8f;


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

    public bool landed = false, moving = false;
    //1ȸ�� �������� ���� �ִϸ��̼��� �߰��ϰ� �ʹٸ�, ���� �߿��� animator.rangeAttack�� ������ �����ϰų�, ���� ���۽� animator.MeleeAttack()�� ȣ���ϼ���.
    //���ڴ� ���� ���� ���Ÿ� ���� �ִϸ��̼���, ���ڴ� ȣ�� �� �ٰŸ� ���� �ִϸ��̼��� ����մϴ�.
    //���� ��ü�� PlayerRenderer.cs�� �����ϼ���.
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

    private void FixedUpdate() {
        //0. �۷ι� ��Ȳ �Ǵ�
        stateTime += Time.deltaTime;
        CheckLanded();
        //insert code here...

        if (!EventSystem.current.IsPointerOverGameObject())
		{
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit poshit;
                Ray posray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(posray, out poshit))
                {
                    animator.MeleeAttack();
                    Vector3 look = poshit.point - transform.position;
                    look.y = 0;
                    rotation = Quaternion.LookRotation(look);
                    Ray shootray = new Ray(transform.position, poshit.point - transform.position);

                    RaycastHit hit;
                    if (Physics.Raycast(shootray, out hit))
                    {
                        Instantiate(clickparticle, hit.point, Quaternion.identity);

                        var emission = bullet.GetComponent<ParticleSystem>().emission;
                        emission.rateOverDistance = 1f;
                        bullet.transform.SetParent(null);
                        bullet.transform.position = hit.point;
                        Destroy(bullet, 1.0f);
                        bullet = Instantiate(shootparticle, this.transform.position, Quaternion.identity, this.transform);

                        if (hit.transform.gameObject.CompareTag("Target"))
                        {
                            Vector3 shoot = hit.point - this.transform.position;
                            hit.transform.gameObject.GetComponent<Target>().attack(80, shoot);
                        }
                    }
                }

            }
            else if (Input.GetMouseButtonDown(1) && Rclick)
            {
                RaycastHit hit;
                Ray posray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(posray, out hit))
                {
                    Vector3 look = hit.point - transform.position;
                    look.y = 0;
                    rotation = Quaternion.LookRotation(look);

                    Rigidbody bombparticle = Instantiate(bomb, this.transform).GetComponent<Rigidbody>();
                    Vector3 v = (hit.point - this.transform.position).normalized;
                    v.y += 0.6f;
                    bombparticle.AddForce(v * 8f, ForceMode.Impulse);

                    StartCoroutine(CoolTime());
                }

            }
        }
        

        //1. ������Ʈ ��ȯ ��Ȳ �Ǵ�
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


        //2. ������Ʈ �ʱ�ȭ
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

        //3. �۷ι� & ������Ʈ ������Ʈ
        UpdateInput();
        //insert code here...
    }

    //���� ��Ҵ��� ���θ� Ȯ���ϰ� landed�� �������ִ� �Լ�
    private void CheckLanded() {
        //�� ��ġ�� ���� ���� �ϳ� ������ �� ���� ���� ����� �˻��Ѵ�.
        //1 << 6�� Ground�� ���̾ 6�̱� ����.
        landed = Physics.CheckSphere(new Vector3(col.bounds.center.x, col.bounds.center.y - ((HEIGHT - 1f) / 2 + 0.15f), col.bounds.center.z), 0.45f, 1 << 6, QueryTriggerInteraction.Ignore);
    }

    //WASD ��ǲ�� ó���ϴ� �Լ�
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
            moving = true;
        }
        rigid.MovePosition(transform.position + move.normalized * Time.deltaTime * moveSpeed);
    }

    //ī�޶� �������� �հ� ���� ���͸� ������ִ� �Լ�
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

    IEnumerator CoolTime()
    {
        Rclick = false;
        SkillOn.SetActive(false);
        SkillCool.SetActive(true);

        for (int i = 0; i < 100; i++)
        {
            SkillFill.fillAmount += 0.01f;

            yield return new WaitForSeconds(0.03f);
        }

        SkillOn.SetActive(true);
        SkillCool.SetActive(false);
        SkillFill.fillAmount = 0f;
        Rclick = true;
    }
}
