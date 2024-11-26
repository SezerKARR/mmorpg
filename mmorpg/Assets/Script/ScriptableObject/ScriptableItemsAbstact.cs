using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ScriptableItemsAbstact : ScriptableObject
{

    /*public enum canUseCharacter
    {
        Warrior,Shaman,Sura,Ninja
    }*/
    public List<(ScriptableObject upgradeItem, int howMany, float upgradeMoney,int level)> Requirement = new List<(ScriptableObject upgradeItem, int howMany, float upgradeMoney, int level)>();

    public Sprite Image;
    public int level;
}
