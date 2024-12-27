using Script.Player;
using Script.ScriptableObject.Equipment;

namespace Script.ScriptableObject.Player
{
    
    public class PlayerModel : CharacterStats
    {

        public Character character = Character.Warrior;
        public int level;
        public int exp;
        
        public bool haveGroup;
        public GroupType groupType;
        




    }
}