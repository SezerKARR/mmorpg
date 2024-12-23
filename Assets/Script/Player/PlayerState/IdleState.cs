using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState :  PlayerState
{
    public IdleState(PlayerStateManager manager) : base(manager) { }
    public override void EnterState()
    {
        //MonoBehaviour.print("idlestate");
    
    }

    public override void ExitState()
    {
        //MonoBehaviour.print("geldi");
    }

    public override void UpdateState()
    {
        animator.SetFloat("StopedPos", stateManager.animValue);
        if (animator.GetFloat("StopedPos") > 0)
        {
            animator.SetFloat("WalkPos", 0);
            animator.SetFloat("IdlePos", -1);
            // StartCoroutine(WaitBeforeIdle(playerController));
        }
       
    }
    public override bool CanTransitionTo(PlayerState newState)
    {
        
        return base.CanTransitionTo(newState);
    }

    IEnumerator WaitBeforeIdle(PlayerMovement player)
    {
        
        yield return new WaitForSeconds(5);
        if (animator.GetFloat("WalkPos") == 0 && animator.GetFloat("IdlePos") == -1)
        {
            animator.SetFloat("IdlePos", stateManager.animValue);

        }

    }
}
