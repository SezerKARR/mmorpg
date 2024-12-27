using Script.Anim;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public abstract class CharacterState
    {
        protected CharacterAnims characterAnims;
        protected Animator animator;
        protected PlayerStateManager stateManager;


        protected CharacterState(PlayerStateManager manager)
        {
            stateManager = manager;
            animator = stateManager.animator;


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

