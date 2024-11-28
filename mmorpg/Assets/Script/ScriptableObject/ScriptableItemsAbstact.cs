using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

public  class ScriptableItemsAbstact : ScriptableObject
{
    public int levelWithPlus;
    /*public enum canUseCharacter
    {
        Warrior,Shaman,Sura,Ninja
    }*/
    public List<Character> canUseCharacters = new List<Character>();
    public RequirementClass[] Requirements =new RequirementClass[0];
    public Sprite Image;
    public int level;
}
