using System.Collections.Generic;
using UnityEngine;

namespace Game.Components.EnvanterSistemiTest
{
    public class EquipmentManager : MonoBehaviour
    {
        private Dictionary<ItemType, EquipmentSlot> _equipmentSlots;
        
        private void OnEnable()
        {
            ItemEvents.OnItemClicked += OnItemClicked;
        }

        private void OnItemClicked(ItemController obj)
        {
            _equipmentSlots[obj.ItemType].SetItem(obj);
        }
        
        private void OnDisable()
        {
            ItemEvents.OnItemClicked -= OnItemClicked;
        }
    }
}