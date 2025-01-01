using Script.Damage;
using Script.Player;
using Script.Player.Character;
using UnityEngine;

namespace Script.Interface
{
    public interface IDamageAble
    {
    
        //void TakeDamage(float damage );
        void TakeDamage(float damage,IDamager damager);
        public CharacterNormalDefenderData GetNormalDefenderData();
        public CharacterSkillDefenderData GetSkillDefenderData();
        void Death( );
        Vector2 GetPosition();
        
    
    }
}
