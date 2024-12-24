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
        void OnEquipmentChanged(IItemable newItem, IItemable oldItem)
        {
            /*if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier());
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.armorModifier);
        }*/

        }




    }
}