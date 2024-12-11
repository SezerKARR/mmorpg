using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Extensions.Unity
{
    [Serializable]
    public abstract class UnityDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField] public List<TKey> _tKeys = new();
        [SerializeField] public List<TValue> _tValues = new();

        
        

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            _tKeys = Keys.ToList();
            _tValues = Values.ToList();
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            Clear();

            if (_tKeys != null && _tValues != null && _tKeys.Count == _tValues.Count)
            {
                for (int i = 0; i < _tKeys.Count; i++)
                {
                    Add(_tKeys[i], _tValues[i]);
                }
            }
            else
            {
                Debug.LogError("Keys and Values lists are not synchronized.");
            }
        }
    }
}