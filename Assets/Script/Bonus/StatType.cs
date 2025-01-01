using System;

namespace Script.Bonus
{
    public enum StatType
    {
        None,
        MinAttack,
        MaxAttack,
        MinMagicAttack,
        MaxMagicAttack,
        Defense,
        CritChange,
        AttackSpeed,
        CritDamageRate
    }
    [Serializable]
    public class Stat : UnityDictionary<StatType, float> { }
}