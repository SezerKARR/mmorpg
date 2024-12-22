// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Pool;
//
// namespace Script.ObjectInTheGround
// {
//     public class DropObjectPooler
//     {
//         private Queue<ItemDrop> pool = new Queue<ItemDrop>();
//         private GameObject prefab;
//
//         public DropObjectPooler(DropPrefabList prefab)
//         {
//             this.prefab = prefab;
//             foreach (var objectClass in prefab)
//             {
//             
//                 Queue<GameObject> objectPool = new Queue<GameObject>() ;
//                 for (int i = 0; i < 30; i++)
//                 {
//                     GameObject objectGO = Object.Instantiate(objectClass.Prefab);
//                     objectGO.SetActive(false);
//                     objectPool.Enqueue(objectGO);
//                 }
//                 objectsToPool.Add(objectClass.ObjectType, objectPool);
//             }
//             for (int i = 0; i < initialSize; i++)
//             {
//                 CreateNewObject();
//             }
//         }
//
//         private void CreateNewObject()
//         {
//             GameObject obj = Object.Instantiate(prefab);
//             obj.SetActive(false);
//             pool.Enqueue(obj.GetComponent<ItemDrop>());
//         }
//
//         public ItemDrop GetObject(int count)
//         {
//             if (pool.Count == 0)
//             {
//                 CreateNewObject();
//             }
//
//             ItemDrop obj = pool.Dequeue();
//             obj.gameObject.SetActive(true);
//             obj.OnActivate(count);
//             return obj;
//         }
//
//         public void ReturnObject(ItemDrop obj)
//         {
//             obj.OnDeactivate();
//             obj.gameObject.SetActive(false);
//             pool.Enqueue(obj);
//         }
//     }
//     }
// }