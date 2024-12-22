using System;
using Script.Interface;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.ScriptableObject.Prefab
{
    [Serializable]
    public class ObjectClass{
        
        [FormerlySerializedAs("ObjectType")] public string objectType;
        [FormerlySerializedAs("Prefab")] public GameObject prefab;
    }

    [CreateAssetMenu(fileName = "ItemPrefabList", menuName = "ScriptableObjects/ItemPrefabList", order = 1)]
    public class ItemPrefabList : UnityEngine.ScriptableObject
    {
        [FormerlySerializedAs("Objects")] public ObjectClass[]objects;
        
        public GameObject GetPrefabByType(string type)
        {
            foreach (var obj in objects)
            {
                if (obj.objectType == type)
                {
                    return obj.prefab;
                }
            }
            return null;
        }

        private void OnValidate()
        {
            foreach (var objecta in objects)
            {
                IPoolable poolable = objecta.prefab.GetComponent<IPoolable>();
                objecta.objectType=poolable.GetPoolType();
            }
        }
    }
}

