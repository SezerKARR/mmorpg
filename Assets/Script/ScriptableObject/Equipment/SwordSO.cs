using System.Collections.Generic;
using Script.Equipment;
using UnityEngine;

namespace Script.ScriptableObject.Equipment
{
    public enum TypeWeapon
    {
        Swords, TwoHandedWeapons, Blades, Fans, Bells, Daggers, Bows, Claws
    }
    [CreateAssetMenu(menuName = "ScriptableObject/Weapon")]
    public class SwordSo : ScriptableItemsAbstact
    {
        public override EquipmentType equipmentType => EquipmentType.Weapon;
        public override ObjectType Type => ObjectType.Item; 
        public List<Vector2> minAndMaxAttackValue=new List<Vector2>();
        public List<Vector2> minAndMaxMagicalAttackValue = new List<Vector2>();
        public List<float> attackSpeed = new List<float>();
        public TypeWeapon typeWeapon;
        public int sockets;
        // public override EquipmentType GetEquipmentType()
        // {
        //     return equipmentType;
        // }
        //
        //
        // public override Dictionary<StatType, float> GetStats()
        // {
        //     Dictionary<StatType, float> stats= new Dictionary<StatType, float>();
        //     if (minAndMaxMagicalAttackValue.Count > 0)
        //     {
        //         stats.Add(StatType.MinMagicAttack, minAndMaxMagicalAttackValue[currentPlus].x);
        //         stats.Add(StatType.MaxMagicAttack, minAndMaxMagicalAttackValue[currentPlus].y);
        //     }
        //     stats.Add(StatType.MinAttack, minAndMaxAttackValue[currentPlus].x);
        //     stats.Add(StatType.MaxAttack, minAndMaxAttackValue[currentPlus].y);
        //     stats.Add(StatType.AttackSpeed, attackSpeed[currentPlus]);
        //     return stats;
        // }
        // public override void SetStats()
        // {
        //     if (minAndMaxMagicalAttackValue.Count > 0)
        //     {
        //         stats.Add(StatType.MinMagicAttack, minAndMaxMagicalAttackValue[currentPlus].x);
        //         stats.Add(StatType.MaxMagicAttack, minAndMaxMagicalAttackValue[currentPlus].y);
        //     }
        //     stats.Add(StatType.MinAttack, minAndMaxAttackValue[currentPlus].x);
        //     stats.Add(StatType.MaxAttack, minAndMaxAttackValue[currentPlus].y);
        //     stats.Add(StatType.AttackSpeed, attackSpeed[currentPlus]);
        // }


    
    }
}