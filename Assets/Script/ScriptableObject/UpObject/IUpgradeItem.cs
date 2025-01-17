
namespace Script.ScriptableObject.UpObject
{
    public interface IUpgradeItem 
    {
        public float GetChangeUp();
        public int GetPlus(bool upResult);
        public string GetPlusDescription();
        
    }
}
