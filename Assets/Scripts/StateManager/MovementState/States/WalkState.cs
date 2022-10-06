public class WalkState : BaseMovementState
{
    public override void EnterState(MovementStateManager movement){
        movement.pRenderer.toggleWalk(true);
    }

    public override void UpdateState(MovementStateManager movement){
        if (movement.moving && movement.running) ExitState(movement, movement.Run);
        else if (movement.crouching) ExitState(movement, movement.Crouch);
        if (!movement.moving) ExitState(movement, movement.Idle);
    }

    void ExitState(MovementStateManager movement, BaseMovementState state){
        movement.pRenderer.toggleWalk(false);
        movement.SwitchState(state);
    }

}