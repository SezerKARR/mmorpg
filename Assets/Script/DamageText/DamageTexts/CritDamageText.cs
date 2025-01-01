namespace Script.DamageText.DamageTexts
{
    public class CritDamageText : DamageTextBone
    {
        public DamageType damageType=DamageType.Crit;
        // protected override DamageType DamageType=>damageType;

        public override void Initialize(string damage)
        {
           base.Initialize(damage);
           
        }
    }
}
