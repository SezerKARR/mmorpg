using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Script;
using Script.Bonus;
using Script.Equipment;
using Script.Inventory;
using Script.Player;
using Script.ScriptableObject.Equipment;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Serialization;
using Stats = Script.Bonus.Stats;

public enum Character
{
    Warrior, Sura, Ninja, Shaman, Lycan
}

[System.Serializable]
public class UpgradeItem
{
    public ScriptableObject upgradeItemName;
    public int howMany;
}
[System.Serializable]
public class RequirementClass
{
    public UpgradeItem[] upgradeItems=new UpgradeItem[0];
    
    public float upgradeMoney;
    
}

public abstract  class ScriptableItemsAbstact : ObjectAbstract 

{
    
    public float price;
    public ObjectType objectType=ObjectType.Item;
    public List<(string bonusName ,float bonusValue)> bonuses=new List<(string bonusName ,float bonusValue)>() ;
    public List<(string bonusName, List<float> bonusValue)> ItemBonuses = new List<(string bonusName, List<float> bonusValue)>();
    
    public int levelWithPlus;
    public int currentPlus = 0;
    /*public enum canUseCharacter
    {
        Warrior,Shaman,Sura,Ninja
    }*/
    [FormerlySerializedAs("itemstats")] public Stats  stats;
   
    public List<Character> canUseCharacters = new List<Character>();
    public RequirementClass[] Requirements =new RequirementClass[0];
    public abstract EquipmentType equipmentType { get; }
    
    public int level;
    // public void SetNewStats()
    // {
    //     foreach (var itemstat in stats)
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
    // public ScriptableItemsAbstact GetScriptableItemsAbstact()
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
    // public List<Character> GetCanUseCharacters()
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
