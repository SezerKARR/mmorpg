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
        private AnimatorStateInfo _currentAnimState;

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
            
            AnimController(animationEnum,DirectionToString(direction),speed);   
        }
        public bool IsAnimationComplete()
        {
            _currentAnimState = _animator.GetCurrentAnimatorStateInfo(0);
            return _currentAnimState.normalizedTime >= 0.97f;
        }
        public float GetRemainingAnimationTime()
        {
            // Animator'dan şu anki animasyon clip'inin süresi
            AnimationClip currentClip = _animator.GetCurrentAnimatorClipInfo(0)[0].clip;
            float animationLength = currentClip.length; // Animasyonun toplam süresi
            float normalizedTime = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime; // 0.0 - 1.0 arasında geçen süre
            float remainingTime = animationLength * (1f - (normalizedTime % 1f)); // Kalan süre hesaplanır
            return remainingTime;
        }
        public float GetCurrentAnimatorTime(int layer = 0)
        {
            float currentTime = _currentAnimState.normalizedTime % 1;
            return currentTime;
        }
        private string DirectionToString(Vector2 direction)
        {
            return AnimAndDirection.DirectionToStringMap.GetValueOrDefault(direction);
        }
    }
}