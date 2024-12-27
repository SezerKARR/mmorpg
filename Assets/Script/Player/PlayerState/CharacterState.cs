using Script.Anim;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public abstract class CharacterState
    {
        protected CharacterAnims _characterAnims;
        protected Animator _animator;
        protected PlayerStateManager _stateManager;
        protected Vector2 _direction;

        protected CharacterState(PlayerStateManager manager, Vector2 direction)
        {
            _direction = direction;
            _stateManager = manager;
            _animator = _stateManager.animator;
            _characterAnims=new CharacterAnims(_animator);

        }

    
        public virtual void EnterState()
        {
            
        }
        public virtual void UpdateState()
        {
            
        }
        public virtual void ExitState() 
        { 
        }
        public virtual bool CanTransitionTo(CharacterState newState)
        {
            if (newState == this)
            {
                return false;
            }
            return true; // Default: Ge�i� yap�labilir
        }
    }
}

