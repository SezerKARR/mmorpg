using System;
using System.Collections.Generic;
using Script.Inventory.Objects;
using Unity.Mathematics;
using UnityEngine;

namespace Script.Inventory
{
    public class InventoryEvent
    {
        // public static event Action<ObjectAbstract, int> OnObjectAdded;
        // public static event Action<ObjectController> OnObjectSelected;
        public static  Action<List<int2>,int> OnAdd;
        public static  Action<ItemController,List<int2>,int> OnUneqipItem;
        public static  Action OnClickInventory;
    }
}