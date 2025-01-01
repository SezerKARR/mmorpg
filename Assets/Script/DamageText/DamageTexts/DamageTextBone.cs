using Script.Damage;
using TMPro;
using UnityEngine;
using IPoolable = Script.Interface.IPoolable;

namespace Script.DamageText.DamageTexts
{
    public  class DamageTextBone : MonoBehaviour,IPoolable
    {
    
        public Vector2 initialVelocity; // Ba�lang�� h�z�
        public float lifetime = 2f;     // Objenin yok olma s�resi
        public DamageType damageType=DamageType.None;
        protected Vector2 _startPosition;
        protected float _timeElapsed;
        [SerializeField]
        protected TextMeshPro damageText;

        private IPoolable _ıPoolableImplementation;

        public virtual string GetPoolType()
        {
            return damageType.ToString();
        }
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
               DamageTextEvent.OnFinishTextTime?.Invoke(this);
            }
        }


        public void OnActivate(string damage, Vector2 position)
        {
            this.gameObject.SetActive(true);
            damageText.text = damage;
            this.transform.position=position;
            _startPosition = transform.position;
        }
    }
}
