using System;
using System.Collections.Generic;
using Script.Inventory.Objects;
using Script.ScriptableObject;
using Unity.Mathematics;
using UnityEngine;

namespace Script.Inventory
{
    public class InventoryEvent
    {
        // public static event Action<ObjectAbstract, int> OnObjectAdded;
        // public static event Action<ObjectController> OnObjectSelected;
        public static  Action<List<int2>,int,ObjectAbstract,int> OnAdd;
        public static Action<List<int2>, int, ObjectAbstract, int> OnCreateItem;
        public static  Action<ItemController,List<int2>,int> OnUneqipItem;
        public static  Action<ObjectController,List<int2>,int> OnChangedObjectPosition;
        public static Action<ObjectAbstract> OnDropObject;
        public static Action<GameObject> OnItemPickUp;
    }
}