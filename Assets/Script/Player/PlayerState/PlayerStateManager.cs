using System.Collections;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public class PlayerStateManager : MonoBehaviour
    {
        public static PlayerStateManager Instance;
        private CharacterState _currentState;
        private PlayerMovement _playerMovement;
        public Animator animator;
        [HideInInspector]
        public int animValue;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
            Instance = this;
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
            _currentState = new IdleState(this);
            _currentState.EnterState();
        }
        private void Update()
        {
            if (_currentState == null)
            {
                _currentState = new IdleState(this);
                _currentState.EnterState();
            }
            _currentState.UpdateState();
        }
        public void CanChangeStateToMove(Vector2 walkDirection)
        {
            ChangeState(new MoveState(this, walkDirection));
        }
        public void CanChangeStateToIdle()
        {
            ChangeState(new IdleState(this));
        }
        public void CanChangeStateToAttack()
        {
            ChangeState(new AttackState(this));

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