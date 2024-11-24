using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IState 
{
     public void EnterState(Player player)
    {
        //MonoBehaviour.print("walkstate");
    }
    public void UpdateState(Player player)
    {
        player.Walk();
        
        player.CanChangeStateToAttack();
        player.CanChangeStateToIdle();
    }
    public void ExitState(Player player)
    {
        
    }
}
