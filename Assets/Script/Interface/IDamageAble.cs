using Script.Player;
using UnityEngine;

namespace Script.Interface
{
    public interface IDamageAble
    {
    
        //void TakeDamage(float damage );
        void TakeDamage(float damage,PlayerController playerController);
        void Death( );
        Vector2 GetPosition();
    
    }
}
