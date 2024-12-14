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
                throw new System.NotImplementedException();
            }

            public void SetOldStats()
            {
                throw new System.NotImplementedException();
            }
            public ScriptableItemsAbstact ItemSO=>itemSO;
            public EquipmentType EquipmentType => itemSO.equipmentType;
    }
}