using System;
using Script.Interface;
using UnityEngine;

namespace Script.Player
{
    public class DeteckCollider : MonoBehaviour
    {
        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponentInParent<CharacterController>();

            if (_characterController == null)
            {
                Debug.LogError("CharacterController not found in parent chain!");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageAble>();
            if (damageable != null)
            {
                _characterController.GiveNormalDamage(damageable);
            }
        
        }
    }
}
