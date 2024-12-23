using System;
using Script.Inventory.Objects;

namespace Script.Equipment
{
    public class EquipmentEvent
    {
        public static Action<ItemController> OnEquip;
        public static Action<ItemController> OnUnequip;
    }
}