using Script.InventorySystem.inventory;
using Script.InventorySystem.Objects;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Script.Equipment
{
    public class EquipmentSlot : MonoBehaviour
    {
        [FormerlySerializedAs("_type")] [SerializeField]
        private EquipmentType type;

        [SerializeField] private ItemController currentItem;
        [Inject] private InventoryManager _inventoryManager;
        

        public void SetItem(ItemController equipItem)
        {
            Debug.Log("SetItem");
            if (currentItem == equipItem)
            {
                CellsInfo cellsInfo = InventoryEvent.OnGetEmptyCells?.Invoke(currentItem.itemInstance.weightInInventory, currentItem.itemInstance.howMany);
                if (cellsInfo!=null)
                {
                    UnEquip();
                }
                return;
            }

            if (currentItem == null)
            {
                //OnEquip?.Invoke(item);
                Equip(equipItem);
                return;
            }

            // if (_inventoryManager.inventoryStorage.IsCanChangeItem(this.currentItem, equipItem))
            // {
            //     UnEquip();
            //     Equip(equipItem);
            // }
        }

        public void Equip(ItemController equipItem)
        {
            EquipmentEvent.OnEquip?.Invoke(equipItem.itemInstance);
            equipItem.Place(this);
            this.currentItem = equipItem;
        }

        public void UnEquip()
        {
            EquipmentEvent.OnUnequip?.Invoke(currentItem);
            this.currentItem = null;
        }

        public EquipmentType GetEquipmentType()
        {
            return type;
        }
    }
}