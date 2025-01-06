using Script.Bonus;
using Script.Damage;
using Script.Player.Character;
using Script.ScriptableObject.Equipment;
using UnityEngine;
using UnityEngine.Serialization;

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
        [FormerlySerializedAs("stats")] public CharStat charStats;
        public bool haveGroup;
        public GroupType groupType;
        public Element element;
        public float expRate;

        public CharacterNormalAttackData GetCharacterDamageData()
        {
            if(charStats==null){}
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
            if(charStats.TryGetValue(statType, out var stat))return stat;
            charStats[statType] = 0f;
            return charStats[statType];
        }
        public void UpdateStats(CharStat upgradeCharStat,bool isEquipped)
        {
            foreach (var stat in upgradeCharStat)
            {
                int equipVal = isEquipped ? 1 : -1;
                if (this.charStats.ContainsKey(stat.Key))
                {
                    this.charStats[stat.Key]+= equipVal*stat.Value;
                }
                else
                {
                    this.charStats[stat.Key] = stat.Value;
                }
            }
        }
        
    }
    


    
}