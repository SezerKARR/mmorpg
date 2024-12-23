using UnityEngine.Events;

namespace Script.Enemy
{
    public class EnemyHealth
    {
        private float maxHealth;
        public float currentHealth;
        public  UnityAction OnDeath;
        public  EnemyHealth(float health)
        {
            maxHealth = health;
            currentHealth = health;
        }
        public float getCurrentHealth() => currentHealth;

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if(currentHealth <= 0) OnDeath?.Invoke();
        }
    }
}