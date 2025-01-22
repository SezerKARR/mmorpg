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
        public ObjectInstance(ObjectAbstract objectAbstract)
        {
            this.objectAbstract = objectAbstract;
        }
        public IInstanceHolder<ObjectInstance> currentHolder;
        public int howMany;
        public ObjectAbstract objectAbstract;
        public CellsInfo cellsInfo;
        public IPool controllerPool;
        public Sprite image => objectAbstract.image;
        public int weightInInventory=> objectAbstract.weightInInventory;
        public ObjectType type => objectAbstract.Type;

        public void DecreaseHowMany(int amount = 1)
        {
            howMany -= amount;
            if(howMany <= 0) currentHolder.RemoveObject(this);
        }
        public virtual string ObjectName()
        {
            return objectAbstract.itemName;}

        public virtual string Description(){return null;}

        public virtual string DropName()
        {
            return objectAbstract.itemName + " x " + howMany;
        }

        public virtual void LeftClick(ObjectInstance objectInstance){}
       



    }
}