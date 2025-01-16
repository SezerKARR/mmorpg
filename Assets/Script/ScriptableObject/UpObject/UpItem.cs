using Script.InventorySystem;
using Script.ObjectInstances;
using Script.UI;
using UnityEngine;

namespace Script.ScriptableObject.UpObject
{
    [CreateAssetMenu(menuName ="ScriptableObject/UpItem")]
    public class UpItem : ObjectAbstract,IUpgradeItem
    {
        public int upResultTrue;
        public int upResultFalse;
        public float changeForUp;
        public override ObjectType Type => ObjectType.Stack;
        public float GetChangeUp()
        {
        
            return changeForUp;
        }
      

        public override void LeftClick(ObjectInstance objectInstance)
        {
            if (objectInstance is ItemInstance item)
            {
                ImageUnderCursor.OnCloseImageUnderCursor?.Invoke();
                UIEvent.OnUpgradePanel?.Invoke(item);
            }
            return;
            
        }


        public int GetPlus(bool upResult)=>upResult ? upResultTrue : upResultFalse;
        

        // public override ObjectType GetTypeController()
        // {
        //     return ObjectType.Up;
        // }

    
    }
}
