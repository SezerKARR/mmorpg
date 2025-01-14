using System;
using Script.Interface;
using Script.InventorySystem.inventory;
using Script.ScriptableObject;
using UnityEngine;

namespace Script.ObjectInstances
{
    [Serializable]
    public class ObjectInstance:IObject
    {
        
        public int howMany;
        public ObjectAbstract objectAbstract;
        public CellsInfo cellsInfo;
        public IPool controllerPool;
        public Sprite ımage => objectAbstract.ımage;
        public int weightInInventory=> objectAbstract.weightInInventory;
        public ObjectType type => objectAbstract.Type;

       

    }
}