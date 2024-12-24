using System;

namespace Script.Bonus
{
    public enum StatType
    {
        MinAttack,
        MaxAttack,
        MinMagicAttack,
        MaxMagicAttack,
        Defense,
        Critical,
        AttackSpeed
    }
    [Serializable]
    public class Stats : UnityDictionary<StatType, float> { }
}