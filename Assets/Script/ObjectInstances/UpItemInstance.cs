using System;
using Script.InventorySystem;
using Script.InventorySystem.inventory;
using Script.ScriptableObject;
using Script.ScriptableObject.UpObject;
using Script.UI;
using UnityEngine;

namespace Script.ObjectInstances
{
    [Serializable]
    public class UpItemInstance:ObjectInstance
    {
        public UpItem upItem;

        public UpItemInstance(ObjectAbstract objectAbstract) : base(objectAbstract)
        {
           this.upItem = (UpItem)objectAbstract;
        }

        public float GetChangeUp()
        {
        
            return upItem.changeForUp;
        }
        public int GetPlus(bool upResult)=>upResult ? upItem.upResultTrue : upItem.upResultFalse;

        public string GetPlusDescription()
        {
            if (Mathf.Approximately(GetChangeUp(), 100f))
            {
                return "Do you want to upgrade this item?";
            }

            if (upItem.upResultFalse == -99)
            {
                return "The item may disappear. Are you sure you want to upgrade this item?";
            }        
            return "The item's level may decrease. Are you sure you want to upgrade this item?";
        }
        public override void LeftClick(ObjectInstance objectInstance)
        {
            if (objectInstance is ItemInstance item)
            {

                InventoryEvent.OnDeselect?.Invoke();
                UIEvent.OnUpgradePanel?.Invoke(item,this);
            }
            
        }
    }
}