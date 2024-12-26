using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using IPoolable = Script.Interface.IPoolable;

namespace Script.ScriptableObject.Prefab
{
    [Serializable]
    public class ObjectClass{
        
        [FormerlySerializedAs("ObjectType")] public string objectType;
        [FormerlySerializedAs("Prefab")] public GameObject prefab;
        public int howMany=-1;
    }

    [CreateAssetMenu(fileName = "ItemPrefabList", menuName = "ScriptableObjects/ItemPrefabList", order = 1)]
    public class ItemPrefabList : UnityEngine.ScriptableObject
    {
        [FormerlySerializedAs("Objects")] public ObjectClass[] objects;
        [SerializeField] GameObject[] prefabs;
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
            int index = 0;
            objects=new ObjectClass[prefabs.Length];
            foreach (var prefab in prefabs)
            {
                IPoolable poolable = prefab.GetComponent<IPoolable>();
                objects[index] = new ObjectClass{objectType=poolable.GetPoolType(), prefab=prefab};
                index++;
            }
        }
    }
}

