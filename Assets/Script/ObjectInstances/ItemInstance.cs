using System;
using System.Collections.Generic;
using Script.Equipment;
using Script.ScriptableObject;
using Script.ScriptableObject.Equipment;

namespace Script.ObjectInstances
{
    [Serializable]
    public class ItemInstance:ObjectInstance
    {
        public ScriptableItemsAbstract scriptableItemsAbstract;
        public List<(string bonusName ,float bonusValue)> bonuses=new List<(string bonusName ,float bonusValue)>() ;
        public int currentPlus = 0;
        public int level=>scriptableItemsAbstract.level;
        public List<CharacterType> canUseCharacters=>scriptableItemsAbstract.canUseCharacters;
        public EquipmentType equipmentType => scriptableItemsAbstract.equipmentType;
        public string ItemName() => scriptableItemsAbstract.itemName+" "+currentPlus;
        public List<string> itemStats => scriptableItemsAbstract.GetStatsString(currentPlus);
        public List<string> ItemBonuses(){
            List<string> bonusesString = new List<string>();
            foreach (var bonus in bonuses)
            {
                bonusesString.Add($"{bonus.bonusName}"+": "+"{bonus.bonusValue}"); 
            }
            return bonusesString;
        }
        public override string DropName() {return ItemName(); }

    }
}