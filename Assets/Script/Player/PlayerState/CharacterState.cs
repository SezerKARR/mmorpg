using Script.Anim;
using Script.Player.Character;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public abstract class CharacterState
    {
        protected CharacterStateManager _stateManager;
        public string direction;
        protected CharacterState(CharacterStateManager manager)
        {
            
            _stateManager = manager;

        }

    
        public virtual void EnterState(string direction)
        {
            this.direction = direction;
        }
        public virtual void UpdateState()
        {
            
        }
        public virtual void ExitState() 
        { 
        }
        public virtual bool CanTransitionTo(CharacterState newState, string direction)
        {
            if (newState == this&&direction == this.direction)
            {
                return false;
            }
            return true; // Default: Ge�i� yap�labilir
        }
    }
}

