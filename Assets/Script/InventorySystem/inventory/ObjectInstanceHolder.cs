using System;
using Script.Equipment;
using Script.ObjectInstances;
using UnityEngine;

namespace Script.InventorySystem.inventory
{
    public abstract class ObjectInstanceHolder:MonoBehaviour ,IInstanceHolder<ObjectInstance>
    {
        protected ObjectInstance _currentInstance;
        

        public virtual void AddObject(ObjectInstance objectToAdd, CellsInfo cellsInfo)
        {
            _currentInstance = objectToAdd;
            _currentInstance.currentHolder?.RemoveObject(_currentInstance);


            _currentInstance.cellsInfo = cellsInfo;
            _currentInstance.currentHolder = this;
        }

        public virtual void RemoveObject(ObjectInstance objectToRemove)
        {
            objectToRemove.currentHolder=null;
            _currentInstance=null;
            
        }
    }
}