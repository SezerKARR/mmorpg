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
         private ItemInstance _currentItemInstance;
        [SerializeField]private ItemController currentItemController;
        [Inject] private InventoryManager _inventoryManager;

        public EquipmentType GetEquipmentType() => type;
        public void SetItem(ItemInstance equipItem)
        {
            Debug.Log("SetItem");
            if (_currentItemInstance == equipItem)
            {
                CellsInfo cellsInfo = InventoryEvent.OnGetEmptyCells?.Invoke(_currentItemInstance.weightInInventory, _currentItemInstance.howMany);
                if (cellsInfo!=null)
                {
                    UnEquip();
                }
                return;
            }

            if (_currentItemInstance == null)
            {
                //OnEquip?.Invoke(item);
                Equip(equipItem);
                return;
            }

            if (_inventoryManager.inventoryStorage.IsCanChangeItem(this._currentItemInstance, equipItem))
            {
                UnEquip();
                Equip(equipItem);
            }
        }

        public void Equip(ItemInstance equipItemInstance)
        {
            EquipmentEvent.OnEquip?.Invoke(equipItemInstance);
            this._currentItemInstance = equipItemInstance;
            currentItemController.Place(equipItemInstance.objectAbstract);
        }

        public void UnEquip()
        {
            EquipmentEvent.OnUnequip?.Invoke(_currentItemInstance);
            currentItemController.Reset();
        }

        
    }
}