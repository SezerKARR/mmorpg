using System;
using Game.Extensions.Unity;
using Script.Equipment;
using Script.Inventory;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Script.ScriptableObject.Prefab
{
    [Serializable]
    public class objectClass{
    public ObjectType ObjectType;
    public GameObject Prefab;
    }

    [CreateAssetMenu(fileName = "ItemPrefabList", menuName = "ScriptableObjects/ItemPrefabList", order = 1)]
    public class ItemPrefabList : UnityEngine.ScriptableObject
    {
        public objectClass[]Objects;

        public GameObject GetPrefabByType(ObjectType type)
        {
            foreach (var obj in Objects)
            {
                if (obj.ObjectType == type)
                {
                    return obj.Prefab;
                }
            }
            return null;
        }

        
    }
}

