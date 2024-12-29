using System.Collections;
using System.Collections.Generic;
using Script.Anim;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public class PlayerStateManager : MonoBehaviour
    {
   
        private Vector2 _direction;
        public Animator animator;
        [HideInInspector]
        public int animValue;
        private CharacterState _currentState;
        public CharacterAnims characterAnims;
        public AttackState attackState;
        public MoveState moveState;
        public IdleState idleState;
        public StopState stopState;
        public CharacterState nextState;
        private void Awake()
        {
            
            animator = GetComponent<Animator>();
            characterAnims = new CharacterAnims(animator);
            attackState = new AttackState(this);
            moveState = new MoveState(this);
            stopState = new StopState(this);
            idleState = new IdleState(this);
            nextState = stopState;
            InputPlayer.OnMovePressed += CanChangeStateToMove;
            InputPlayer.OnNormalAttackPressed += CanChangeStateToAttack;
            InputPlayer.OnMoveCancel += MoveCanceled;
            InputPlayer.OnShootCancel += ShootCanceled;
        }

        private void MoveCanceled()
        {
            nextState = stopState;
                ControlState(moveState);
            

            
        }
        private void ShootCanceled()
        {
            
            ControlState(attackState);
        }

        private void ControlState(CharacterState state)
        {
            if (_currentState == state)
            {
                ControlChangeState(nextState);
            }
        }
        void Start()
        {
            // Durumlar� olu�tur

            //states.Add(PlayerStateType.Jump, new JumpState(this));
            //states.Add(PlayerStateType.Dodge, new DodgeState(this));

            // �lk durumu ayarla
            _currentState =stopState;
            _currentState.EnterState(Vector2.down);
        }
        private void Update()
        {
            if (_currentState == null)
            {
                _currentState = stopState;
                _currentState.EnterState(Vector2.down);
            }
            _currentState.UpdateState();
        }
        public void CanChangeStateToMove(Vector2 walkDirection)
        {
            Debug.Log("move");
            _direction = walkDirection;
            ControlChangeState(moveState);
        }
        public void CanChangeStateToIdle()
        {
            nextState = idleState;
            ControlChangeState(idleState);
        }
        public void CanChangeStateToAttack()
        {
            nextState = _currentState;
            ControlChangeState(attackState);

        }
        
        
        public void StartPlayerCoroutine(IEnumerator routine)
        {
            StartCoroutine(routine); // Coroutine'i ba�lat
        }
        public void ControlChangeState(CharacterState newState)
        {
            if (_currentState.CanTransitionTo(newState, _direction))
            {
                ChangeState(newState);
            }
        }
        
        public void ChangeState(CharacterState newState)
        {
            if (newState != null)
            {
                _currentState.ExitState();
                _currentState = newState;
                _currentState.EnterState(_direction);
            }
            
        }

        public CharacterState GetState(CharacterState stateType)
        {
            return stateType;
        }
    }
}