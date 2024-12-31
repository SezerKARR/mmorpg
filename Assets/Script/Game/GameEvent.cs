using System;
using Script.ScriptableObject.Player;
using UnityEngine;

namespace Script
{
    public class GameEvent
    {
        public static Action< Vector3 , ObjectAbstract,string> OnItemDroppedWithPlayer;
        public static Action<ObjectAbstract,Transform> OnItemDroppedWithoutPlayer;
        public delegate CharacterModel GetCharacterModelDelegate ( string _characterId );
        public static GetCharacterModelDelegate OnGetCharacterModel;
    }
}