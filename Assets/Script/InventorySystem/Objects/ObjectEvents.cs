using System;
using Script.DroppedItem;

namespace Script.InventorySystem.Objects
{
    public static class ObjectEvents
    {
        public static Action<IPickedUpAble> OnPickUp;
        public static Action<ObjectController> ObjectClicked;
       
    }
}