using UnityEngine;

public class JumpState : BaseMovementState
{
    private static float jumpAmout = 5f;
    private static float HEIGHT = 2f;
    private bool isGrounded = true;
    public override void EnterState(MovementStateManager movement){
        Debug.Log("jump state entered");
        isGrounded = false;
        Vector3 vel = movement.rigid.velocity;
        vel.y = jumpAmout;
        movement.rigid.velocity = vel;
        movement.pRenderer.Jump();
    }

    public override void UpdateState(MovementStateManager movement){
        isGrounded = CheckLanded(movement);
        if(isGrounded){
            if(movement.moving) ExitState(movement, movement.Walk);
            else if(movement.running)ExitState(movement, movement.Run);
            else ExitState(movement, movement.Idle);
        }
    }

    void ExitState(MovementStateManager movement, BaseMovementState state){
        movement.jumping = false;
        movement.landed = true;
        movement.SwitchState(state);
    }

    private bool CheckLanded(MovementStateManager movement) {
        //발 위치에 작은 구를 하나 생성에 그 구에 땅이 닿는지 검사한다.
        //1 << 6은 Ground의 레이어가 6이기 때문.
        return Physics.CheckSphere(new Vector3(movement.col.bounds.center.x, movement.col.bounds.center.y - ((HEIGHT - 1f) / 2 + 0.15f), movement.col.bounds.center.z), 0.45f, 1 << 6, QueryTriggerInteraction.Ignore);
    }

}