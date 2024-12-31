using TMPro;
using UnityEngine;

namespace Script.Damage.DamageText
{
    public class DamageText : MonoBehaviour
    {
        public Vector2 initialVelocity; // Ba�lang�� h�z�
        public float gravity = 9.8f;    // Yer�ekimi
        public float lifetime = 2f;     // Objenin yok olma s�resi

        protected Vector2 _startPosition;
        protected float _timeElapsed;
        [SerializeField]
        protected TextMeshPro damageText;
        // Start is called before the first frame update
        public virtual void Initialize(string damage)
        {
            damageText.text = damage;
            _startPosition = transform.position;
        }
        protected virtual void Update()
        {
            _timeElapsed += Time.deltaTime;

            // Parabolik hareket form�l�
            float newX = _startPosition.x + initialVelocity.x * _timeElapsed;
            float newY = _startPosition.y + initialVelocity.y * _timeElapsed - 0.5f *  Mathf.Pow(_timeElapsed, 2);

            transform.position = new Vector3(newX, newY, transform.position.z);

            // Belirtilen s�re sonunda objeyi yok et
            if (_timeElapsed >= lifetime/2)
            {
                Destroy(gameObject);
            }
        }
    }
}
