using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Anim
{
    public  class CharacterAnims
    {
        private readonly Animator _animator;
        private AnimationEnum _currentAnimation;
        private String _direction;
        

        public CharacterAnims(Animator animator)
        {
            Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
            Vector2 randomDirection = directions[Random.Range(0, directions.Length)];
            this._animator = animator;
            UpdateAnim(AnimationEnum.Idle,randomDirection);
            
        }
        private void AnimController(AnimationEnum animationEnum,string direction,float speed)
        {
            if(_currentAnimation==animationEnum&&_direction==direction)return;
            _currentAnimation = animationEnum;
            _direction = direction;
            string animWithDirection = animationEnum.ToString() + direction;
            _animator.CrossFade(animWithDirection, speed);
        }
        public  void UpdateAnim(AnimationEnum animationEnum,Vector2 direction,float speed=0.2f)
        {
            
            AnimController(animationEnum,DirectionToString(direction),0.2f);
        }
       

        private string DirectionToString(Vector2 direction)
        {
            return AnimAndDirection.DirectionToStringMap.GetValueOrDefault(direction);
        }
    }
}