using Script.Bonus;
using Script.ScriptableObject.Equipment;

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


        public Stats GetStats()
        {
            return scriptableItemsAbstact.stats;
        }
        public void SetOldStats()
        {
            scriptableItemsAbstact.SetOldStats();
        }
    }
}

