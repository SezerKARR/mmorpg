using System.Collections.Generic;
using Script.ScriptableObject.Prefab;
using UnityEngine;

namespace Script.Inventory.Objects
{
    public class ObjectPooler
    {
        private readonly ıtem _objectsToPooled;
        private class ıtem: UnityDictionary<string, Queue<GameObject>> { };
        
        ItemPrefabList _itemPrefabList;
        private readonly Transform _parentTransform;
        public ObjectPooler(ItemPrefabList  itemPrefabList,Transform parentTransform,int count =5)
        {
            _itemPrefabList = itemPrefabList;
            this._parentTransform = parentTransform;
            _objectsToPooled = new ıtem();
            foreach (var objectClass in itemPrefabList.objects)
            {
                if(objectClass.Value.howMany!=-1) count=objectClass.Value.howMany;
                _objectsToPooled.Add(objectClass.Key,SpawnObject(objectClass.Key, count));
            }
            
        }

        public T SpawnFromPool<T>(string objectType) where T : Component
        {
            Debug.Log(_objectsToPooled[objectType].Count);
            if(_objectsToPooled[objectType].Count <= 1)_objectsToPooled[objectType].Enqueue(CreateObject(_itemPrefabList.objects[objectType].prefab.GetGameObject()));
            // Pool'dan bir nesne al
            GameObject objectToSpawn = _objectsToPooled[objectType].Dequeue();

            // GameObject'ten T tipinde bir bileşen al ve döndür
            return objectToSpawn.GetComponent<T>();
        }

        private Queue<GameObject> SpawnObject(string objectClass,int count=5)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>() ;
            for (int i = 0; i < count; i++)
            {
               
                objectPool.Enqueue(CreateObject(_itemPrefabList.objects[objectClass].prefab.GetGameObject()));
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
            Debug.Log(_objectsToPooled.ContainsKey(objectType));
            if (_objectsToPooled.ContainsKey(objectType))
            {
                obj.SetActive(false);
                _objectsToPooled[objectType].Enqueue(obj);
            }
        }
    }
    
}