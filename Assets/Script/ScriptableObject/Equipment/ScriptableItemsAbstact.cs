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

public abstract  class ScriptableItemsAbstact : ScriptableObject,ItemViewable,IInventorObjectAble,
{
    public float price;
    public int weightInInventory=1;
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
   

    public string GetName()
    {
        return this.ItemName;
    }

    public ScriptableItemsAbstact GetScriptableItemsAbstact()
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

    public ScriptableObject GetScriptableObject()
    {
        throw new NotImplementedException();
    }


    public int GetStackLimit()
    { return 1; }
}
