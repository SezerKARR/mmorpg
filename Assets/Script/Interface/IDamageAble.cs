

using UnityEngine;

public interface IDamageAble
{
    
    //void TakeDamage(float damage );
    void TakeDamage(float damage,Player player);
    void Death(Player player);
    Vector2 GetPosition();
    
}
