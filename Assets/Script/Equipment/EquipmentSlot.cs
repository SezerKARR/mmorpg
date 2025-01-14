using System;
using Script.InventorySystem.inventory;
using Script.InventorySystem.Objects;
using Script.ObjectInstances;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Script.Equipment
{
    public class EquipmentSlot : MonoBehaviour
    {
        [FormerlySerializedAs("_type")] [SerializeField]
        private EquipmentType type;
        [SerializeField]private ItemController currentItemController;
        [Inject] private InventoryManager _inventoryManager;
        private ItemInstance _oldItemInstance;
        private ItemInstance currentItemInstance
        {
            get => currentItemController.itemInstance;
            set => currentItemController.itemInstance = value;
        }

        private void Awake()
        {
            currentItemController.itemInstance = null;
        }

        public EquipmentType GetEquipmentType() => type;
        public void SetItem(ItemInstance equipItem)
        {
            Debug.Log("SetItem");
            if (currentItemInstance == null||currentItemInstance.scriptableItemsAbstract==null)
            {
                //OnEquip?.Invoke(item);
                Equip(equipItem);
                return;
            }
            
         
            if (currentItemInstance == equipItem)
            {
                
                if (EquipmentEvent.OnUnequipItem?.Invoke(equipItem)==true)
                {
                    UnEquip();
                }
                return;
            }
            
            _oldItemInstance = currentItemInstance;
            if (EquipmentEvent.OnChangeItem?.Invoke(this.currentItemInstance,equipItem)==true)
            {
               
                UnEquip();
                Equip(equipItem);
                return;
            }
          
          
           
        }

        
        public void Equip(ItemInstance equipItemInstance)
        {
            EquipmentEvent.OnEquip?.Invoke(equipItemInstance);
            currentItemController.Place(equipItemInstance.objectAbstract);
            this.currentItemInstance = equipItemInstance;

           
        }

        public void UnEquip()
        {
            //old stat
            currentItemController.Reset();
        }

        
    }
}