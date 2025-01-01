using System;
using UnityEngine;

namespace Script.Damage
{
    public class DamageTextEvent
    {
        public static Action<string,Vector2,DamageType> OnDamage;
        public static Action<string,Vector2,DamageType> OnDeath;
    }
}