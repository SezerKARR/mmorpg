using System;
using UnityEngine;

namespace Game.Components.EnvanterSistemiTest
{
    [Serializable]
    public struct ItemModel
    {
        [SerializeField] private ItemType _itemType;
        [SerializeField] private Sprite _itemImage;
        [SerializeField] private int _damage;

    }

    public enum ItemType
    {
        Sword,
        Shield
    }
}