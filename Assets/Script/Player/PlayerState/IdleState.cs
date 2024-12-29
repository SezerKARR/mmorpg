using Script.Anim;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public class IdleState :  CharacterState
    {
        public IdleState(PlayerStateManager manager) : base(manager) { }
        public override void ExitState()
        {
            //MonoBehaviour.print("geldi");
        }

        public override void UpdateState()
        {
            _stateManager.characterAnims.UpdateAnim(AnimationEnum.Idle,_direction,0.0f);
       
        }
    }
}
