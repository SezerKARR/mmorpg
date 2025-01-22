using System;
using System.Collections.Generic;
using Script.Bonus;
using Script.Equipment;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.ScriptableObject.Objects.Equipment
{
    [Serializable]
    public enum CharacterType
    {
       None, Warrior, Sura, Ninja, Shaman, Lycan
    }

    [System.Serializable]
    public class Require
    {
        public UnityEngine.ScriptableObject upgradeItemName;
        public UpgradeItemsSO upgradeItem;
        public int howMany;
    }
    [System.Serializable]
    public class RequirementClass
    {
        public Require[] upgradeItems=new Require[0];
    
        public float upgradeMoney;
    
    }

    public abstract  class ScriptableItemsAbstract : ObjectAbstract 

    {
    
        public float price;
        public ObjectType objectType=ObjectType.Item;
        public List<(string bonusName, List<float> bonusValue)> ıtemBonuses = new List<(string bonusName, List<float> bonusValue)>();
    
        public int levelWithPlus;
        public CharStat  itemStat;
        [SerializeField]
        public List<CharacterType> canUseCharacters = new List<CharacterType>();
        [FormerlySerializedAs("Requirements")] public RequirementClass[] requirements =new RequirementClass[0];
        public EquipmentType equipmentType;
        public int level;
        public abstract List<string> GetStatsString(int level);
        // public void SetNewStats()
        // {
        //     foreach (var itemstat in charStats)
        //     {
        //         PlayerController.instance.EquipmentStat.AddModifier(itemstat.Key, itemstat.Value);
        //     }
        //             
        // }

        public void SetOldStats()
        {
                
        }
        // public string GetCurrentPlus()
        // {
        //     return currentPlus.ToString();
        // }
        //
        //
        // public ScriptableItemsAbstract GetScriptableItemsAbstact()
        // {
        //     return this;
        // }
        // public override void SetDropName()
        // {
        //     DropName= $"{ItemName}+{currentPlus}";
        // }
    
        // public abstract Dictionary<StatType, float> GetStats();
        // public void SetNewStats()
        // {
        //     var modifiers = GetStats();
        //     foreach (var modifier in modifiers)
        //     {
        //         
        //         PlayerController.instance.EquipmentStat.AddModifier(modifier.Key, modifier.Value);
        //     }
        // }
        //
        // public void SetOldStats()
        // {
        //     var modifiers = GetStats();
        //     foreach (var modifier in modifiers)
        //     {
        //         PlayerController.instance.EquipmentStat.RemoveModifier(modifier.Key, modifier.Value);
        //     }
        // }
        // public void GetBonus()
        // {
        //     throw new NotImplementedException();
        // }
        //
        //
        //
        // public void SetNewBonus()
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public void SetOldBonus()
        // {
        //     throw new NotImplementedException();
        // }
        // public int GetLevel()
        // {
        //     return level;
        // }
        //
        // public List<CharacterType> GetCanUseCharacters()
        // {
        //     return canUseCharacters;
        // }
        //
        // public abstract EquipmentType GetEquipmentType();
        //
        // public override ObjectType GetTypeController()
        // {
        //     return ObjectType.Item;
        // }
    
    }
}