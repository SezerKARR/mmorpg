using System.Collections;
using Script.Anim;
using Script.Damage;
using Script.DamageText;
using Script.Interface;
using Script.Player.Character;
using UnityEngine;
using Zenject;

namespace Script.Player.PlayerState
{
    public class AttackState :  CharacterState
    {
        [Inject] private DamageTextManager _damagageTextManager;
        private CharacterNormalAttackData _attackData;
        public AttackState(CharacterStateManager manager) : base(manager)
        {
            _attackData = manager.characterModel.GetCharacterDamageData();
        }
        private CharacterState _nextState = null;

        public override void UpdateState()
        {
            base.UpdateState();
            Debug.Log(_attackData.minDamage);
            _stateManager.characterAnims.UpdateAnim(AnimationEnum.Attack,_direction);
            

        }
        public override bool CanTransitionTo(CharacterState newState, Vector2 direction)
        {
            _nextState = newState;
            Attack();
            return false;
        }
        // public  void GiveDamage( IDamageAble damageAble)
        // {
        //     float damage=
        //     damageAble.TakeDamage(damage , this);
        //     DamageTextEvent.OnDamage(damage.ToString(), damageAble.GetPosition(), damageType);
        // }
        
        public override void ExitState( )
        {
            base.ExitState();
        }


       
        public void Attack()
        {
            
            //_stateManager.StartPlayerCoroutine(Waita(_stateManager.characterAnims.GetRemainingAnimationTime()));
            //if you want the walk in attack animation time you need + call the walk() function here and
            //change the waitattack coroutine canchangestatetowalk() to if(shootFloat==0){canchangestatetowalk()}

        }
        public IEnumerator Waita(float second)
        {
           
            while ( !_stateManager.characterAnims.IsAnimationComplete())
            {
                yield return null;
                
            }
            //_stateManager.ChangeState(_nextState);
            
            
        }
    
    


    }
}