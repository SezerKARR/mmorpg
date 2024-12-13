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
        public EquipmentManager _equipmentManager;
        public IItemable itemable;
        

        public override void RightClick()
        {
            ItemEvents.OnItemRightClickedInventory(this);
            if (inventorObjectable.GetItemPlace() == ItemPlace.Inventory)
            {
                
            }
            else if (inventorObjectable.GetItemPlace() == ItemPlace.Equipment)
            {
                ItemEvents.OnItemRightClickedEquipment(this);
            }
            
        }

        public override void Place(Transform parent)
        {
           
            base.Place(parent);
            //objectView.SetPosition(new Vector2(positon.x, positon.y));
        }
        public override void Place(Transform parent, int2 cellInt2, int howMany, IInventorObjectable objectToPlace, float height, float weight)
        {
            
            if(objectToPlace is IItemable itemable) this.itemable = itemable;
            base.Place(parent, cellInt2, howMany, objectToPlace, height, weight);
        }

        public void SetNewStats()
        {
            itemable.SetNewStats();
        }
        public void SetOldStats()
        {
            itemable.SetOldStats();
        }
    }
}

