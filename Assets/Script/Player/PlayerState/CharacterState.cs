using Script.Anim;
using Script.Player.Character;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public abstract class CharacterState
    {
        protected CharacterStateManager _stateManager;
        public string directionString;
        public Vector2 direction;
        protected CharacterState(CharacterStateManager manager)
        {
            
            _stateManager = manager;

        }

    
        public virtual void EnterState(string direction)
        {
            ChangeDirection(DirectionHelper.GetVector(direction));
            this.directionString = direction;
        }
        public virtual void UpdateState()
        {
            
        }
        public virtual void ExitState() 
        { 
        }

        public virtual void ChangeDirection(Vector2 direction)
        {
            this.direction=direction;
        }
        public virtual bool CanTransitionTo(CharacterState newState, string direction)
        {
            if (newState == this&&direction == this.directionString)
            {
                return false;
            }
            return true; // Default: Ge�i� yap�labilir
        }
    }
}

