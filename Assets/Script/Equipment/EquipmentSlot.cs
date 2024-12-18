using System.Collections.Generic;
using Script.Inventory;
using Script.Inventory.Objects;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Script.Equipment
{
    public  class EquipmentSlot : MonoBehaviour
    {
        [Inject][SerializeField] private InventoryStorage _inventoryStorage;
        [SerializeField] private EquipmentType _type;
        [SerializeField] private int2 _size = new int2(1,1);
        [SerializeField] private ItemController currentItem;
     
        public bool SetItem(ItemController equipItem)
        {
            Debug.Log("SetItem");
            if (currentItem == equipItem)
            {
                UnEquip();
            }
            if (currentItem == null)
            {
                //OnEquip?.Invoke(item);
                _inventoryStorage.Equip(equipItem);
                Equip(equipItem);
                return true;
            }
            

            
            else if (_inventoryStorage.ControlUnequip(this.currentItem,equipItem))
            {
                //_inventoryManager.Equip(equipItem);
               // OnEquipmentChanged?.Invoke(equipment.GetItemable(), item);
                UnEquip();
                Equip(equipItem);
                return true;
            }
            return false;
            /*if(_itemController != null)
            {
                //_inventoryManager.AddItem(_itemController);
            }
         
            _itemController = itemController;
            _itemController.Place(transform, transform.position);
            return false;*/
        }
        public void Equip(ItemController equipItem)
        {

            equipItem.Place(this.transform,gameObject.GetComponent<RectTransform>().rect.size);
            //EquipmentManager.Instance.a(equipItem, equipItem);
            this.currentItem = equipItem;
            this.currentItem.SetNewStats();

        }
        public void UnEquip()
        {
        
            this.currentItem.SetOldStats();
            this.currentItem = null;
        }
        public EquipmentType GetEquipmentType()
        {
            return _type;
        }
    }
}