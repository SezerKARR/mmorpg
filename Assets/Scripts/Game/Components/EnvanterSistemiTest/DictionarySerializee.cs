using System;
using Game.Extensions.Unity;
using UnityEngine;

namespace Game.Components.EnvanterSistemiTest
{
    public class DictionarySerializee : MonoBehaviour
    {


        [SerializeField] private WeaponDatas _weaponDatas;
        

        [Serializable]
        public class WeaponDatas : UnityDictionary<ItemType, Sprite> { }

    }
}