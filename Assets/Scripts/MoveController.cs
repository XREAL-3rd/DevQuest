using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpAmount = 4f;
    [SerializeField] private float damage = 10f;   

    // Start is called before the first frame update
    private Vector3 moveDirection;
    public PlayerRenderer animator;
    public Transform shootOrigin;
    private InputActions _inputActions;
    private InputAction move;
    private InputAction fire;

    private void Awake(){
        _inputActions = new InputActions();
    }

    private void OnEnable(){
        move = _inputActions.Player.Move;
        move.Enable();
    }

    private void OnDisable(){
        move.Disable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onMove(InputAction.CallbackContext context){
        
        Vector2 input = context.ReadValue<Vector2>();
        if (input != null){
            moveDirection = new Vector3(input.x, 0, input.y);
        }
    }

}
