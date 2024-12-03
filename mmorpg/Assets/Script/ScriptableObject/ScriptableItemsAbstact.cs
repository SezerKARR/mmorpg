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

public abstract  class ScriptableItemsAbstact : ScriptableObject,IViewable
{
    public int weightInInventory;
    public List<string> bonuses;
    public List<(string bonusName, List<float> bonusValue)> ItemBonuses = new List<(string bonusName, List<float> bonusValue)>();
    public string ItemName;
    public int levelWithPlus;
    public int currentPlus = 0;
    /*public enum canUseCharacter
    {
        Warrior,Shaman,Sura,Ninja
    }*/
    public List<Character> canUseCharacters = new List<Character>();
    public RequirementClass[] Requirements =new RequirementClass[0];
    public Sprite Image;
    public int level;
    public int StackLimit()
    { return 1; }
    public string GetInfo()
    {
        return "weapon";
    }

    public string GetName()
    {
        return this.ItemName;
    }

    public ScriptableObject GetScriptableObject()
    {
        return this;
    }

    public Sprite GetSprite()
    {
        return this.Image;
    }

    public int GetWeightInInventory()
    {
        return weightInInventory;
    }
}
