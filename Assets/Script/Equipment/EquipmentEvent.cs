using System;
using Script.Inventory.Objects;
using Script.InventorySystem.inventory;
using Script.InventorySystem.Objects;
using Script.ObjectInstances;

namespace Script.Equipment
{
    public class EquipmentEvent
    {
        public static Action<ItemInstance> OnEquip;
        public static Action<ItemInstance> OnUnEquip;
        public delegate bool ChangeItem(ItemInstance unequipped,ItemInstance equipped);
        public static ChangeItem OnChangeItem;
    }
}