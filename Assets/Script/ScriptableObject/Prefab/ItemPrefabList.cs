using System;
using Game.Extensions.Unity;
using Script.Equipment;
using Script.Inventory;
using UnityEngine;

namespace Script.ScriptableObject.Prefab
{
    [CreateAssetMenu(fileName = "ItemPrefabList", menuName = "ScriptableObjects/ItemPrefabList", order = 1)]
    public class ItemPrefabList : UnityEngine.ScriptableObject
    {
        [SerializeField] private PrefabControllers prefabControllers;

        [Serializable]
        public class PrefabControllers : UnityDictionary<TypeController, GameObject> { }

        private void OnValidate()
        {
          
            if (prefabControllers != null)
            {
                prefabControllers.Add(TypeController.none,null); // Senkronize et
            }
        }
        public PrefabControllers GetPrefabControllers() => prefabControllers;
     
    }
}

