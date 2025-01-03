using Script.Bonus;
using Script.Damage;
using Script.Player.Character;
using Script.ScriptableObject.Equipment;
using UnityEngine;

namespace Script.ScriptableObject.Player
{
    
    [CreateAssetMenu(menuName = "ScriptableObject/Player/CharacterModel")]
    public class CharacterModel : UnityEngine.ScriptableObject
    {
        public string characterName="satisfaction";
        public CharacterType characterType = CharacterType.Warrior;
        public TypeWeapon typeWeapon = TypeWeapon.None;
        public int level;
        public long exp;
        public Stat stats;
        public bool haveGroup;
        public GroupType groupType;
        public Element element;
        
        public CharacterNormalAttackData GetCharacterDamageData()
        {
            if(stats==null){}
            CharacterNormalAttackData characterNormalAttackData = new CharacterNormalAttackData()
            {
                critChange = GetStat(StatType.CritChange),
                critDamageRate = GetStat(StatType.CritDamageRate),
                minDamage = GetStat(StatType.MinAttack),
                maxDamage = GetStat(StatType.MaxAttack),
                weaponType = typeWeapon,
                attackSpeed = GetStat(StatType.AttackSpeed),
                element=this.element,
            };

            return characterNormalAttackData;
        }

        public float GetStat(StatType statType)
        {
            if(stats.TryGetValue(statType, out var stat))return stat;
            stats[statType] = 0f;
            return stats[statType];
        }
        public void UpdateStats(Stat upgradeStat,bool isEquipped)
        {
            foreach (var stat in upgradeStat)
            {
                int equipVal = isEquipped ? 1 : -1;
                if (this.stats.ContainsKey(stat.Key))
                {
                    this.stats[stat.Key]+= equipVal*stat.Value;
                }
                else
                {
                    this.stats[stat.Key] = stat.Value;
                }
            }
        }
        
    }
    


    
}