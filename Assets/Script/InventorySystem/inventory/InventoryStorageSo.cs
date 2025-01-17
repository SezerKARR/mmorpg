using System;
using System.Collections.Generic;
using System.Linq;
using Script.Inventory;
using Script.InventorySystem.Page;
using Script.ObjectInstances;
using Script.ScriptableObject;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Script.InventorySystem.inventory
{
    [Serializable]
    public class ObjectClass<T>  :IVariable where T : ObjectInstance
    {
        public List<T> objects = new List<T>();
        
        public void Add(ObjectInstance variable)
        {
            if (variable is T castedItem)
            {
                objects.Add(castedItem);
            }
        }

        public void Remove(ObjectInstance variable)
        {
            if (variable is T castedItem)
            {
                objects.Remove(castedItem);
            }
        }

        public List<ObjectInstance> GetVariables()
        {
            return new List<ObjectInstance>(objects);
        }
    }

    public interface IVariable
    {
        void Add(ObjectInstance variable);
        void Remove(ObjectInstance variable);
       List<ObjectInstance> GetVariables();
    }

  
    [CreateAssetMenu( menuName = "ScriptableObject/InventoryStorage")]
    public class InventoryStorageSo: UnityEngine.ScriptableObject
    {
        public int rowCount,columnCount;
        public List<PageModel> pageModels=new List<PageModel>();
        [SerializeField]public List<ObjectInstance> objectInstances = new List<ObjectInstance>();
        [SerializeField]public  ObjectClass<ItemInstance> itemInstances = new ObjectClass<ItemInstance>();
        [SerializeField]public  ObjectClass<StackInstance> stackInstances = new ObjectClass<StackInstance>();
        [SerializeField]public  ObjectClass<UpItemInstance> upItemInstances = new ObjectClass<UpItemInstance>();
        [Serializable]
        public class ObjectsDictionary : UnityDictionary<ObjectType, IVariable > { };
        [SerializeField]
        public ObjectsDictionary objects = new ObjectsDictionary(){ };
        public void Initialize()
        {
            objects= new ObjectsDictionary(){
                { ObjectType.Item, itemInstances},
                { ObjectType.Stack,stackInstances },
                { ObjectType.UpItem ,upItemInstances}
            };
            foreach (var pageModel in pageModels)  
            {
                pageModel.Initialize(rowCount: rowCount, columnCount: columnCount);
            }
            
        }
       
       
        public void AddItem( ObjectInstance objectInstance)
        {
            objects[objectInstance.type].Add(objectInstance);
        }
        public void RemoveItem(ObjectInstance removeObject)
        {
            objects[removeObject.type].Remove(removeObject);
        }
        // public void AddObjectType(ObjectType type, IEnumerable<ObjectInstance> instances)
        // {
        //     Type objectType = objects.GetObjectType(type);
        //
        //     if (objectType != null)
        //     {
        //         foreach (var instance in instances)
        //         {
        //             if (instance.GetType() == objectType)
        //             {
        //                 // Burada her bir instance'ı uygun yere ekliyoruz
        //                 Debug.Log($"Adding {instance.GetType().Name} to {type}");
        //             }
        //         }
        //     }
        // }
        
    }
}