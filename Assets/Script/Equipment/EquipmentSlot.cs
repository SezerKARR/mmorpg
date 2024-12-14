using Script.Inventory.Objects;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Script.Equipment
{
    public  class EquipmentSlot : MonoBehaviour
    {
        [Inject][SerializeField] private InventoryManager _inventoryManager;
        [SerializeField] private EquipmentType _type;
        [SerializeField] private int2 _size = new int2(1,1);
        [SerializeField] private ItemController currentItem;
     
        public bool SetItem(ItemController itemController)
        {
            Debug.Log("SetItem");
            if (currentItem == null)
            {
                //OnEquip?.Invoke(item);
                Equip(itemController);
                return true;
            }
            else if (NeedUnequipForEquip(currentItem.itemModel.ItemSO))
            {
               // OnEquipmentChanged?.Invoke(equipment.GetItemable(), item);
                UnEquip();
                Equip(itemController);
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
        private bool NeedUnequipForEquip(ScriptableItemsAbstact equipItem)
        {
            return _inventoryManager.NeedUnequip(equipItem);

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