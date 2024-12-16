using System.Collections;
using System.Collections.Generic;
using Script.Equipment;
using Script.Inventory;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/Helmet")]

public class HelmetSo : ScriptableItemsAbstact
{
    public override EquipmentType equipmentType=> EquipmentType.Helmet;
    // public override void SetStats()
    // {
    //     
    //     itemstats.Add(StatType.Defense, defence[currentPlus]);
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
    //     return equipmentType;
    // }


    
}
