using UnityEngine;
public class RunState : BaseMovementState
{
    public override void EnterState(MovementStateManager movement){
        Debug.Log("run state entered");
        movement.pRenderer.toggleRun(true);
    }

    public override void UpdateState(MovementStateManager movement){
        if(!movement.moving){
            ExitState(movement, movement.Idle);
        }
        else if(movement.walking){
            ExitState(movement, movement.Walk);
        }
    }

    void ExitState(MovementStateManager movement, BaseMovementState state){
        movement.pRenderer.toggleRun(false);
        movement.SwitchState(state);
    }
}