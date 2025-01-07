using System;
using Script.Interface;
using Script.ObjectInstances;
using Script.ScriptableObject;
using Script.ScriptableObject.Player;
using UnityEngine;

namespace Script
{
    public class GameEvent
    {
        public static Action< Vector3 , ObjectInstance,string> OnItemDroppedWithPlayer;
        public static Action<ObjectInstance,Vector3> OnItemDroppedWithoutPlayer;
        public static Action<IPool> OnPickup;
        public delegate CharacterModel GetCharacterModelDelegate ( string _characterId );
        public static GetCharacterModelDelegate OnGetCharacterModel;
    }
}