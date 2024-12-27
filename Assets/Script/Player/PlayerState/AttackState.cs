using System.Collections;
using System.Collections.Generic;
using Script.Player.PlayerState;
using UnityEngine;

public class AttackState :  CharacterState
{
    public AttackState(PlayerStateManager manager) : base(manager) { }
    bool wait = false;
    
    public override void EnterState()       
    {
        //MonoBehaviour.print("attackstate");
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Attack();


    }
    public override bool CanTransitionTo(CharacterState newState)
    {
        return wait;
    }

    public override void ExitState( )
    {
        base.ExitState();
        animator.SetFloat("AttackPos", 0);
    }


    public float GetCurrentAnimatorTime(Animator targetAnim, int layer = 0)
    {
        AnimatorStateInfo animState = targetAnim.GetCurrentAnimatorStateInfo(layer);
        float currentTime = animState.normalizedTime % 1;
        return currentTime;
    }
    public void Attack()
    {

        if (!wait)
        {


            stateManager.StartPlayerCoroutine(Waita(GetCurrentAnimatorTime(animator)));
            //if you want the walk in attack animation time you need + call the walk() function here and
            //change the waitattack coroutine canchangestatetowalk() to if(shootFloat==0){canchangestatetowalk()}
        }
        else
        {
            return;

        }

    }
    public IEnumerator Waita(float second)
    {
        wait = true;
        animator.SetFloat("AttackPos", stateManager.animValue);
        yield return new WaitForSeconds(0.345f);
        //CanChangeStateToWalk();
        //CanChangeStateToIdle();
        wait = false;
    }
    
    


}