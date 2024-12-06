
using UnityEngine;

public interface IInventorObjectAble
{
    public ScriptableObject GetScriptableObject();
    public int GetWeightInInventory();
    public int GetStackLimit();
    public Sprite GetSprite();
}
