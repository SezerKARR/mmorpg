using System.Collections.Generic;
using Script.Equipment;
using UnityEngine;

namespace Script.ScriptableObject.Equipment
{
    public enum TypeWeapon
    {
        None,Swords, TwoHandedWeapons, Blades, Fans, Bells, Daggers, Bows, Claws
    }
    [CreateAssetMenu(menuName = "ScriptableObject/Weapon")]
    public class SwordSo : ScriptableItemsAbstract
    {
        public override ObjectType Type => ObjectType.Item; 
        public List<Vector2> minAndMaxAttackValue=new List<Vector2>();
        public List<Vector2> minAndMaxMagicalAttackValue = new List<Vector2>();
        public List<float> attackSpeed = new List<float>();
        public TypeWeapon typeWeapon;
        public int sockets;
        // public override EquipmentType GetEquipmentType()
        // {
        //     return weaponType;
        // }
        //
        //
        // public override Dictionary<StatType, float> GetStats()
        // {
        //     Dictionary<StatType, float> charStats= new Dictionary<StatType, float>();
        //     if (minAndMaxMagicalAttackValue.Count > 0)
        //     {
        //         charStats.IsAdd(StatType.MinMagicAttack, minAndMaxMagicalAttackValue[currentPlus].x);
        //         charStats.IsAdd(StatType.MaxMagicAttack, minAndMaxMagicalAttackValue[currentPlus].y);
        //     }
        //     charStats.IsAdd(StatType.MinAttack, minAndMaxAttackValue[currentPlus].x);
        //     charStats.IsAdd(StatType.MaxAttack, minAndMaxAttackValue[currentPlus].y);
        //     charStats.IsAdd(StatType.AttackSpeed, attackSpeed[currentPlus]);
        //     return charStats;
        // }
        // public override void SetStats()
        // {
        //     if (minAndMaxMagicalAttackValue.Count > 0)
        //     {
        //         charStats.IsAdd(StatType.MinMagicAttack, minAndMaxMagicalAttackValue[currentPlus].x);
        //         charStats.IsAdd(StatType.MaxMagicAttack, minAndMaxMagicalAttackValue[currentPlus].y);
        //     }
        //     charStats.IsAdd(StatType.MinAttack, minAndMaxAttackValue[currentPlus].x);
        //     charStats.IsAdd(StatType.MaxAttack, minAndMaxAttackValue[currentPlus].y);
        //     charStats.IsAdd(StatType.AttackSpeed, attackSpeed[currentPlus]);
        // }


    
    }
}