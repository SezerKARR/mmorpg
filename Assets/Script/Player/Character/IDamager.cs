using System;
using Script.Interface;

namespace Script.Player.Character
{
    public interface IDamager:IGetName
    {
        Action<int,long> onEnemyKilled { get; set; }
        public CharacterNormalAttackData GetCharacterNormalAttackData();
        void GiveNormalDamage(IDamageAble damageAble);
        void GiveDamage(float damage, IDamageAble damageAble, DamageType damageType);
    }
}