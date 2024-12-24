using System;
using UnityEngine;

namespace Script.Anim
{
    public  class CharacterAnims
    {
        public Animator animator;
        private AnimAndDirection.AnimEnum _currentAnim;
        private String _direction;
        

        public CharacterAnims(Animator animator,float speed)
        {
            this.animator = animator;
            UpdateAnim(AnimAndDirection.AnimEnum.Idle,Vector2.left,speed);
        }
        private void AnimController(AnimAndDirection.AnimEnum animEnum,string direction,float speed)
        {
            if(_currentAnim==animEnum&&_direction==direction)return;
            _currentAnim = animEnum;
            _direction = direction;
            string animWithDirection = animEnum.ToString() + direction;
            animator.CrossFade(animWithDirection, speed);
        }
        public  void UpdateAnim(AnimAndDirection.AnimEnum animEnum,Vector2 direction,float speed=0.2f)
        {
            
            AnimController(animEnum,DirectionToString(direction),0.2f);
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