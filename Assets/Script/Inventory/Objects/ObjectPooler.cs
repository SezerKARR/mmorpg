using System.Collections.Generic;
using Script.ScriptableObject.Prefab;
using UnityEngine;

namespace Script.Inventory.Objects
{
    public class ObjectPooler
    {
        public Item objectsToPool;
        public class Item: UnityDictionary<string, Queue<GameObject>> { };

        public ObjectPooler(ItemPrefabList  itemPrefabList,Transform parentTransform,int count =5)
        {
            objectsToPool = new Item();
            foreach (var objectClass in itemPrefabList.objects)
            {
                if(objectClass.howMany!=-1) count=objectClass.howMany;
                Queue<GameObject> objectPool = new Queue<GameObject>() ;
                for (int i = 0; i < count; i++)
                {
                    GameObject objectGo = Object.Instantiate(objectClass.prefab, parentTransform, true);
                    objectGo.SetActive(false);
                    objectPool.Enqueue(objectGo);
                }
                objectsToPool.Add(objectClass.objectType, objectPool);
            }
            
        }

        public T SpawnFromPool<T>(string objectType) where T : Component
        {
            // Pool'dan bir nesne al
            GameObject objectToSpawn = objectsToPool[objectType].Dequeue();

            // GameObject'ten T tipinde bir bileşen al ve döndür
            return objectToSpawn.GetComponent<T>();
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