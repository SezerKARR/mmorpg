using Script.Player;
using Script.Player.Character;
using UnityEngine;

namespace Script.Interface
{
    public interface IDamageAble
    {
    
        //void TakeDamage(float damage );
        void TakeDamage(float damage,IDamager damager);
        void Death( );
        Vector2 GetPosition();
    
    }
}
