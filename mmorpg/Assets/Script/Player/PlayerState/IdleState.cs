using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState :  IState
{
    public void EnterState(Player player)
    {
        //MonoBehaviour.print("idlestate");
    
    }

    public void ExitState(Player player)
    {
        //MonoBehaviour.print("geldi");
    }

    public void UpdateState(Player player)
    {
        player.animator.SetFloat("StopedPos", player.animValue);
        if (player.animator.GetFloat("StopedPos") > 0)
        {
            player.animator.SetFloat("WalkPos", 0);
            player.animator.SetFloat("IdlePos", -1);
            // StartCoroutine(WaitBeforeIdle(player));
        }
        player.CanChangeStateToWalk();

        player.CanChangeStateToAttack();
    }

    IEnumerator WaitBeforeIdle(Player player)
    {
        
        yield return new WaitForSeconds(5);
        if (player.animator.GetFloat("WalkPos") == 0 && player.animator.GetFloat("IdlePos") == -1)
        {
            player.animator.SetFloat("IdlePos", player.animValue);

        }

    }
}
