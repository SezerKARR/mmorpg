using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState :  IState
{
    
    public void EnterState(Player player)
    {
        //MonoBehaviour.print("attackstate");
    }

   

    public void ExitState(Player player)
    {

        player.animator.SetFloat("AttackPos", 0);
    }

    

    public void UpdateState(Player player)
    {

        player.Attack();


    }
   

}