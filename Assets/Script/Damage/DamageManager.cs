using UnityEngine;

namespace Script.Damage
{
    public class DamageManager : MonoBehaviour
    {
        public static DamageManager instance;
        [SerializeField]
        private GameObject damageTextPrefab;
        [SerializeField]
        private GameObject critDamageTextPrefab;
        [SerializeField]
        private GameObject skillDamageTextPrefab;
        private void Awake()
        {
            instance = this;
        }
        public void CreateDamageText(string damage,Vector2 position,DamageType damageType)
        {
            GameObject damageText=null;
            switch (damageType)
            {
                case DamageType.Normal:
                    damageText = Instantiate(damageTextPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                    break;
                case DamageType.Crit:
                    damageText = Instantiate(critDamageTextPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                    break;
                case DamageType.Magical:
                    damageText = Instantiate(critDamageTextPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                    break;
            }
        
            damageText.GetComponent<global::Script.Damage.DamageText.DamageText>().Initialize(damage);
        }
    }
}
