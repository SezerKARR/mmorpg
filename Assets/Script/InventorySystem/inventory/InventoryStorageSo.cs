using System;
using System.Collections.Generic;
using Script.Inventory;
using Script.InventorySystem.Page;
using Script.ObjectInstances;
using Script.ScriptableObject;
using UnityEngine;

namespace Script.InventorySystem.inventory
{
    [CreateAssetMenu( menuName = "ScriptableObject/InventoryStorage")]
    public class InventoryStorageSo: UnityEngine.ScriptableObject
    {
        public int rowCount,columnCount;
        public List<PageModel> pageModels=new List<PageModel>();
        public HaveObjects haveObjects=new HaveObjects();
        [Serializable]
        public class HaveObjects : UnityDictionary<ObjectAbstract, int> { };
        [SerializeField]public List<ObjectInstance> objectInstances = new List<ObjectInstance>();
    }
}