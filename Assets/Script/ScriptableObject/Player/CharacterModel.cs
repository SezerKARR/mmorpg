using Script.ScriptableObject.Equipment;
using UnityEngine;

namespace Script.ScriptableObject.Player
{
    [CreateAssetMenu(menuName = "ScriptableObject/Player/CharacterModel")]
    public class CharacterModel : UnityEngine.ScriptableObject
    {
        public string characterName="satisfaction";
        public PolygonCollider2D[] attackColliderNormalSword;
        public CharacterType characterType = CharacterType.Warrior;
        public TypeWeapon typeWeapon = TypeWeapon.None;
        public int level;
        public long exp;
        public CharacterStats stats;
        public bool haveGroup;
        public GroupType groupType;

       
    }


    
}