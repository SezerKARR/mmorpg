using Script.Inventory;
using Script.Inventory.Objects;
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
                if (_inventoryManager.inventoryStorage.ControlUnequip(this.currentItem))
                {
                    UnEquip();
                }
                return;
            }

            if (currentItem == null)
            {
                //OnEquip?.Invoke(item);
                EquipmentEvent.OnEquip?.Invoke(equipItem);
                Equip(equipItem);
                return;
            }

            if (_inventoryManager.inventoryStorage.ControlUnequipForEquip(this.currentItem, equipItem))
            {
                UnEquip();
                Equip(equipItem);
            }
        }

        public void Equip(ItemController equipItem)
        {
            equipItem.Place(this.transform, gameObject.GetComponent<RectTransform>().rect.size);
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
            return type;
        }
    }
}