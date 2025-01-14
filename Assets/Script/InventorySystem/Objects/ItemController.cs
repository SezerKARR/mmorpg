using Script.Bonus;
using Script.ObjectInstances;
using Script.ScriptableObject;
using UnityEngine.Serialization;

namespace Script.InventorySystem.Objects
{
    public class ItemController : ObjectController
    {
       
        [FormerlySerializedAs("scriptableItemsAbstract")] public ItemInstance itemInstance=null;
        

        
        public override string GetPoolType()
        {
            return ObjectType.Item.ToString();
        }

        public override void RightClick()
        {
            ItemEvents.OnItemRightClickedInventory(this.itemInstance);
            /*if (inventorObjectable.GetItemPlace() == ItemPlace.InventorySystem)
            {
                
            }
            else if (inventorObjectable.GetItemPlace() == ItemPlace.Equipment)
            {
                ItemEvents.OnItemRightClickedEquipment(this);
            }*/
            
        }

        public override void Place(ObjectInstance objectInstancePlace)
        {
            base.Place(objectInstancePlace);
            this.itemInstance=objectInstancePlace is ItemInstance ? objectInstancePlace as ItemInstance :null ;
        }

        // public CharStat GetStats()
        // {
        //     return itemInstance.itemStat;
        // }
        // public void SetOldStats()
        // {
        //     itemInstance.SetOldStats();
        // }
        public void Reset()
        {
            this.itemInstance = null;
            this.gameObject.SetActive(false);
        }
    }
}

