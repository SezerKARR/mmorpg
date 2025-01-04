using Script.Anim;
using Script.Interface;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Player.Character
{
    
    public class NormalAttackCollider:MonoBehaviour
    {
        private CharController _charController;
        private void Awake()
        {
            _charController = GetComponentInParent<CharController>();

            if (_charController == null)
            {
                Debug.LogError("CharacterModel not found in parent chain!");
            }
        }
        

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageAble>();
            if (damageable != null)
            {
                _charController.GiveNormalDamage(damageable);
            }
        
        }
    }
}