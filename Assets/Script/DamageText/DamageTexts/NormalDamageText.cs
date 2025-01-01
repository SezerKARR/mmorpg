using TMPro;
using UnityEngine;

namespace Script.Damage.DamageTexts
{
    public class NormalDamageText : DamageTextBone
    {
        public DamageType damageType=DamageType.Normal;
        protected override DamageType DamageType=>damageType;
    }
}
