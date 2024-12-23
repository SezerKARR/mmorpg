using System;
using UnityEngine;

namespace Script.Anim
{
    public  class CharacterAnims
    {
        public Animator animator;
        private AnimEnum _currentAnim;
        private String _direction;
        public enum AnimEnum
        {
            None,
            Idle,
            Walk,
            Attack
        }

        public CharacterAnims(Animator animator,float speed)
        {
            this.animator = animator;
            UpdateAnim(AnimEnum.Idle,Vector2.left,speed);
        }
        private void AnimController(AnimEnum animEnum,string direction,float speed)
        {
            if(_currentAnim==animEnum&&_direction==direction)return;
            _currentAnim = animEnum;
            _direction = direction;
            string animWithDirection = animEnum.ToString() + direction;
            animator.CrossFade(animWithDirection, speed);
        }
        public  void UpdateAnim(AnimEnum animEnum,Vector2 direction,float speed=0.2f)
        {
            
            AnimController(animEnum,DirectionToString(direction),0.2f);
        }
       

        private String DirectionToString(Vector2 direction)
        {
           if(direction==Vector2.right)return "Right";
           if(direction==Vector2.left)return "Left";
           if(direction==Vector2.up)return "Up";
           if(direction==Vector2.down)return "Down";
           return null;
        }
    }
}