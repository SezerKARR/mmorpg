using Script.Damage;
using Script.DamageText.DamageTexts;
using Script.Inventory.Objects;
using Script.InventorySystem.Objects;
using Script.ScriptableObject.Prefab;
using UnityEngine;

namespace Script.DamageText
{
    public class DamageTextManager : MonoBehaviour
    {
        [SerializeField] private ItemPrefabList damageTextList;
        private ObjectPooler _objectPooler;

        private void Awake()
        {
            DamageTextEvent.OnDamage += CreateDamageText;
            DamageTextEvent.OnFinishTextTime += CloseDamageText;
            _objectPooler=new ObjectPooler(damageTextList,this.transform,10);
        }
        private void CreateDamageText(string damage,Vector2 position,DamageType damageType)
        {
            _objectPooler.SpawnFromPool<DamageTextBone>(damageType.ToString()).OnActivate(damage,position);
           
        }
        private void CloseDamageText(DamageTextBone damageTextBone)
        {
            _objectPooler.ReturnObject(damageTextBone);
        }
    }
}
