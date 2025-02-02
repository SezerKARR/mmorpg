using System;
using System.Linq;
using Script.Bonus;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

/* Contains all the charStats for a characterType. */

namespace Script.ScriptableObject.Player
{
    
    public  class CharacterStats : UnityEngine.ScriptableObject
    {
        
        // public CharacterStats()
        // {
        //     foreach (StatType statType in Enum.GetValues(typeof(StatType)).Cast<StatType>().Skip(1))
        //     {
        //         if (!charStats.ContainsKey(statType))
        //         {
        //             this.charStats[statType] = 0;
        //         }
        //         
        //     }
        // }
        //  
        // public void UpdateStats(CharStat upgradeCharStat,bool isEquipped)
        // {
        //     foreach (var itemStat in upgradeCharStat)
        //     {
        //         int equipVal = isEquipped ? 1 : -1;
        //         if (this.charStats.ContainsKey(itemStat.Key))
        //         {
        //             this.charStats[itemStat.Key]+= equipVal*itemStat.Value;
        //         }
        //         else
        //         {
        //             this.charStats[itemStat.Key] = itemStat.Value;
        //         }
        //     }
        // }

        //
        // public int currentHealth { get; protected set; }    // Current amount of health
        //
        // public int damage;
        // public int armor;
        //
        // public event System.Action OnHealthReachedZero;
        //
        // public virtual void Awake()
        // {
        //     currentHealth = maxHealth;
        // }
        //
        // // Start with max HP.
        // public virtual void Start()
        // {
        //
        // }
        //
        // // Damage the characterType
        // public void TakeDamage(int damage)
        // {
        //     // Subtract the armor value - Make sure damage doesn't go below 0.
        //     damage -= armor;
        //     damage = Mathf.Clamp(damage, 0, int.MaxValue);
        //
        //     // Subtract damage from health
        //     currentHealth -= damage;
        //     Debug.Log(transform.name + " takes " + damage + " damage.");
        //
        //     // If we hit 0. Die.
        //     if (currentHealth <= 0)
        //     {
        //         if (OnHealthReachedZero != null)
        //         {
        //             OnHealthReachedZero();
        //         }
        //     }
        // }
        //
        // // Heal the characterType.
        // public void Heal(int amount)
        // {
        //     currentHealth += amount;
        //     currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        // }



    }
}