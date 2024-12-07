
using UnityEngine;

public interface IInventorObjectable
{
    public ScriptableObject GetScriptableObject();
    public int GetWeightInInventory();
    public int GetStackLimit();
    public Sprite GetSprite();
}
