using System.Collections;
using Script.Anim;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public class AttackState :  CharacterState
    {
        public AttackState(PlayerStateManager manager,Vector2 direction) : base(manager, direction) { }
        bool wait = false;
    
    
        public override void EnterState()       
        {
            //MonoBehaviour.print("attackstate");
            _characterAnims.UpdateAnim(AnimationEnum.Attack,_direction);
            
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


                _stateManager.StartPlayerCoroutine(Waita(GetCurrentAnimatorTime(_animator)));
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
            
            yield return new WaitForSeconds(0.345f);
            //CanChangeStateToWalk();
            //CanChangeStateToIdle();
            wait = false;
        }
    
    


    }
}