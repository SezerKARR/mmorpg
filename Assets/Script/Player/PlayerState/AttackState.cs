using System.Collections;
using Script.Anim;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public class AttackState :  CharacterState
    {
        public AttackState(PlayerStateManager manager) : base(manager) { }
        private CharacterState _nextState = null;

        public override void UpdateState()
        {
            base.UpdateState();
            _stateManager.characterAnims.UpdateAnim(AnimationEnum.Attack,_direction);
            

        }
        public override bool CanTransitionTo(CharacterState newState, Vector2 direction)
        {
            _nextState = newState;
            Attack();
            return false;
        }

        public override void ExitState( )
        {
            base.ExitState();
        }


       
        public void Attack()
        {
            
            _stateManager.StartPlayerCoroutine(Waita(_stateManager.characterAnims.GetRemainingAnimationTime()));
            //if you want the walk in attack animation time you need + call the walk() function here and
            //change the waitattack coroutine canchangestatetowalk() to if(shootFloat==0){canchangestatetowalk()}

        }
        public IEnumerator Waita(float second)
        {
           
            while ( !_stateManager.characterAnims.IsAnimationComplete())
            {
                yield return null;
                
            }
            _stateManager.ChangeState(_nextState);
            
            
        }
    
    


    }
}