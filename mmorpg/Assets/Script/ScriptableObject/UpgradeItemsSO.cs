using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/UpgradeItem")]
public class UpgradeItemsSO : ScriptableObject,IWiewable
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
        return this.GetScriptableObject();
    }

    string IWiewable.GetInfo()
    {
        return info;
    }
}
