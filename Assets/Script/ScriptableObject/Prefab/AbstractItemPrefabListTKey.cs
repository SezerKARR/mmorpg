using System.Collections.Generic;
using UnityEngine;

// Abstract ScriptableObject
namespace Script.ScriptableObject
{
    public abstract class AbstractItemPrefabList<TKey> : UnityEngine.ScriptableObject
    {
        // Türetilen sınıflarda hangi türün kullanılacağına karar verilecek
        private Dictionary<TKey, GameObject> itemPrefabs = new Dictionary<TKey, GameObject>();

        // Prefab eklemek için bir metot (anahtar türü TKey)
        public void AddPrefab(TKey key, GameObject prefab)
        {
            if (!itemPrefabs.ContainsKey(key))
            {
                itemPrefabs.Add(key, prefab);
                Debug.Log($"Prefab for {key} added.");
            }
            else
            {
                Debug.LogWarning($"Prefab for {key} already exists!");
            }
        }

        // Prefab almak için bir metot (anahtar türü TKey)
        public GameObject GetPrefab(TKey key)
        {
            if (itemPrefabs.TryGetValue(key, out var prefab))
            {
                return prefab;
            }
            else
            {
                Debug.LogError($"Prefab for key {key} not found!");
                return null;
            }
        }

        // Prefab silmek için bir metot (anahtar türü TKey)
        public void RemovePrefab(TKey key)
        {
            if (itemPrefabs.ContainsKey(key))
            {
                itemPrefabs.Remove(key);
                Debug.Log($"Prefab for {key} removed.");
            }
            else
            {
                Debug.LogWarning($"Prefab for {key} does not exist!");
            }
        }

        // Tüm prefablari temizlemek için bir metot
        public void ClearAllPrefabs()
        {
            itemPrefabs.Clear();
            Debug.Log("All prefabs cleared.");
        }
    }
}
