using System;
using Script.ObjectInstances;

namespace Script.InventorySystem.Objects
{
    public static class ItemEvents
    {
        public static Action<ItemInstance> OnItemRightClickedInventory;

        public static Action<ItemController> OnItemRightClickedEquipment;

    
    }
}
