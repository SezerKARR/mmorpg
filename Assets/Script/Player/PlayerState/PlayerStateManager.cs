using System.Collections;
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
        private void Awake()
        {
            animator = GetComponent<Animator>();
            InputPlayer.OnMovePressed += CanChangeStateToMove;
            InputPlayer.OnNormalAttackPressed += CanChangeStateToAttack;
            InputPlayer.OnIdlePerformed += CanChangeStateToIdle;
        }
        void Start()
        {
            // Durumlar� olu�tur

            //states.Add(PlayerStateType.Jump, new JumpState(this));
            //states.Add(PlayerStateType.Dodge, new DodgeState(this));

            // �lk durumu ayarla
            _currentState = new IdleState(this,Vector2.down);
            _currentState.EnterState();
        }
        private void Update()
        {
            if (_currentState == null)
            {
                _currentState = new IdleState(this,Vector2.down);
                _currentState.EnterState();
            }
            _currentState.UpdateState();
        }
        public void CanChangeStateToMove(Vector2 walkDirection)
        {
            _direction = walkDirection;
            ChangeState(new MoveState(this,walkDirection));
        }
        public void CanChangeStateToIdle()
        {
            ChangeState(new IdleState(this,_direction));
        }
        public void CanChangeStateToAttack()
        {
            ChangeState(new AttackState(this,_direction));

        }
        public void StartPlayerCoroutine(IEnumerator routine)
        {
            StartCoroutine(routine); // Coroutine'i ba�lat
        }
        public void ChangeState(CharacterState newState)
        {
            if (_currentState.CanTransitionTo(newState))
            {
                _currentState.ExitState();
                _currentState = newState;
                _currentState.EnterState();
            }
        }

        public CharacterState GetState(CharacterState stateType)
        {
            return stateType;
        }
    }
}