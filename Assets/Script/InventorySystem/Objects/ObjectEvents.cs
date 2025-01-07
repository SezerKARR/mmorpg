using System;
using Script.DroppedItem;
using Script.InventorySystem.Objects;
using Script.ScriptableObject;
using UnityEngine;

namespace Script.Inventory.Objects
{
    public static class ObjectEvents
    {
        public static Action<IPickedUpAble> OnPickUp;
        public static Action<ObjectController> ObjectClicked;
       
    }
}