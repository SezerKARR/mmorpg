namespace Script.Damage.DamageTexts
{
    public class SkillDamageText:DamageTextBone
    {
        public DamageType damageType = DamageType.Magical;
        protected override DamageType DamageType { get; }
    }
}