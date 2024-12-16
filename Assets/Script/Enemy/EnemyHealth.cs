namespace Script.Enemy
{
    public class EnemyHealth
    {
        public float maxHealth;
        public float currentHealth;

        public  EnemyHealth(float health)
        {
            maxHealth = health;
            currentHealth = health;
        }
        public float getCurrentHealth() => currentHealth;

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
        }
    }
}