using System;
using System.Collections.Generic;
using Script.ScriptableObject;

namespace Script.ObjectInstances
{
    public static class ObjectInstanceCreator
    {
        public static Dictionary<ObjectType, Func<ObjectAbstract, ObjectInstance>> ObjectFactories = new()
        {
            { ObjectType.Item, obj => new ItemInstance(obj) },
            { ObjectType.Stack, obj => new StackInstance(obj) },
            { ObjectType.UpItem ,obj=>new UpItemInstance(obj)}
        };
        public static ObjectInstance GetObjectInstance(ObjectAbstract objectAbstract) =>
            ObjectFactories.TryGetValue(objectAbstract.Type, out var createInstance) 
                ? createInstance(objectAbstract) 
                : null;
        public static ObjectInstance ObjectInstance(ObjectInstance objectAbstract)
        {
            if (objectAbstract is ItemInstance scriptableItemsAbstact)
            {
               
                return scriptableItemsAbstact;
            }
            
            return objectAbstract;
        }
        
    }
}