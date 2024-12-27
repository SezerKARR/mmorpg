using Script.Bonus;
using UnityEditor;

/* Contains all the stats for a character. */

namespace Script.ScriptableObject.Player
{
    
    public abstract class CharacterStats : UnityEngine.ScriptableObject
    {
        public Stats stats;
        public void UpdateStats(Stats upgradeStats,bool isEquipped)
        {
            foreach (var stat in upgradeStats)
            {
                int equipVal = isEquipped ? 1 : -1;
                if (stats.ContainsKey(stat.Key))
                {
                    stats[stat.Key]+= equipVal*stat.Value;
                }
                else
                {
                    stats[stat.Key] = stat.Value;
                }
            }
        }

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
        // // Damage the character
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
        // // Heal the character.
        // public void Heal(int amount)
        // {
        //     currentHealth += amount;
        //     currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        // }



    }
}