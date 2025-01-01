using System;
using Script.ScriptableObject;
using UnityEngine;

namespace Script.Inventory.Objects
{
    public static class ObjectEvents
    {
        public static Action<ObjectAbstract,int,GameObject> OnPickUp;
        public static Action<ObjectController> ObjectClicked;
       
    }
}