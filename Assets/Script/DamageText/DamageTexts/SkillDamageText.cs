using Script.Damage;

namespace Script.DamageText.DamageTexts
{
    public class SkillDamageText:DamageTextBone
    {
        public  DamageType damageType = DamageType.Magical;
        // protected override DamageType DamageType { get; }
        public override string GetPoolType() => damageType.ToString();
    }
}