using Script.Equipment;
using Script.ScriptableObject.Equipment;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Script.Inventory.Objects
{
    public class ItemController : ObjectController
    {
       
        public ScriptableItemsAbstact scriptableItemsAbstact;
        private void OnEnable()
        {
            scriptableItemsAbstact=objectAbstract is ScriptableItemsAbstact ? objectAbstract as ScriptableItemsAbstact :null ;
        }


        public override string GetPoolType()
        {
            return ObjectType.Item.ToString();
        }

        public override void RightClick()
        {
            ItemEvents.OnItemRightClickedInventory(this);
            /*if (inventorObjectable.GetItemPlace() == ItemPlace.Inventory)
            {
                
            }
            else if (inventorObjectable.GetItemPlace() == ItemPlace.Equipment)
            {
                ItemEvents.OnItemRightClickedEquipment(this);
            }*/
            
        }


        public ScriptableItemsAbstact.Itemstats GetStats()
        {
            return scriptableItemsAbstact.itemstats;
        }
        public void SetOldStats()
        {
            scriptableItemsAbstact.SetOldStats();
        }
    }
}

