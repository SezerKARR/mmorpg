using UnityEngine;

public interface IWiewable
{
    public string GetInfo();
    public ScriptableObject GetScriptableObject();
    public Sprite GetSprite();
    public string GetName();
    public int StackLimit();
    public int GetWeightInInventory();
}
