using UnityEngine;

namespace Script.Damage
{
    public class DamageCalculator
    {
        public float CalculateDamage(CharacterNormalAttackData atacker, CharacterNormalDefenderData defender)
        {
            if (defender.blockNormalAttack >= Random.Range(0f, 100f))
            {
                return 0f;
            }
            float atackerDamage=Random.Range(atacker.minDamage, atacker.maxDamage);
            float damage = atackerDamage - defender.defense;
            damage = damage * atacker.raceAttack[defender.race];
            if(defender.elementDefence.TryGetValue(atacker.element, value: out var value))
                damage = damage * (100 - value)/100f;
            if(defender.waponTypeDefence.TryGetValue(atacker.weaponType, out var value1))
                damage = damage * (100 - value1)/100f;
            if (atacker.critChange >= Random.Range(0f, 100f)) damage =damage* 2;
            return damage;
            
        }
        
        //  public float DamageCalculator(CharacterSkillAttackData atacker, CharacterSkillDefenderData defender)
        // {
        //     if (defender.blockNormalAttack >= Random.Range(0f, 100f))
        //     {
        //         return 0f;
        //     }
        // }
    }
}