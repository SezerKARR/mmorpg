using System.Collections.Generic;
using Script.Interface;
using Script.ScriptableObject.Prefab;
using UnityEngine;

namespace Script.InventorySystem.Objects
{
    public class ObjectPooler
    {
        private readonly ıtem _objectsToPooled;
        private class ıtem: UnityDictionary<string, Queue<GameObject>> { };

        private readonly ItemPrefabList _itemPrefabList;
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

        public T SpawnFromPool<T>(string objectType,Transform parentTransform=null) where T : Component
        {
            foreach (var key in _objectsToPooled.Keys)
            {
                Debug.Log(key);
            }
            Debug.Log(_objectsToPooled[objectType].Count);
            if(_objectsToPooled[objectType].Count <= 1)_objectsToPooled[objectType].Enqueue(CreateObject(_itemPrefabList.objects[objectType].prefab));
            GameObject objectToSpawn = _objectsToPooled[objectType].Dequeue();
            if(parentTransform!=null)objectToSpawn.transform.SetParent(parentTransform);
            return objectToSpawn.GetComponent<T>();
        }
       
        private Queue<GameObject> SpawnObject(string objectClass,int count=5)
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
        public void ReturnObject(IPool pool)
        {
            string objectType = pool.GetPoolType();
            GameObject obj = pool.GetGameObject();
            if (_objectsToPooled.TryGetValue(objectType, out var value))
            {
                obj.SetActive(false);
                obj.transform.SetParent(_parentTransform);
                value.Enqueue(obj);
            }
        }
    }
    
}