using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
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

public abstract  class ScriptableItemsAbstact : ObjectAbstract, IItemable,IRightClickAble
{
    
    public float price;
    
    public List<string> bonuses;
    public List<(string bonusName, List<float> bonusValue)> ItemBonuses = new List<(string bonusName, List<float> bonusValue)>();
  
    public int levelWithPlus;
    public int currentPlus = 0;
    /*public enum canUseCharacter
    {
        Warrior,Shaman,Sura,Ninja
    }*/
    public List<Character> canUseCharacters = new List<Character>();
    public RequirementClass[] Requirements =new RequirementClass[0];
    
    public int level;
    public string GetCurrentPlus()
    {
        return currentPlus.ToString();
    }
    

    public ScriptableItemsAbstact GetScriptableItemsAbstact()
    {
        return this;
    }
    public override string GetDropName()
    {
        if(bonuses.Count > 0)
        {
            return $"{ItemName}<color=yellow>+{currentPlus}</color>";
        }
        else
        {
            return $"{ItemName}<color=red>+{currentPlus}</color>";
        }
    }

    public abstract Dictionary<StatType, float> GetStats();
    public void SetNewStats()
    {
        var modifiers = GetStats();
        foreach (var modifier in modifiers)
        {
            
            Player.instance.EquipmentStat.AddModifier(modifier.Key, modifier.Value);
        }
    }

    public void SetOldStats()
    {
        var modifiers = GetStats();
        foreach (var modifier in modifiers)
        {
            Player.instance.EquipmentStat.RemoveModifier(modifier.Key, modifier.Value);
        }
    }
    public void GetBonus()
    {
        throw new NotImplementedException();
    }

   

    public void SetNewBonus()
    {
        throw new NotImplementedException();
    }

    public void SetOldBonus()
    {
        throw new NotImplementedException();
    }
    public int GetLevel()
    {
        return level;
    }

    public List<Character> GetCanUseCharacters()
    {
        return canUseCharacters;
    }

    public abstract EquipmentType GetEquipmentType();

    

    public  void RightClick(InventorButton inventorButton)
    {
        InventoryManager.Instance.EquipThisItem(inventorButton);
    }
}
