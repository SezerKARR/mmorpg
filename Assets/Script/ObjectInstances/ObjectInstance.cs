using System;
using Script.Interface;
using Script.InventorySystem.inventory;
using Script.ScriptableObject;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Script.ObjectInstances
{
    [Serializable]
    public class ObjectInstance
    {
        public int howMany;
        public ObjectAbstract objectAbstract;
        public CellsInfo cellsInfo;
        public IPool controllerPool;
        public Sprite ımage => objectAbstract.ımage;
        public int weightInInventory=> objectAbstract.weightInInventory;
        public string type => objectAbstract.Type.ToString();


    }
}