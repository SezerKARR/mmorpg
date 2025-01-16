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
        public Sprite image => objectAbstract.image;
        public int weightInInventory=> objectAbstract.weightInInventory;
        public ObjectType type => objectAbstract.Type;

        public virtual string ObjectName()
        {
            return objectAbstract.itemName;}

        public virtual string Description(){return null;}

        public virtual string DropName()
        {
            return objectAbstract.itemName + " x " + howMany;
        }




    }
}