using System;
using Script.Player.Character;
using Script.ScriptableObject.Equipment;

namespace Script.Damage
{
    [Serializable]
    public class ElementDefence : UnityDictionary<Element, float>{};
    [Serializable]
    public class WaponTypeDefence : UnityDictionary<TypeWeapon, float>{};
    public class CharacterNormalDefenderData
    {
        public float blockNormalAttack;
        public float defense;
        public WaponTypeDefence waponTypeDefence;
        public Element element;
        public ElementDefence elementDefence;
        public Race race;
    }
    public class CharacterSkillDefenderData
    {
       
    }
}