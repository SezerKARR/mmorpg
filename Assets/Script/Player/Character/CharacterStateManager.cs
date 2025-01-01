using System;
using System.Collections;
using Script.Anim;
using Script.Damage;
using Script.Interface;
using Script.Player.PlayerState;
using Script.ScriptableObject.Player;
using UnityEngine;

namespace Script.Player.Character
{
    public abstract class CharacterStateManager:MonoBehaviour,IDamager
    {
        protected Vector2 _direction;
        public Animator animator;
        public CharacterModel characterModel;
        protected CharacterState _currentState;
        public CharacterAnims characterAnims;
        public AttackState attackState;
        public MoveState moveState;
        public IdleState idleState;
        public StopState stopState;
        public DamageCalculator damageCalculator;
        public CharacterState nextState;
        protected virtual void Awake()
        {
            Debug.Log($"{gameObject.name} Awake çağrıldı, aktif mi? {gameObject.activeSelf}");
            damageCalculator = new DamageCalculator();
            characterModel=GameEvent.OnGetCharacterModel?.Invoke(this.gameObject.name);
            animator = GetComponent<Animator>();
            characterAnims = new CharacterAnims(animator);
            attackState = new AttackState(this);
            moveState = new MoveState(this);
            stopState = new StopState(this);
            idleState = new IdleState(this);
            nextState = stopState;
        }
        protected virtual void MoveCanceled()
        {
            nextState = stopState;
            ControlState(moveState);
            

            
        }
        protected virtual void ShootCanceled()
        {
            nextState= stopState;
            ControlState(attackState);
        }

        protected virtual void ControlState(CharacterState state)
        {
            if (_currentState == state)
            {
                ControlChangeState(nextState);
            }
        }
        protected virtual void Update()
        { Debug.Log($"{gameObject.name} Awake çağrıldı, aktif mi? {gameObject.activeSelf}");
            if (_currentState == null)
            {
                _currentState = stopState;
                _currentState.EnterState(Vector2.down);
            }
            _currentState.UpdateState();
        }
        protected virtual void CanChangeStateToMove(Vector2 walkDirection)
        {
            Debug.Log("move");
            _direction = walkDirection;
            ControlChangeState(moveState);
        }
        protected virtual void CanChangeStateToIdle()
        {
            nextState = idleState;
            ControlChangeState(idleState);
        }
        protected virtual void CanChangeStateToAttack()
        {
            nextState = _currentState;
            ControlChangeState(attackState);

        }
        
        
        protected virtual void StartPlayerCoroutine(IEnumerator routine)
        {
            StartCoroutine(routine); // Coroutine'i ba�lat
        }
        protected virtual void Start()
        {
          
            _currentState =stopState;
            _currentState.EnterState(Vector2.down);
        }
        
        protected virtual void ControlChangeState(CharacterState newState)
        {
            if (_currentState.CanTransitionTo(newState, _direction))
            {
                ChangeState(newState);
            }
        }
        
        protected virtual void ChangeState(CharacterState newState)
        {
            if (newState != null)
            {
                _currentState.ExitState();
                _currentState = newState;
                _currentState.EnterState(_direction);
            }
            
        }

        protected virtual CharacterState GetState(CharacterState stateType)
        {
            return stateType;
        }

        public string GetName()
        {
            return this.gameObject.name;
        }

        public Action<int, long> onEnemyKilled { get; set; }
        public CharacterNormalAttackData GetCharacterNormalAttackData()
        {
            return characterModel.GetCharacterDamageData();
        }

        public void GiveNormalDamage(IDamageAble damageAble)
        {
            throw new NotImplementedException();
        }

        public void GiveDamage(float damage, IDamageAble damageAble, DamageType damageType)
        {
            throw new NotImplementedException();
        }
    }
}