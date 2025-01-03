using Script.Anim;
using Script.Player.Character;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public class MoveState : CharacterState
    {
        public float moveSpeed = 7f;
        public Vector2 moveDirection = Vector2.zero;
        
        public MoveState(CharacterStateManager manager) : base(manager)
        {
        
        }
        public override void UpdateState()
        {
            Walk();


        }
        public void Walk()
        {
            _stateManager.characterAnims.UpdateAnim(AnimationEnum.Walk, direction);
            moveDirection = DirectionHelper.GetVector(direction).normalized;
            _stateManager.transform.position += new Vector3(moveDirection.x, moveDirection.y, 0f) * moveSpeed * Time.deltaTime;
        }
  
        public override void ExitState()
        {

        }
        
    }
}
