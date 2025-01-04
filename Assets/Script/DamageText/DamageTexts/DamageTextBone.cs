using System;
using Cysharp.Threading.Tasks;
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

        protected virtual void OnEnable()
        {
            
        }

       

        protected virtual async void StartDamageTextMovement()
        {
            try
            {
                float timeElapsed = 0f;

                while (timeElapsed < lifetime / 2)
                { 
                    timeElapsed += Time.deltaTime;
                    await UniTask.Yield(); // Bir sonraki frame'e geçmeyi bekler
                    float newX = _startPosition.x + initialVelocity.x * timeElapsed;
                    float newY = _startPosition.y + initialVelocity.y * timeElapsed - 0.5f *  Mathf.Pow(timeElapsed, 2);
                    transform.position = new Vector3(newX, newY, transform.position.z);
                }
                DamageTextEvent.OnFinishTextTime?.Invoke(this);

                // İşlemler tamamlandıktan sonra objeyi devre dışı bırak
                gameObject.SetActive(false);
            }
            catch (Exception e)
            {
                Debug.Log(e);


            }
        }

        public void OnActivate(string damage, Vector2 position)
        {
            Debug.Log(this.gameObject.name);
            this.gameObject.SetActive(true);
            damageText.text = damage;
            this.transform.position=position;
            _startPosition = transform.position;
            StartDamageTextMovement();
        }
    }
}
