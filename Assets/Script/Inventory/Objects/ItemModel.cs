using Script.Equipment;
using UnityEngine;

namespace Script.Inventory.Objects
{
    public class ItemModel:ObjectModel
    {
        
            [SerializeField] private ScriptableItemsAbstact itemSO;

           

            public override void SetObjectAbstract(ObjectAbstract objectAbstract)
            {
                itemSO=objectAbstract is ScriptableItemsAbstact ? objectAbstract as ScriptableItemsAbstact : null;
                base.SetObjectAbstract(objectAbstract);
            }
           
            public void SetNewStats()
            {
                foreach (var itemstat in itemSO.itemstats)
                {
                    Player.instance.EquipmentStat.AddModifier(itemstat.Key, itemstat.Value);
                }
                
            }

            public void SetOldStats()
            {
                
            }
            public ScriptableItemsAbstact ItemSO=>itemSO;
            public EquipmentType EquipmentType => itemSO.equipmentType;
    }
}