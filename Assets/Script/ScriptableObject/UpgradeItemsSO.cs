using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/UpgradeItem")]
public class UpgradeItemsSO : ScriptableObject,IDropable
{
    public Sprite Image;
    public string upgradeName;
    public string dropsFrom;
    public string info;
    public bool playerCanDrop = true;
    public bool canEveryBodyTake=true;
    public string GetName()
    {
        return upgradeName;
    }

    public Sprite GetSprite()
    {
        return Image; 
    }

    public ScriptableObject GetScriptableObject()
    {
        return this;
    }

    public int GetWeightInInventory()
    {
        return 1;
    }

    public int GetStackLimit()
    {
        return 200;
    }

    public string GetDropName()
    {
        
        
            return upgradeName;
        
    }

    public bool GetPlayerCanDrop()
    {
        return playerCanDrop;
    }

    public bool GetCanEveryBodyTake()
    {
        return canEveryBodyTake;
    }
}
