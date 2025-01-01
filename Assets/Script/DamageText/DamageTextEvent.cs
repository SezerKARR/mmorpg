using System;
using Script.DamageText.DamageTexts;
using UnityEngine;

namespace Script.Damage
{
    public class DamageTextEvent
    {
        public static Action<string,Vector2,DamageType> OnDamage;
        public static Action<DamageTextBone> OnFinishTextTime;
    }
}