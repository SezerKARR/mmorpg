using System;
using UnityEngine;
using static Script.Anim.AnimAndDirection;

namespace Script.Anim
{
    public  class CharacterAnims
    {
        public Animator animator;
        private AnimationEnum _currentAnimation;
        private String _direction;
        

        public CharacterAnims(Animator animator,float speed)
        {
            this.animator = animator;
            UpdateAnim(AnimationEnum.Idle,Vector2.left,speed);
        }
        private void AnimController(AnimationEnum animationEnum,string direction,float speed)
        {
            if(_currentAnimation==animationEnum&&_direction==direction)return;
            _currentAnimation = animationEnum;
            _direction = direction;
            string animWithDirection = animationEnum.ToString() + direction;
            animator.CrossFade(animWithDirection, speed);
        }
        public  void UpdateAnim(AnimationEnum animationEnum,Vector2 direction,float speed=0.2f)
        {
            
            AnimController(animationEnum,DirectionToString(direction),0.2f);
        }
       

        private string DirectionToString(Vector2 direction)
        {
            if (AnimAndDirection.DirectionToStringMap.TryGetValue(direction, out string directionString))
            {
                return directionString;
            }
            return null;
        }
    }
}