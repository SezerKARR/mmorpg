using Script.Anim;
using Script.Player.Character;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public abstract class CharacterState
    {
        protected CharacterStateManager _stateManager;
        protected Vector2 _direction;
        
        public Vector2 Direction=>_direction;
        protected CharacterState(CharacterStateManager manager)
        {
            
            _stateManager = manager;

        }

    
        public virtual void EnterState(Vector2 direction)
        {
            _direction = direction;
        }
        public virtual void UpdateState()
        {
            
        }
        public virtual void ExitState() 
        { 
        }
        public virtual bool CanTransitionTo(CharacterState newState, Vector2 direction)
        {
            if (newState == this&&direction == _direction)
            {
                return false;
            }
            return true; // Default: Ge�i� yap�labilir
        }
    }
}

