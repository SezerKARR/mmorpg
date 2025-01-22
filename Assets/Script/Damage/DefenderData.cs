using System;
using Script.Player.Character;
using Script.ScriptableObject.Objects.Equipment;

namespace Script.Damage
{
    [Serializable]
    public class ElementDefence : UnityDictionary<Element, float>{};
    [Serializable]
    public class WaponTypeDefence : UnityDictionary<TypeWeapon, float>{};
    public class CharacterNormalDefenderData
    {
        public float blockNormalAttackChange;
        public float defense;
        public WaponTypeDefence waponTypeDefence;
        public Element elements;
        public Race race;
    }
    public class CharacterSkillDefenderData
    {
       
    }
}