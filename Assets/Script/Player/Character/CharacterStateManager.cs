using System.Collections;
using Script.Anim;
using Script.Damage;
using Script.Player.PlayerState;
using Script.ScriptableObject.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Player.Character
{
    public  class CharacterStateManager:MonoBehaviour
    {
        protected string _direction;
        public Animator animator;
        [FormerlySerializedAs("charController")] public ScriptableObject.Player.CharacterModel characterModel;
        public CharacterAnims characterAnims;
        
        protected CharacterState _currentState;
        public AttackState attackState;
        public MoveState moveState;
        public IdleState idleState;
        public StopState stopState;
        public CharacterState nextState;
        
        protected virtual void Awake()
        {
            characterModel=GameEvent.OnGetCharacterModel?.Invoke(this.gameObject.name);
            animator = GetComponent<Animator>();
            characterAnims = new CharacterAnims(animator);
            attackState = new AttackState( this);
            moveState = new MoveState(this);
            stopState = new StopState(this);
            idleState = new IdleState(this);
            nextState = stopState;
        }
        protected virtual void MoveCanceled()
        {
            if(nextState==moveState)
                nextState = stopState;
            
            ControlState(moveState);
            

            
        }
        protected virtual void ShootCanceled()
        { 
            // if(nextState!=moveState)
                // nextState= stopState;
            // ControlState(attackState);
            ControlChangeState(nextState);
        }

        protected virtual void ControlState(CharacterState state)
        {
            if (_currentState == state)
            {
                ControlChangeState(stopState);
            }
        }
        protected virtual void Update()
        { 
            if (_currentState == null)
            {
                _currentState = stopState;
                _currentState.EnterState("Down");
            }
            _currentState.UpdateState();
        }
        protected virtual void CanChangeStateToMove(Vector2 walkDirection)
        {
            Debug.Log(walkDirection);
            string direction = DirectionHelper.GetDirection(walkDirection);
            ChangeDirection(walkDirection);
            if (direction == null)
            {
                return;
            }
            
            ControlChangeState(moveState,direction);
            
            
        }

        protected void ChangeDirection(Vector2 direction)
        {
            _currentState.ChangeDirection(direction);
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
            _currentState.EnterState("Down");
        }

        protected virtual void ControlChangeState(CharacterState newState)
        {
            string direction = _currentState.directionString;
            if (direction == null)
                direction = "Up";
            ControlChangeState(newState, _currentState.directionString);
        }
        protected virtual void ControlChangeState(CharacterState newState,string direction)
        {
            
            if (newState == _currentState && direction == _currentState.directionString)
            {
                return;
            }
            
            if (_currentState.CanTransitionTo(newState, direction))
            {
                ChangeState(newState, direction);
            }
        }
        
        public virtual void ChangeState(CharacterState newState,string direction)
        {
            if (newState != null)
            {
                _currentState.ExitState();
                _currentState = newState;
                _currentState.EnterState(direction);
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

        // public Action<int, long> onEnemyKilled { get; set; }
        // public CharacterNormalAttackData GetCharacterNormalAttackData()
        // {
        //     return characterModel.GetCharacterDamageData();
        // }
        //
        // public void GiveNormalDamage(IDamageAble damageAble)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public void GiveDamage(float damage, IDamageAble damageAble, DamageType damageType)
        // {
        //     throw new NotImplementedException();
        // }
    }
}