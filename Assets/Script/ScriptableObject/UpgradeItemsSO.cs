using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/UpgradeItem")]
public class UpgradeItemsSO : ScriptableObject,IViewable
{
    public Sprite Image;
    public string upgradeName;
    public string dropsFrom;
    public string info;

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

    string IViewable.GetInfo()
    {
        return info;
    }
    public int StackLimit()
    { 
        return 200; 
    }

    public int GetWeightInInventory()
    {
        return 1;
    }
}
