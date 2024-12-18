using System.Collections.Generic;
using Script.ScriptableObject.Prefab;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.Inventory.Objects
{
    public class ObjectPooler
    {
        public Item objectsToPool;
        public class Item: UnityDictionary<ObjectType, Queue<GameObject>> { };

        public ObjectPooler(ItemPrefabList  itemPrefabList)
        {
            objectsToPool = new Item();
            foreach (var objectClass in itemPrefabList.Objects)
            {
            
                Queue<GameObject> objectPool = new Queue<GameObject>() ;
                for (int i = 0; i < 30; i++)
                {
                    GameObject objectGO = Object.Instantiate(objectClass.Prefab);
                    objectGO.SetActive(false);
                    objectPool.Enqueue(objectGO);
                }
                objectsToPool.Add(objectClass.ObjectType, objectPool);
            }
            
        }

        public ObjectController SpawnFromPool(ObjectType objectType)
        {
            GameObject objectToSpawn=objectsToPool[objectType].Dequeue();
            objectToSpawn.SetActive(true);
            return objectToSpawn.GetComponent<ObjectController>();
        }
    }
    
}