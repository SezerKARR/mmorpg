using System;
using Script.Inventory.Objects;
using UnityEngine;

namespace Script.Inventory
{
    public static class ObjectEvents
    {
        public static Action<ObjectAbstract,int,GameObject> OnPickUp;
        public static Action<ObjectController,ObjectAbstract> ObjectClicked;
       
    }
}