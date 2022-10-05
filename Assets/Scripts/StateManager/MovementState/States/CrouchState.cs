public class CrouchState : BaseMovementState
{
    public override void EnterState(MovementStateManager movement){
        movement.pRenderer.toggleCrouch(true);
    }

    public override void UpdateState(MovementStateManager movement){
        if(!movement.crouching){
            if(!movement.moving) ExitState(movement, movement.Idle);
            else if (movement.running) ExitState(movement, movement.Run);
            else ExitState(movement, movement.Walk);
        }
    }

    void ExitState(MovementStateManager movement, BaseMovementState state){
        movement.pRenderer.toggleCrouch(false);
        movement.SwitchState(state);
    }

}