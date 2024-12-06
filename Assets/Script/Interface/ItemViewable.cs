using UnityEngine;

public interface ItemViewable
{
    public ScriptableItemsAbstact GetScriptableItemsAbstact();
    public Sprite GetSprite();
    public string GetName();
    public int GetWeightInInventory();
}
