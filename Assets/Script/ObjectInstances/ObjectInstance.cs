using System;
using Script.InventorySystem.inventory;
using Script.ScriptableObject;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.ObjectInstances
{
    [Serializable]
    public class ObjectInstance
    {
        public int howMany;
        public ObjectAbstract objectAbstract;
        public CellsInfo cellsInfo;
        
        public Sprite ımage => objectAbstract.ımage;
        public int weightInInventory=> objectAbstract.weightInInventory;
        public string type => objectAbstract.Type.ToString();
        [FormerlySerializedAs("parent")] public Transform parentTransform;


    }
}