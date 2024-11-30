using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MoveState : PlayerState
{
    public float moveSpeed = 7f;
    public Vector2 moveDirection = Vector2.zero;
    public MoveState(PlayerStateManager manager, Vector2 moveDirection) : base(manager)
    {
        this.moveDirection = moveDirection;
    }
    public override void EnterState()
    {
        //MonoBehaviour.print("walkstate");
    }
    public override void UpdateState()
    {
        Walk(this.moveDirection);


    }
    public void Walk(Vector2 moveDirection)
    {
        switch (moveDirection.x, moveDirection.y)
        {

            case (0, -1):

                PlayerWalk(1);
                break;
            case (1, 0):
                PlayerWalk(2);
                break;
            case (0, 1):
                PlayerWalk(3);
                break;
            case (-1, 0):
                PlayerWalk(4);
                break;
        }
        moveDirection = moveDirection.normalized;
        Debug.Log(moveDirection);
        stateManager.transform.position += new Vector3(moveDirection.x, moveDirection.y, 0f) * moveSpeed * Time.deltaTime;
    }
    public void PlayerWalk(int animvalue)
    {
        stateManager.animValue = animvalue;
        animator.SetFloat("StopedPos", 0);
        animator.SetFloat("IdlePos", -1);
        animator.SetFloat("WalkPos", stateManager.animValue);
    }
    public override void ExitState()
    {

    }
    public override bool CanTransitionTo(PlayerState newState)
    {
        return base.CanTransitionTo(newState);
    }
}
