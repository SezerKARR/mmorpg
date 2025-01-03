using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Script.Anim;
using Script.Damage;
using Script.DamageText;
using Script.Player.Character;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Script.Player.PlayerState
{
    public class AttackState :  CharacterState
    {
        [Inject] private DamageTextManager _damagageTextManager;
        private CharacterNormalAttackData _attackData;

        public Collider normalAttackColliders=new Collider();
        [Serializable]
        public class Collider : UnityDictionary<String, GameObject>{};

        private bool _isAttacking;
        public AttackState( CharacterStateManager manager) : base(manager)
        {
            List<NormalAttackCollider> colliders = _stateManager.GetComponentsInChildren<NormalAttackCollider>().ToList();
            foreach (NormalAttackCollider collider in colliders)
            {
                collider.gameObject.SetActive(false);
                collider.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
                normalAttackColliders[collider.gameObject.name] = collider.gameObject;
                Debug.Log(collider.gameObject.name);
            }
            //_normalAttackCollider=manager.get
        }

        private CharacterState _nextState;
        private string _nextStateDirection;
        public override void EnterState(string direction)
        {
            _attackData = _stateManager.characterModel.GetCharacterDamageData();
            base.EnterState(direction);
            _nextState = null;
            
        }

        public override void UpdateState()
        {
            //_stateManager.StartPlayerCoroutine(Waita(_stateManager.characterAnims.GetRemainingAnimationTime()));
            base.UpdateState();
            if (!_isAttacking)
            {
                Attack(_attackData.attackSpeed);
            }
            Debug.Log(_nextState);
            Debug.Log(_attackData.minDamage);
            
            
            

        }
        public override bool CanTransitionTo(CharacterState newState, string direction)
        {
            _nextState = newState;
            _nextStateDirection = direction;
            return false;
        }

        private async void Attack(float attackSpeed)
        {
            try
            {
                float delayTime = (1000f/attackSpeed) ;
                _isAttacking = true;
                normalAttackColliders[direction].gameObject.SetActive(true);
                _stateManager.characterAnims.UpdateAnim(AnimationEnum.Attack,direction,"attackSpeed",attackSpeed);
                await UniTask.Delay((int)(delayTime));
                normalAttackColliders[direction].gameObject.SetActive(false);
                _isAttacking = false;
                if (_nextState != null) _stateManager.ChangeState(_nextState,_nextStateDirection);
            }
            catch (Exception e)
            {
                throw; // TODO handle exception
            }
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


       
        // public void Attack()
        // {
        //     
        //     //_stateManager.StartPlayerCoroutine(Waita(_stateManager.characterAnims.GetRemainingAnimationTime()));
        //     //if you want the walk in attack animation time you need + call the walk() function here and
        //     //change the waitattack coroutine canchangestatetowalk() to if(shootFloat==0){canchangestatetowalk()}
        //
        // }
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