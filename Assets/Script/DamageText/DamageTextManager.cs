using UnityEngine;
using Script.Damage.DamageTexts;
using Script.Inventory.Objects;
using Script.ScriptableObject.Prefab;

namespace Script.Damage
{
    public class DamageTextManager : MonoBehaviour
    {
        public static DamageTextManager İnstance;
        [SerializeField] private ItemPrefabList damageTextList;
        private ObjectPooler _objectPooler;

        private void Awake()
        {
            DamageTextEvent.OnDamage += CreateDamageText;
            İnstance = this;
            _objectPooler=new ObjectPooler(damageTextList,this.transform,10);
        }
        private void CreateDamageText(string damage,Vector2 position,DamageType damageType)
        {
            DamageTextBone damageTextBone= _objectPooler.SpawnFromPool<DamageTextBone>(damageType.ToString());
            // if(damageTexts.Keys.Contains(da))
            // GameObject damageText=null;
            // switch (damageType)
            // {
            //     case DamageType.Normal:
            //         damageText = Instantiate(damageTextPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
            //         break;
            //     case DamageType.Crit:
            //         damageText = Instantiate(critDamageTextPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
            //         break;
            //     case DamageType.Magical:
            //         damageText = Instantiate(critDamageTextPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
            //         break;
            // }
            //
            // if (damageText != null) damageText.GetComponent<NormalDamageText>().Initialize(damage);
        }
        private void CloseDamageText(DamageTextBone damageTextBone)
        {
            _objectPooler.ReturnObject(damageTextBone.GetPoolType(), damageTextBone.gameObject);
        }
    }
}
