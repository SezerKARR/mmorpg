using System;
using System.Linq;
using Script.Interface;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Script.ScriptableObject.Prefab
{
    [Serializable]
    public class ObjectClass<T>
    {
        public T prefab; // Generic olarak Component türü
        public int howMany = -1;
    }

    [CreateAssetMenu(fileName = "ItemPrefabList", menuName = "ScriptableObjects/ItemPrefabList", order = 1)]
    public class ItemPrefabList : UnityEngine.ScriptableObject
    {
        [SerializeField]
        public Obje objects=new Obje();
        [Serializable]
        public class Obje: UnityDictionary<string, ObjectClass<IPool>> { };
        
        [SerializeField] public GameObject[] prefabs;
        public IPool GetPrefabByType(string type)
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
                IPool ıPool = prefab.GetComponent<IPool>();
                if (!objects.Keys.Contains(ıPool.GetPoolType()))
                {
                    
                    objects.Add(ıPool.GetPoolType(),new ObjectClass<IPool>{ prefab=ıPool});
                }
                index++;
            }
        }
    }
}

