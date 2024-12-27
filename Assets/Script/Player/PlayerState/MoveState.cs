using Script.Anim;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public class MoveState : CharacterState
    {
        public float moveSpeed = 7f;
        public Vector2 moveDirection = Vector2.zero;
        public MoveState(PlayerStateManager manager,Vector2 direction) : base(manager, direction)
        {
        
        }
        public override void EnterState()
        {
            //MonoBehaviour.print("walkstate");
        }
        public override void UpdateState()
        {
            Walk();


        }
        public void Walk()
        {
            Debug.Log(_direction);
            _characterAnims.UpdateAnim(AnimationEnum.Walk, _direction,0f);
            moveDirection = _direction.normalized;
            _stateManager.transform.position += new Vector3(moveDirection.x, moveDirection.y, 0f) * moveSpeed * Time.deltaTime;
        }
  
        public override void ExitState()
        {

        }
        public override bool CanTransitionTo(CharacterState newState)
        {
            return base.CanTransitionTo(newState);
        }
    }
}
