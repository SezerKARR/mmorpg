using System;
using UnityEngine;

namespace Script.Inventory
{
    public static class ObjectEvents
    {
        public static Action<IInventorObjectable,int,GameObject> OnPickUp;
        public static Action<ObjectController> ObjectClicked;
    }
}