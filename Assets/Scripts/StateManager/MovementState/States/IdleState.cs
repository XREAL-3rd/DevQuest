using UnityEngine;
public class IdleState : BaseMovementState
{
    public override void EnterState(MovementStateManager movement){
        movement.pRenderer.toggleGrounded(true);
        Debug.Log("idle state entered");

    }

    public override void UpdateState(MovementStateManager movement){
        if(movement.jumping){
            movement.SwitchState(movement.Jump);
        }
        else if(movement.moving){
            if(movement.running) movement.SwitchState(movement.Run);
            else if (movement.walking) movement.SwitchState(movement.Walk);
        }
        else if(movement.crouching){movement.SwitchState(movement.Crouch);}
    }

}