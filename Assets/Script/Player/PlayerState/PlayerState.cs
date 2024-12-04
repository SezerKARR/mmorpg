using UnityEngine;

public abstract class PlayerState
{
    
    protected Animator animator;
    protected PlayerStateManager stateManager;
    

    public PlayerState(PlayerStateManager manager)
    {
        stateManager = manager;
        animator = stateManager.GetComponent<Animator>();

        
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
    public virtual bool CanTransitionTo(PlayerState newState)
    {
        if (newState == this)
        {
            return false;
        }
        return true; // Default: Geçiþ yapýlabilir
    }
}

