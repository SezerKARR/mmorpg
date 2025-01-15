using System;
using Script.Equipment;
using Script.ObjectInstances;
using UnityEngine;

namespace Script.InventorySystem.inventory
{
    public abstract class ObjectInstanceHolder:MonoBehaviour ,IInstanceHolder<ObjectInstance>
    {
        

        public virtual void AddObject(ObjectInstance objectToAdd, CellsInfo cellsInfo)
        {
            objectToAdd.currentHolder?.RemoveObject(objectToAdd);


            objectToAdd.cellsInfo = cellsInfo;
            objectToAdd.currentHolder = this;
        }

        public virtual void RemoveObject(ObjectInstance objectToRemove)
        {
            objectToRemove.currentHolder=null;
            
        }
    }
}