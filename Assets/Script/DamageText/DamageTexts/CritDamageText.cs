using Script.Damage;

namespace Script.DamageText.DamageTexts
{
    public class CritDamageText : DamageTextBone
    {
        public DamageType damageType=DamageType.Crit;

        public override string GetPoolType()=>damageType.ToString();

        public override void Initialize(string damage)
        {
           base.Initialize(damage);
           
        }
    }
}
