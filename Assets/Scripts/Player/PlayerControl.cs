using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour {
    private static float HEIGHT = 2f;
    //간단한 fsm state방식으로 동작하는 Player Controller입니다. Fsm state machine에 대한 더 자세한 내용은 세션 3회차에서 배울 것입니다!
    //지금은 state가 3개뿐이지만 3회차 세션에서 직접 state를 더 추가하는 과제가 나갈 예정입니다.
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 20f;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    [SerializeField] private float jumpAmount = 8f;

    public enum State {
        none,
        idle,
        jump,
        roll
    }

    [Header("Debug")]
    public State state = State.none;
    public State nextState = State.idle;
    public Quaternion rotation = Quaternion.identity;
    public Vector3 moveDirection;

    public bool landed = false;
    public bool moving = false;
    public bool canMove = true;
    public bool rolling = false;

    public PlayerRenderer playerRenderer;
    public Transform renderTransform;
    public Vector3 forward;
    
    private Rigidbody rigid;
    private Collider col;
    private Transform camTransform;

    private void Start() {
        camTransform = FindObjectOfType<Camera>().transform;
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        renderTransform = transform.GetChild(0).GetComponent<Transform>();

        state = State.idle;
        nextState = State.none;
        rotation = transform.rotation;
    }

    private void Update() {
        landed = CheckLanded();
        forward = SetForward();
        Move();

        if (nextState == State.none) {
            switch (state) {
                case State.idle:
                    if (landed) {
                        if (Input.GetKey(KeyCode.Space))
                            nextState = State.jump;
                        if (Input.GetKey(KeyCode.LeftShift))
                            nextState = State.roll;
                    }
                    break;
                case State.jump:
                    if (landed)
                        nextState = State.idle;
                    break;
                case State.roll:
                    if (!rolling)
                        nextState = State.idle;
                    else
                        nextState = State.roll;
                    break;
            }
        }

        if (nextState != State.none) {
            state = nextState;
            nextState = State.none;
            switch (state) {
                case State.idle:
                    Idle();
                    break;
                case State.jump:
                    Jump();
                    break;
                case State.roll:
                    if(!rolling)
                        StartCoroutine(Roll());
                    break;
            }
        }
    }

    private void Idle() {
        canMove = true;
    }
    
    private void Jump() {
        playerRenderer.Jump();
        Vector3 vel = rigid.velocity;
        vel.y = jumpAmount;
        rigid.velocity = vel;
    }

    private IEnumerator Roll() {
        playerRenderer.Roll();
        canMove = false;
        rolling = true;
        yield return StartCoroutine(RollPosition());
    }

    private IEnumerator RollPosition() {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.01f);
        Vector3 destination = transform.position + forward * 10;

        for (int i = 0; i < 110; i++) {
            transform.position = Vector3.Lerp(transform.position, destination, 0.01f);
            yield return waitForSeconds;
        }
        rolling = false;
    }

    public bool CheckLanded() {
        //1 << 6은 Ground의 레이어가 6이기 때문.
        return Physics.CheckSphere(new Vector3(col.bounds.center.x, col.bounds.center.y - ((HEIGHT - 1f) / 2 + 0.15f), col.bounds.center.z), 0.45f, 1 << 6, QueryTriggerInteraction.Ignore);
    }

    private Vector3 SetForward() {
        return renderTransform.forward;
    }

    private Vector3 SetMoveDirection() {
        Vector3 moveDirection = Vector3.zero;
        moving = false;

        if (Input.GetKey(KeyCode.W))
            moveDirection += ForwardVector() * 1;
        if (Input.GetKey(KeyCode.S))
            moveDirection += ForwardVector() * -1;
        if (Input.GetKey(KeyCode.D))
            moveDirection += RightVector() * 1;
        if (Input.GetKey(KeyCode.A))
            moveDirection += RightVector() * -1;

        if (moveDirection.x != 0 || moveDirection.z != 0) {
            rotation = Quaternion.LookRotation(moveDirection);
            moving = true;
        }
        return moveDirection.normalized;
    }

    private void Move() {
        Vector3 moveDirection = SetMoveDirection();
        if (canMove)
            rigid.MovePosition(transform.position + moveDirection * Time.deltaTime * moveSpeed);
    }

    private Vector3 ForwardVector() {
        Vector3 v = camTransform.forward;
        Debug.DrawRay(transform.position, camTransform.forward, Color.red);
        v.y = 0;
        return v.normalized;
    }

    private Vector3 RightVector() {
        Vector3 v = camTransform.right;
        Debug.DrawRay(transform.position, camTransform.right, Color.blue);
        v.y = 0;
        return v.normalized;
    }
}