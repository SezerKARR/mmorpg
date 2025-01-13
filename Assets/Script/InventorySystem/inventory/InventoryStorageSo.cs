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
        [SerializeField]public List<ObjectInstance> objectInstances = new List<ObjectInstance>();
        [SerializeField]public  List<ItemInstance> itemInstances = new List<ItemInstance>();
        [SerializeField]public  List<StackInstance> stackInstances = new List<StackInstance>();

        [Serializable]
        public class ObjectsDictionary : UnityDictionary<ObjectType, List<ObjectInstance>> { };

        public ObjectsDictionary objects = new ObjectsDictionary();
        public void İnitialize()
        {
            objects= new ObjectsDictionary(){
            { ObjectType.Item, new List<ObjectInstance>(itemInstances) },
            { ObjectType.Stack, new List<ObjectInstance>(stackInstances) }
            };
        }
        
    }
}