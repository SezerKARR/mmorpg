using System.Collections.Generic;
using Script.ScriptableObject.Prefab;
using UnityEngine;

namespace Script.Inventory.Objects
{
    public class ObjectPooler
    {
        public Item objectsToPool;
        public class Item: UnityDictionary<string, Queue<GameObject>> { };
        
        ItemPrefabList _itemPrefabList;
        private readonly Transform _parentTransform;
        public ObjectPooler(ItemPrefabList  itemPrefabList,Transform parentTransform,int count =5)
        {
            _itemPrefabList = itemPrefabList;
            this._parentTransform = parentTransform;
            objectsToPool = new Item();
            foreach (var objectClass in itemPrefabList.objects)
            {
                if(objectClass.Value.howMany!=-1) count=objectClass.Value.howMany;
                objectsToPool.Add(objectClass.Key,SpawnObject(objectClass.Key, count));
            }
            
        }

        public T SpawnFromPool<T>(string objectType) where T : Component
        {
            if(objectsToPool[objectType].Count <= 1)objectsToPool[objectType].Enqueue(CreateObject(_itemPrefabList.objects[objectType].prefab));
            // Pool'dan bir nesne al
            GameObject objectToSpawn = objectsToPool[objectType].Dequeue();

            // GameObject'ten T tipinde bir bileşen al ve döndür
            return objectToSpawn.GetComponent<T>();
        }

        public Queue<GameObject> SpawnObject(string objectClass,int count=5)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>() ;
            for (int i = 0; i < count; i++)
            {
               
                objectPool.Enqueue(CreateObject(_itemPrefabList.objects[objectClass].prefab));
            }
            return objectPool;
        }

        private GameObject CreateObject(GameObject objectToCreate)
        {
            GameObject objectGo = Object.Instantiate(objectToCreate, _parentTransform, true);
            objectGo.SetActive(false);
            return objectGo;
        }
        public void ReturnObject(string objectType, GameObject obj)
        {
            if (objectsToPool.ContainsKey(objectType))
            {
                obj.SetActive(false);
                objectsToPool[objectType].Enqueue(obj);
            }
        }
    }
    
}