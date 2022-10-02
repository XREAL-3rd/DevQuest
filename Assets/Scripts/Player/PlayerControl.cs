using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private static float HEIGHT = 2f;

    [Header("Settings")] [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpAmount = 4f;

    public enum State
    {
        None,
        Idle,
        Jump
    }

    [Header("Debug")] public State state = State.None;
    public State nextState = State.None;
    private float stateTime;

    public PlayerRenderer animator;

    public bool landed = false, moving = false;

    public Quaternion rotation = Quaternion.identity;
    private Rigidbody rigid;
    private Collider col;
    private Transform camt;

    public static event Action MouseClicked;

    private void Start()
    {
        camt = FindObjectOfType<Camera>().transform;
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        state = State.None;
        nextState = State.Idle;
        stateTime = 0f;
        rotation = transform.rotation;
    }

    private void Update()
    {
        stateTime += Time.deltaTime;
        CheckLanded();

        if (nextState == State.None)
        {
            switch (state)
            {
                case State.Idle:
                    if (landed)
                    {
                        if (Input.GetKey(KeyCode.Space))
                        {
                            nextState = State.Jump;
                        }
                    }

                    break;
                case State.Jump:
                    if (landed) nextState = State.Idle;
                    break;
                //insert code here...
            }
        }

        if (nextState != State.None)
        {
            state = nextState;
            nextState = State.None;
            switch (state)
            {
                case State.Jump:
                    Vector3 vel = rigid.velocity;
                    vel.y = jumpAmount;
                    rigid.velocity = vel;
                    animator.Jump();
                    break;
                //insert code here...
            }

            stateTime = 0f;
        }
        
        UpdateInput();
        
        if (state != State.Jump && Input.GetMouseButtonDown(0))
        {
            SetAttack();
        }
    }
    
    private void CheckLanded()
    {
        landed = Physics.CheckSphere(
            new Vector3(col.bounds.center.x, col.bounds.center.y - ((HEIGHT - 1f) / 2 + 0.15f), col.bounds.center.z),
            0.45f, 1 << 6, QueryTriggerInteraction.Ignore);
    }
    
    private void UpdateInput()
    {
        Vector3 move = Vector3.zero;
        moving = false;
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
        }

        rigid.MovePosition(transform.position + move.normalized * Time.deltaTime * moveSpeed);
    }
    
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
    
    private void SetAttack()
    {
        MouseClicked?.Invoke();
    }

}