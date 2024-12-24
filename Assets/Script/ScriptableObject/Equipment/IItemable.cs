using System.Collections.Generic;
using Script.Bonus;
using Script.Equipment;

namespace Script.ScriptableObject.Equipment
{
    public interface IItemable:IInventorObjectable
    {
        public Dictionary<StatType, float> GetStats();
    
        public void SetNewStats();
        public void SetOldStats();
        public void GetBonus();
        public void SetNewBonus();
        public void SetOldBonus();
        public int GetLevel();
        public List<Character> GetCanUseCharacters();
        public EquipmentType GetEquipmentType();
    
    }
}