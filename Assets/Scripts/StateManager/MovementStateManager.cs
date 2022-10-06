using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementStateManager : MonoBehaviour
{
    private static float HEIGHT = 2f;
    public PlayerRenderer pRenderer;
    private Collider col;
    public Vector3 moveDirection;
    private InputActions playerInputActions;

    BaseMovementState currentState;
    public IdleState Idle = new IdleState();
    public WalkState Walk = new WalkState();
    public CrouchState Crouch = new CrouchState();
    public JumpState Jump = new JumpState();
    public RunState Run = new RunState();

    public bool landed = true;
    public bool moving = false, walking = false, crouching = false, jumping = false, running = false;

    InputAction crouchAction;

    void Awake()
    {
        pRenderer = GetComponentInChildren<PlayerRenderer>();
        col = GetComponent<Collider>();
        playerInputActions = new InputActions();
        
        SwitchState(Idle);
    }

    private void OnEnable(){
        playerInputActions = new InputActions();
        SwitchState(Idle);

        playerInputActions.Player.Move.performed += onMove;
        playerInputActions.Player.Move.Enable();

        playerInputActions.Player.Run.performed += onRun;
        playerInputActions.Player.Run.Enable();

        playerInputActions.Player.Jump.performed += onJump;
        playerInputActions.Player.Jump.Enable();

        playerInputActions.Player.Crouch.performed += onCrouch; 
        playerInputActions.Player.Crouch.Enable();
    }

    private void OnDisable(){
        playerInputActions.Player.Move.performed -= onMove;
        playerInputActions.Player.Move.Disable();

        playerInputActions.Player.Run.performed -= onRun;
        playerInputActions.Player.Run.Disable();

        playerInputActions.Player.Jump.performed -= onJump;
        playerInputActions.Player.Jump.Disable();

        playerInputActions.Player.Crouch.performed -= onCrouch;
        playerInputActions.Player.Crouch.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLanded();
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseMovementState state){
        currentState = state;
        currentState.EnterState(this);
    }

    private void CheckLanded() {
        //발 위치에 작은 구를 하나 생성에 그 구에 땅이 닿는지 검사한다.
        //1 << 6은 Ground의 레이어가 6이기 때문.
        landed = Physics.CheckSphere(new Vector3(col.bounds.center.x, col.bounds.center.y - ((HEIGHT - 1f) / 2 + 0.15f), col.bounds.center.z), 0.45f, 1 << 6, QueryTriggerInteraction.Ignore);
        if(landed && jumping){ jumping = false;}
    }

    void onMove(InputAction.CallbackContext context){
        if(landed){
            Vector2 input = context.ReadValue<Vector2>();
            if(input.magnitude > 0.1f){
                moveDirection = new Vector3(input.x, 0, input.y);
                if(!moving) moving = true;
                if(running) walking = false;
                else walking = true;
            }
            else{
                Debug.Log("Stop");
                moving = false;
            }
        }
    }

    void onJump(InputAction.CallbackContext context){
        if (!jumping){
            Debug.Log("jumping");
            jumping = true;
            landed = false;
        }
    }

    void onCrouch(InputAction.CallbackContext context){
        if(crouching) crouching = false;
        else crouching = true;
    }

    void onRun(InputAction.CallbackContext context){
        Debug.Log("Run pressed");
        if(!running) {
            running = true;
        }
        else {
            running = false;
        }
    }
}
