using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Components.EnvanterSistemiTest
{
    public class InventoryManager : MonoBehaviour
    {
        private bool[,] _inventorySlots;
        private Dictionary<int2, ItemController>[] _pages;

        private void OnEnable()
        {
            ItemEvents.OnItemClicked += OnItemClicked;
        }

        private void OnItemClicked(ItemController arg)
        {
            AddItem(arg);
        }
        
        private void OnDisable()
        {
            ItemEvents.OnItemClicked -= OnItemClicked;
        }

        public bool AddItem(ItemController itemController)
        {
            int2 cellIndex = new int2(5,5); //Item size a gore check edip uygun yer varsa onun cellindexini set et.
            itemController.Place(transform, cellIndex);
            Debug.Log("AddItem");
            return true;
        }
    }
}