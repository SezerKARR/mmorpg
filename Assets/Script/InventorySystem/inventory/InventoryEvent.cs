using System;
using System.Collections.Generic;
using Script.DroppedItem;
using Script.Inventory.Objects;
using Script.InventorySystem.Objects;
using Script.ObjectInstances;
using Script.ScriptableObject;
using Unity.Mathematics;
using UnityEngine;

namespace Script.InventorySystem.inventory
{
    public class InventoryEvent
    {
        public static  Action<ObjectInstance> OnAdd;
        public static Action<ObjectInstance> OnInitializeStoreageItem;
        public static  Action<ItemController,CellsInfo> OnUnEquipItem;
        public static  Action<ObjectController,CellsInfo> OnChangedObjectPosition;
        public static Action<ObjectInstance> OnDropObject;
        public static Action<ObjectInstance> OnItemPickUp;
        public delegate CellsInfo GetEmptyCells(int weightInInventory,int howMany);
        public static GetEmptyCells OnGetEmptyCells;
    }
}