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
        private void Awake()
        {
            scriptableItemsAbstact=objectAbstract is ScriptableItemsAbstact ? objectAbstract as ScriptableItemsAbstact :null ;
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
            scriptableItemsAbstact.SetNewStats();
        }
        public void SetOldStats()
        {
            scriptableItemsAbstact.SetOldStats();
        }
    }
}

