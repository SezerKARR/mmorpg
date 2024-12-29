using System;
using UnityEngine;

namespace Script
{
    public class GameEvent
    {
        public static Action< Vector3 , ObjectAbstract,string> OnItemDroppedWithPlayer;
        public static Action<ObjectAbstract,Transform> OnItemDroppedWithoutPlayer;
    }
}