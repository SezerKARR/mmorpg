using Unity.Mathematics;
using UnityEngine;

namespace Game.Components.EnvanterSistemiTest
{
    public abstract class EquipmentSlot : MonoBehaviour
    {
        [SerializeField] private InventoryManager _inventoryManager;
        [SerializeField] private ItemType _type;
        [SerializeField] private int2 _size = new int2(1,1);
        [SerializeField] private ItemController _itemController;
        
        public void SetItem(ItemController itemController)
        {
            if(_itemController != null)
            {
                _inventoryManager.AddItem(_itemController);
            }
            
            _itemController = itemController;
            _itemController.Place(transform, transform.position);
        }
    }
}