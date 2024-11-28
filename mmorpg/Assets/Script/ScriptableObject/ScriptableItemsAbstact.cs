using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
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

public  class ScriptableItemsAbstact : ScriptableObject
{
    public int levelWithPlus;
    /*public enum canUseCharacter
    {
        Warrior,Shaman,Sura,Ninja
    }*/

    public RequirementClass[] Requirements =new RequirementClass[0];

    public void AddObject(UpgradeItem upgradeItem,int swordPlus)
    {
        
        Array.Resize(ref Requirements[swordPlus].upgradeItems, Requirements[swordPlus].upgradeItems.Length + 1);
        Requirements[swordPlus].upgradeItems[Requirements[swordPlus].upgradeItems.Length - 1] = upgradeItem;
        Debug.Log(Requirements[swordPlus].upgradeItems[Requirements[swordPlus].upgradeItems.Length - 1].upgradeItemName);
    }
    public void AddObject(float money)
    {
        Array.Resize(ref Requirements, Requirements.Length + 1);
        RequirementClass requirementClass = new RequirementClass();
        requirementClass.upgradeMoney = money;
        Requirements[Requirements.Length - 1] = requirementClass;
    }
    
    


    public Sprite Image;
    public int level;
}
