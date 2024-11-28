
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour, IWiewable
{
    public ScriptableItemsAbstact ScriptableObject;
    public string GetInfo()
    {
        throw new System.NotImplementedException();
    }

    public string GetName()
    {
        return ScriptableObject.name;
        throw new System.NotImplementedException();
    }

    public ScriptableObject GetScriptableObject()
    {
        return ScriptableObject;
    }

    public Sprite GetSprite()
    {
        throw new System.NotImplementedException();
    }

   
}
