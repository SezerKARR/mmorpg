using Script.Damage;

namespace Script.DamageText.DamageTexts
{
    public class NormalDamageText : DamageTextBone
    {
        public DamageType damageType=DamageType.Normal;
        //protected override DamageType DamageType=>damageType;
        public override string GetPoolType()=>damageType.ToString();
    }
}
