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
        public void Place(Transform parent, Vector2 positon)
        {
            cellIndex = new int2(-1, -1);
            transform.SetParent(parent);
            //objectView.SetPosition(new Vector2(positon.x, positon.y));
        }

        public override void RightClick()
        {
            _equipmentManager.ControlCanEquip(itemable, this);
        }

        public override void Place(Transform parent, int2 cellInt2, int howMany, IInventorObjectable objectToPlace, float height, float weight)
        {
            
            if(inventorObjectable is IItemable itemablea) this.itemable = itemablea;
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

