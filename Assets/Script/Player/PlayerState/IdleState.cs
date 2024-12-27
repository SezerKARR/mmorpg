using Script.Anim;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public class IdleState :  CharacterState
    {
        public IdleState(PlayerStateManager manager,Vector2 direction) : base(manager, direction) { }
        public override void EnterState()
        {
            //MonoBehaviour.print("idlestate");
    
        }

        public override void ExitState()
        {
            //MonoBehaviour.print("geldi");
        }

        public override void UpdateState()
        {
            _characterAnims.UpdateAnim(AnimationEnum.Idle,_direction);
       
        }
        public override bool CanTransitionTo(CharacterState newState)
        {
        
            return base.CanTransitionTo(newState);
        }
    }
}
