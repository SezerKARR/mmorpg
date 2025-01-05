using UnityEngine;

namespace Script.Interface
{
    public interface IPool
    {
        public string GetPoolType();
        public GameObject GetGameObject();
    }
}