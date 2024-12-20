using System;
using System.Collections.Generic;
using Script.Inventory.Objects;
using Script.ScriptableObject.Equipment;
using UnityEngine;
using Script.Player;
namespace Script.Equipment
{
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

        [Serializable]
        public class EquipmentSlots : UnityDictionary<EquipmentType, EquipmentSlot> { };
        
        public event Action<IItemable, IItemable> OnEquipmentChanged;
        //public  event Action<ScriptableItemsAbstact> OnEquip;
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
        //     if (equipmentSlots.ContainsKey(itemcontroller.itemModel.equipmentType))
        //     {
        //          equipmentSlots[itemcontroller.itemModel.equipmentType].SetItem(itemcontroller);
        //     
        //     }
        // }
        public bool IsCharacterMatch(List<Character> canUseCharacter)
        {
            return canUseCharacter.Contains(Player.Player.instance.playerCharecterType);
        }
        public bool IsLevelEnough(int itemLevel)
        {
            return Player.Player.instance.level>=itemLevel;
        }
        public void a(IItemable a,IItemable b)
        {
            OnEquipmentChanged?.Invoke(a, b);
        }
        public void ControlCanEquip(ItemController itemController)
        {
            if (IsLevelEnough(itemController.scriptableItemsAbstact.level) && IsCharacterMatch(itemController.scriptableItemsAbstact.canUseCharacters))
            {
                equipmentSlots[itemController.scriptableItemsAbstact.equipmentType].SetItem(itemController);
                
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
        private bool NeedUnequipForEquip(IInventorObjectable UnequipIviewable)
        {
            //return InventoryManager.Instance.NeedUnequip(UnequipIviewable);

            return false;
        }
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
        /*private bool EquipItem(ScriptableItemsAbstact item)
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