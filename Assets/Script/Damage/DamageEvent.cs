using System;
using Script.Interface;
using Script.Player.Character;

namespace Script.Damage
{
    public class DamageEvent
    {
        public static Action<(float damage,IDamageAble defencer,IDamager attacker)> OnDamage;
    }
}