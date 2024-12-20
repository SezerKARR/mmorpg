using System;
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
         
        [SerializeField] private EquipmentType _type;
        [SerializeField] private int2 _size = new int2(1,1);
        [SerializeField] private ItemController currentItem;
        [Inject] private InventoryManager inventoryManager;
       

        public bool SetItem(ItemController equipItem)
        {
            Debug.Log("SetItem");
            if (currentItem == equipItem)
            {
                if (inventoryManager.inventoryStorage.ControlUnequip(this.currentItem))
                {
                    UnEquip();
                    return true;
                }

                return false;
            }
            if (currentItem == null)
            {
                //OnEquip?.Invoke(item);
                EquipmentEvent.OnEquip?.Invoke(equipItem,1);
                Equip(equipItem);
                return true;
            }
            else
            {
                
                if (inventoryManager.inventoryStorage.ControlUnequipForEquip(this.currentItem,equipItem))
                {
                    //_inventoryManager.Equip(equipItem);
                    // OnEquipmentChanged?.Invoke(equipment.GetItemable(), item);
                    UnEquip();
                    Equip(equipItem);
                    return true;
                }
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