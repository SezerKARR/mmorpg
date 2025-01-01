using Script.Player.Character;
using Script.ScriptableObject.Equipment;

namespace Script
{
    public enum DamageType
    {
        None,
        Normal,
        Crit,
        Magical
    }
    public class RaceAttack : UnityDictionary<Race, float>{};
    public class  CharacterNormalAttackData
    {
        public float critChange;
        public float critDamageRate;
        public float minDamage;
        public float maxDamage;
        public TypeWeapon weaponType;
        public Element element;
        public RaceAttack raceAttack;

    }
    
    public class  CharacterSkillAttackData
    {
        public float skillCritChange;
        public float critDamageRate;
        public float minMagicDamage;
        public float maxMagicDamage;
    }
    
    
}