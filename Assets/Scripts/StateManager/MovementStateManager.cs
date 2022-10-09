using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementStateManager : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float turnSpeed = 5f;
    public PlayerRenderer pRenderer;
    public Collider col;
    public Rigidbody rigid;
    public Vector3 moveDirection;
    private InputActions playerInputActions;

    BaseMovementState currentState;
    public IdleState Idle = new IdleState();
    public WalkState Walk = new WalkState();
    public CrouchState Crouch = new CrouchState();
    public JumpState Jump = new JumpState();
    public RunState Run = new RunState();
    public Quaternion rotation = Quaternion.identity;
    public Transform camt;
    public bool landed = true;
    public bool moving = false, walking = false, crouching = false, jumping = false, running = false;

    void Awake()
    {
        camt = FindObjectOfType<Camera>().transform;
        pRenderer = GetComponentInChildren<PlayerRenderer>();
        col = GetComponent<Collider>();
        rigid = GetComponent<Rigidbody>();
        playerInputActions = new InputActions();
        
        rotation = transform.rotation;
        SwitchState(Idle);
    }

    private void OnEnable(){
        playerInputActions = new InputActions();
        SwitchState(Idle);

        playerInputActions.Player.Move.performed += onMove;
        playerInputActions.Player.Move.Enable();

        playerInputActions.Player.Run.started += onRun;
        playerInputActions.Player.Run.canceled += cancelRun;
        playerInputActions.Player.Run.Enable();

        playerInputActions.Player.Jump.performed += onJump;
        playerInputActions.Player.Jump.Enable();

        playerInputActions.Player.Crouch.performed += onCrouch; 
        playerInputActions.Player.Crouch.Enable();
    }

    private void OnDisable(){
        playerInputActions.Player.Move.performed -= onMove;
        playerInputActions.Player.Move.Disable();

        playerInputActions.Player.Run.started -= onRun;
        playerInputActions.Player.Run.canceled -= cancelRun;
        playerInputActions.Player.Run.Disable();

        playerInputActions.Player.Jump.performed -= onJump;
        playerInputActions.Player.Jump.Disable();

        playerInputActions.Player.Crouch.performed -= onCrouch;
        playerInputActions.Player.Crouch.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleMovement();
        currentState.UpdateState(this);
    }

    void HandleMovement(){
        if (moving) {
            rigid.MovePosition(transform.position + moveDirection * Time.deltaTime * moveSpeed);
        }
    }

    void HandleRotation(){
        if (moving){
            rotation = Quaternion.LookRotation(moveDirection);
            pRenderer.transform.rotation = Quaternion.Lerp(pRenderer.transform.rotation, rotation, Time.deltaTime * turnSpeed);
        }
    }

    public void SwitchState(BaseMovementState state){
        currentState = state;
        currentState.EnterState(this);
    }

    void onMove(InputAction.CallbackContext context){
        if(landed){
            Vector2 input = context.ReadValue<Vector2>();
            if(input.magnitude > 0.1f){
                moveDirection = ConvertVectorToCameraTransform(input);
                if(!moving) moving = true;
                if(running) walking = false;
                else walking = true;
            }
            else{
                Debug.Log("Stop");
                moving = false;
                walking = false;
                running = false;
            }
        }
    }

    Vector3 ConvertVectorToCameraTransform(Vector2 input){
        Vector3 vecCam = new Vector3(camt.forward.x, 0, camt.forward.z);
        vecCam.Normalize();
        Vector3 inputVec = new Vector3(input.x, 0, input.y);
        float cos = Vector3.Dot(vecCam, inputVec);
        float angle = Mathf.Acos(cos);
        return Quaternion.Euler(0, angle, 0) * inputVec;
    }

    void onJump(InputAction.CallbackContext context){
        if (!jumping){
            Debug.Log("jumping");
            jumping = true;
            walking = false;
            running = false;
            landed = false;
        }
    }

    void onCrouch(InputAction.CallbackContext context){
        if (landed){
            if(crouching) crouching = false;
            else crouching = true;
        }
    }

    void onRun(InputAction.CallbackContext context){
        Debug.Log("Run pressed");
        if(landed && moving) {
            running = true;
            walking = false;
        }
    }

    void cancelRun(InputAction.CallbackContext context){
        Debug.Log("Run unpressed");
        if(running){
            running = false;
        }
    }
}
