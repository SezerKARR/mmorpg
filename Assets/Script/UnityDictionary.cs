using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Extensions.Unity
{
    [Serializable]
    public abstract class UnityDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        public List<TKey> tKeys = new();
        public List<TValue> tValues = new();

        
        

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            tKeys = Keys.ToList();
            tValues = Values.ToList();
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            Clear();

            if (tKeys != null && tValues != null && tKeys.Count == tValues.Count)
            {
                for (int i = 0; i < tKeys.Count; i++)
                {
                    Add(tKeys[i], tValues[i]);
                }
            }
            else
            {
                Debug.LogError("Keys and Values lists are not synchronized.");
            }
        }
    }
}