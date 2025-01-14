using System.Collections.Generic;
using Script.ScriptableObject.Equipment;
using UnityEngine;

namespace Script.ScriptableObject.Objects.Equipment
{
    [CreateAssetMenu(menuName = "ScriptableObject/Helmet")]

    public class HelmetSo : ScriptableItemsAbstract
    {
        // public override void SetStats()
        // {
        //     
        //     charStats.Add(StatType.Defense, defence[currentPlus]);
        // }

        public List<int> defence=new List<int>();
        public override ObjectType Type => ObjectType.Item; 
        // public override Dictionary<StatType, float> GetStats()
        // {
        //     return new Dictionary<StatType, float>
        //     {
        //         { StatType.Defense, defence[currentPlus] },
        //     };
        // }
        //
        // public override EquipmentType GetEquipmentType()
        // {
        //     return weaponType;
        // }


    
    }
}
