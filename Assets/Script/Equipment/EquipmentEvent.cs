using System;
using Script.Inventory.Objects;
using Script.InventorySystem.Objects;
using Script.ObjectInstances;

namespace Script.Equipment
{
    public class EquipmentEvent
    {
        public static Action<ItemInstance> OnEquip;
        public static Action<ItemController> OnUnequip;
    }
}