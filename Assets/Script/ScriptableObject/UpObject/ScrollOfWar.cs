using UnityEngine;

namespace Script.ScriptableObject.UpObject
{
    public class ScrollOfWar : ObjectAbstract, IUpgradeItem
    {

        public int upResultTrue;
        public int upResultFalse;
        public float changeForUp;
        public int currentPlus;
        public float GetChangeUp()
        {
            if (currentPlus <= 3) return 100f;
            return changeForUp;
        }
        public override ObjectType Type => ObjectType.LeftClickStack; 


        public int GetPlus(bool upResult) => upResult ? upResultTrue : upResultFalse;
        public string GetPlusDescription()
        {
            if (Mathf.Approximately(GetChangeUp(), 100f))
            {
                return "Do you want to upgrade this item?";
            }
            
            return "Are you sure you want to upgrade this item? The item's level may decrease.";
            
        }


        // public override ObjectType GetTypeController()
        // {
        //     return ObjectType.Up;
        // }
    }
}
