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
            try
            {
                _currentInstance.currentHolder.RemoveObject(_currentInstance);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            _currentInstance.cellsInfo = cellsInfo;
            _currentInstance.currentHolder = this;
        }

        public virtual void RemoveObject(ObjectInstance objectToRemove)
        {
            _currentInstance=null;
        }
    }
}