using System;
using Script.Equipment;
using Script.Interface;
using Script.InventorySystem.inventory;
using Script.ScriptableObject;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.ObjectInstances
{
    [Serializable]
    public  class ObjectInstance
    {
        public IInstanceHolder<ObjectInstance> currentHolder;
        public int howMany;
        public ObjectAbstract objectAbstract;
        public CellsInfo cellsInfo;
        public IPool controllerPool;
        public Sprite ımage => objectAbstract.ımage;
        public int weightInInventory=> objectAbstract.weightInInventory;
        public ObjectType type => objectAbstract.Type;

        public virtual string DropName()
        {
            return null;
        }



    }
}