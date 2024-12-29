using System;
using Script.Player;
using Script.ScriptableObject.Equipment;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.ScriptableObject.Player
{
    [CreateAssetMenu(menuName = "ScriptableObject/Player/CharacterModel")]
    public class CharacterModel : CharacterStats
    {
        public string playerName="satisfaction";
        [FormerlySerializedAs("character")] public CharacterType characterType = CharacterType.Warrior;
        public int level;
        public int exp;
        
        public bool haveGroup;
        public GroupType groupType;

       
    }
}