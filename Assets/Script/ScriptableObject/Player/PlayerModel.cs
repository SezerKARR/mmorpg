using Script.Player;
using Script.ScriptableObject.Equipment;
using UnityEngine;

namespace Script.ScriptableObject.Player
{
    [CreateAssetMenu(menuName = "ScriptableObject/Player/PlayerModel")]
    public class PlayerModel : CharacterStats
    {

        public Character character = Character.Warrior;
        public int level;
        public int exp;
        
        public bool haveGroup;
        public GroupType groupType;
        




    }
}