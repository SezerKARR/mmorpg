using System;
using System.Collections.Generic;
using Script.Equipment;
using Script.ScriptableObject.Equipment;

namespace Script.ObjectInstances
{
    [Serializable]
    public class ItemInstance:ObjectInstance
    {
        public ScriptableItemsAbstact abstact;
        public List<(string bonusName ,float bonusValue)> bonuses=new List<(string bonusName ,float bonusValue)>() ;
        public int currentPlus = 0;
        public int level=>abstact.level;
        public List<CharacterType> canUseCharacters=>abstact.canUseCharacters;
        public EquipmentType equipmentType => abstact.equipmentType;
        
    }
}