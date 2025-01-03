using Script.Anim;
using Script.Player.Character;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public class StopState:CharacterState
    {
        public StopState(CharacterStateManager manager) : base(manager)
        {
        }


        public override void UpdateState()
        {
            _stateManager.characterAnims.UpdateAnim(AnimationEnum.Stop,direction,0.0f);
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override bool CanTransitionTo(CharacterState newState, string direction)
        {
            return base.CanTransitionTo(newState, direction);
        }
    }
}