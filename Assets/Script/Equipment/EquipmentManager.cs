using System;
using System.Collections.Generic;
using Script.Inventory.Objects;
using Script.InventorySystem.Objects;
using Script.ObjectInstances;
using UnityEngine;
using Script.Player;
using Script.ScriptableObject.Equipment;
using Zenject;

namespace Script.Equipment
{
    [Serializable]
    public enum EquipmentType
    {
        None,
        Weapon,
        Helmet,
        Armor,
        Boots,
        Shield
    }
    public class EquipmentManager : MonoBehaviour
    {
        [SerializeField] private EquipmentSlots equipmentSlots;
        [Inject] private PlayerController _playerController;
        [Serializable]
        public class EquipmentSlots : UnityDictionary<EquipmentType, EquipmentSlot> { };
        
        //public  event Action<ItemInstance> OnEquip;
        //public  event Action OnUnEquip;
        private void Awake()
        {
           
            ItemEvents.OnItemRightClickedInventory += ControlCanEquip;
            EquipmentSlot[] equips = this.GetComponentsInChildren<EquipmentSlot>();
            foreach(EquipmentSlot equip in equips)
            {
                equipmentSlots[equip.GetEquipmentType()]= equip;

            }
        }

        // public void Equip(ItemController itemcontroller)
        // {
        //     if (equipmentSlots.ContainsKey(itemcontroller.itemModel.weaponType))
        //     {
        //          equipmentSlots[itemcontroller.itemModel.weaponType].SetItem(itemcontroller);
        //     
        //     }
        // }
        public bool IsCharacterMatch(List<CharacterType> canUseCharacter)
        {
            return canUseCharacter.Contains(_playerController.playerCharecterType);
        }
        public bool IsLevelEnough(int itemLevel)
        {
            return _playerController.level>=itemLevel;
        }
        public void ControlCanEquip(ItemInstance itemInstance)
        {
            if (IsLevelEnough(itemInstance.level) && IsCharacterMatch(itemInstance.canUseCharacters))
            {
                equipmentSlots[itemInstance.equipmentType].SetItem(itemInstance);
                
            }
        }
        // public void SamePos()
        // {
        //     /*if (InventoryManager.Instance.ChangeIViewableInventoryPosition())                )
        //     if (!InventoryManager.Instance.add(this.scriptableObjectIWiewable, 1))
        // {
        //     return;
        // }*/
        // }
        
        /*private bool HandleEquip(IEquipmentAble equipment, IItemable item)
    {
        if (equipment.GetItemable() == null)
        {
            //OnEquip?.Invoke(item);
            equipment.Equip(item);
            return true;
        }
        else if (NeedUnequipForEquip(equipment.GetItemable()))
        {
            OnEquipmentChanged?.Invoke(equipment.GetItemable(), item);
            equipment.UnEquip();
            equipment.Equip(item);
            return true;
        }
        return false;
    }
    private bool EquipItem(IItemable item)
    {
        return HandleEquip(equippedItems[item.GetEquipmentType()], item);
    }*/
        /*private bool EquipItem(ItemInstance item)
    {
        switch (item)
        {
            case SwordSO:
                return HandleEquip(swordEquipment, item);


            case HelmetSo:
                return HandleEquip(helmetEquipment, item);


            default:
                return false;

        }
    }*/
        /*private bool CanUnequip(EquipmentBasic unequipItem)
    {
        if (NeedUnequipForEquip(unequipItem.inventorObjectAble))
        {
            //unequipItem.UnEquip();
            return true;
        }
        return false;
    }
    public void Unequip(EquipmentBasic unEquipItem)
    {
        if (CanUnequip(unEquipItem))
        {
            OnUnEquip?.Invoke();
            unEquipItem.UnEquip();
        }
    }*/

 
    
    }
}