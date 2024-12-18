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
       
        public ScriptableItemsAbstact itemModel;
        private void Awake()
        {
            itemModel=objectAbstract is ScriptableItemsAbstact ? objectAbstract as ScriptableItemsAbstact :null ;
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


        public void SetNewStats()
        {
            itemModel.SetNewStats();
        }
        public void SetOldStats()
        {
            itemModel.SetOldStats();
        }
    }
}

