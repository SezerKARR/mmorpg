using System;
using Script.InventorySystem.inventory;
using Script.InventorySystem.Objects;
using Script.ObjectInstances;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Script.Equipment
{
    public class EquipmentSlot : ObjectInstanceHolder
    {
        [FormerlySerializedAs("_type")] [SerializeField]
        private EquipmentType type;
        [SerializeField]private ItemController currentItemController;
        [Inject] private InventoryManager _inventoryManager;
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
                AddObject(equipItem,null);
                return;
            }
            
         
            if (currentItemInstance == equipItem)
            {
                InventoryEvent.OnGetObject?.Invoke(this.currentItemInstance);
                return;
            }
            
            if (EquipmentEvent.OnChangeItem?.Invoke(this.currentItemInstance,equipItem)==true)
            {
               
                AddObject(equipItem,null);
                return;
            }
          
          
           
        }
        public void Equip(ItemInstance equipItemInstance)
        {
            currentItemController.Place(equipItemInstance);
            this.currentItemInstance = equipItemInstance;
        }

        public void UnEquip(ItemInstance objectToRemove)
        {
            currentItemController.Reset();
            //old stat
        }

        public override void AddObject(ObjectInstance objectToAdd, CellsInfo cellsInfo)
        {           
            base.AddObject(objectToAdd, cellsInfo);
            Equip((ItemInstance)objectToAdd);
        }

        public override void RemoveObject(ObjectInstance objectToRemove)
        {
            
            UnEquip((ItemInstance)objectToRemove);
            base.RemoveObject(objectToRemove);
        }
    }
}