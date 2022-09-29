using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    private static float HEIGHT = 2f;
    private static float DIST_MOVE = 3f;
    //������ fsm state������� �����ϴ� Player Controller�Դϴ�. Fsm state machine�� ���� �� �ڼ��� ������ ���� 3ȸ������ ��� ���Դϴ�!
    //������ state�� 3���������� 3ȸ�� ���ǿ��� ���� state�� �� �߰��ϴ� ������ ���� �����Դϴ�.
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpAmount = 4f;

    private float damage = 10f;

    public enum State {
        none,
        idle,
        jump,
        attack
    }

    [Header("Debug")]
    public State state = State.none;
    public State nextState = State.none;
    private float stateTime;

    public GameObject projectilePrefab;

    public PlayerRenderer animator;

    public bool landed = true, moving = false, shooting = false;
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

    private void Update() {
        //0. �۷ι� ��Ȳ �Ǵ�
        stateTime += Time.deltaTime;
        CheckLanded();
        //insert code here...

        //1. ������Ʈ ��ȯ ��Ȳ �Ǵ�
        if (nextState == State.none) {
            switch (state) {
                case State.idle:
                    if (landed) {
                        if (Input.GetKey(KeyCode.Space)) {
                            nextState = State.jump;
                        }
                        else if (Input.GetMouseButton(0)) {
                            nextState = State.attack;
                        }
                    }
                    break;
                case State.jump:
                    if (landed) nextState = State.idle;
                    break;
                case State.attack:
                    if (!shooting) nextState =State.idle;
                    break;
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
                case State.attack:
                    animator.Shoot();
                    break;
            }
            stateTime = 0f;
        }

        //3. �۷ι� & ������Ʈ ������Ʈ
        UpdateInput();
        // ���� ���� ������Ʈ 
        UpdateAttack();
        //insert code here...
    }

    //���� ��Ҵ��� ���θ� Ȯ���ϰ� landed�� �������ִ� �Լ�
    private void CheckLanded() {
        //�� ��ġ�� ���� ���� �ϳ� ������ �� ���� ���� ����� �˻��Ѵ�.
        //1 << 6�� Ground�� ���̾ 6�̱� ����.
        landed = Physics.CheckSphere(new Vector3(col.bounds.center.x, col.bounds.center.y - ((HEIGHT - 1f) / 2 + 0.15f), col.bounds.center.z), 0.45f, 1 << 6, QueryTriggerInteraction.Ignore);
    }

    private void CheckShooting() {
        // animator�� �������� Ȯ���ϴ� ����� ���� �������?
    }

    private void UpdateAttack(){
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){

        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);


        RaycastHit hit;
        Ray aim;
        aim = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(aim, out hit)){
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null){
                target.TakeDamage(damage);
            }
        }
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
}
