using Script.ScriptableObject;
using Script.ScriptableObject.Equipment;

namespace Script.Inventory.Objects
{
    [System.Serializable]
    public class ItemInstance
    {
        public ObjectAbstract objectSo; // Temel özellikleri tutan SO
        public int plusLevel; // "+" seviyesi

        
    }
}