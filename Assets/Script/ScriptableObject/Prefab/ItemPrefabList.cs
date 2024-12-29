using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using IPoolable = Script.Interface.IPoolable;

namespace Script.ScriptableObject.Prefab
{
    [Serializable]
    public class ObjectClass{
        
        
        [FormerlySerializedAs("Prefab")] public GameObject prefab;
        public int howMany=-1;
    }

    [CreateAssetMenu(fileName = "ItemPrefabList", menuName = "ScriptableObjects/ItemPrefabList", order = 1)]
    public class ItemPrefabList : UnityEngine.ScriptableObject
    {
        [SerializeField]
        public Obje objects=new Obje();
        [Serializable]
        public class Obje: UnityDictionary<string, ObjectClass> { };
        
        [SerializeField] GameObject[] prefabs;
        public GameObject GetPrefabByType(string type)
        {
            foreach (var obj in objects)
            {
                if (obj.Key == type)
                {
                    return obj.Value.prefab;
                }
            }
            return null;
        }

        private void OnValidate()
        {
            int index = 0;
             objects = new Obje();
            foreach (var prefab in prefabs)
            {
                IPoolable poolable = prefab.GetComponent<IPoolable>();
                if (!objects.Keys.Contains(poolable.GetPoolType()))
                {
                    
                    objects.Add(poolable.GetPoolType(),new ObjectClass{ prefab=prefab});
                }
                index++;
            }
        }
    }
}

