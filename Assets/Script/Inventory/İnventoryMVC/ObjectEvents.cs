using System;
using UnityEngine;

namespace Script.Inventory.İnventoryMVC
{
    public static class ObjectEvents
    {
        public static Action<IInventorObjectable,int,GameObject> OnPickUp;
    }
}