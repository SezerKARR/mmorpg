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
        public static Action<ObjectInstance> OnInitializeStorageItem;
        public static Action<ObjectInstance> OnDropObject;
        public static Action<ObjectInstance,CellsInfo> OnCreateItem;
        
    }
}