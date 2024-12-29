using Script.Anim;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public class MoveState : CharacterState
    {
        public float moveSpeed = 7f;
        public Vector2 moveDirection = Vector2.zero;
        
        public MoveState(PlayerStateManager manager) : base(manager)
        {
        
        }
        public override void UpdateState()
        {
            Walk();


        }
        public void Walk()
        {
            _stateManager.characterAnims.UpdateAnim(AnimationEnum.Walk, _direction);
            moveDirection = _direction.normalized;
            _stateManager.transform.position += new Vector3(moveDirection.x, moveDirection.y, 0f) * moveSpeed * Time.deltaTime;
        }
  
        public override void ExitState()
        {

        }
        
    }
}
