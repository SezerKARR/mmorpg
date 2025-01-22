using System;
using System.Collections.Generic;
using Script.Equipment;
using Script.ScriptableObject;
using Script.ScriptableObject.Objects.Equipment;

namespace Script.ObjectInstances
{
    [Serializable]
    public class ItemInstance:ObjectInstance
    {
        public ItemInstance(ObjectAbstract objectAbstract) : base(objectAbstract)
        {
            scriptableItemsAbstract = (ScriptableItemsAbstract)objectAbstract;
        }
        public ScriptableItemsAbstract scriptableItemsAbstract;
        public List<(string bonusName ,float bonusValue)> bonuses=new List<(string bonusName ,float bonusValue)>() ;
        public int currentPlus = 0;


        public int maxPlus => scriptableItemsAbstract.requirements.Length - 1;

        public int level=>scriptableItemsAbstract.level;
        public List<CharacterType> canUseCharacters=>scriptableItemsAbstract.canUseCharacters;
        public EquipmentType equipmentType => scriptableItemsAbstract.equipmentType;
        public override string ObjectName() => scriptableItemsAbstract.itemName+" "+currentPlus;
        public List<string> itemStats => scriptableItemsAbstract.GetStatsString(currentPlus);
        

        public List<string> ItemBonuses(){
            List<string> bonusesString = new List<string>();
            try
            {
                foreach (var bonus in bonuses)
                {
                    bonusesString.Add($"{bonus.bonusName}"+": "+"{bonus.bonusValue}"); 
                }
               
            }
            catch (Exception e)
            {
                // ignored
            }

            return bonusesString;
        }
        public override string DropName() {return ObjectName(); }
        public ItemInstance Clone( )
        {
            ItemInstance clone = new ItemInstance(scriptableItemsAbstract);
            clone.currentPlus = currentPlus;
            clone.bonuses=bonuses;
            
            return clone;
        }
    }
}