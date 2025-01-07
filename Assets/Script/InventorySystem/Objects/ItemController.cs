using Script.Bonus;
using Script.ObjectInstances;
using Script.ScriptableObject;
using UnityEngine.Serialization;

namespace Script.InventorySystem.Objects
{
    public class ItemController : ObjectController
    {
       
        [FormerlySerializedAs("scriptableItemsAbstact")] public ItemInstance itemInstance;
        private void OnEnable()
        {
            itemInstance=objectInstance is ItemInstance ? objectInstance as ItemInstance :null ;
        }


        public override string GetPoolType()
        {
            return ObjectType.Item.ToString();
        }

        public override void RightClick()
        {
            ItemEvents.OnItemRightClickedInventory(this);
            /*if (inventorObjectable.GetItemPlace() == ItemPlace.InventorySystem)
            {
                
            }
            else if (inventorObjectable.GetItemPlace() == ItemPlace.Equipment)
            {
                ItemEvents.OnItemRightClickedEquipment(this);
            }*/
            
        }


        // public CharStat GetStats()
        // {
        //     return itemInstance.itemStat;
        // }
        // public void SetOldStats()
        // {
        //     itemInstance.SetOldStats();
        // }
    }
}

