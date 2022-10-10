using UnityEngine;

public class WalkState : BaseMovementState
{
    public override void EnterState(MovementStateManager movement){
        Debug.Log("walk state entered");
        movement.walking = true;
        movement.pRenderer.toggleWalk(true);
    }

    public override void UpdateState(MovementStateManager movement){
        if (movement.moving && movement.running) ExitState(movement, movement.Run);
        else if (movement.crouching) ExitState(movement, movement.Crouch);
        else if (!movement.moving) ExitState(movement, movement.Idle);
        else if (movement.jumping) ExitState(movement, movement.Jump);
    }

    void ExitState(MovementStateManager movement, BaseMovementState state){
        movement.walking = false;
        movement.pRenderer.toggleWalk(false);
        movement.SwitchState(state);
    }

}