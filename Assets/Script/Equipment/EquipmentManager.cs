using System;
using System.Collections.Generic;
using Game.Extensions.Unity;
using Script.Inventory.Objects;
using Script.ScriptableObject.Equipment;
using UnityEngine;

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
            ItemEvents.OnItemRightClickedInventory += Equip;
            EquipmentSlot[] equips = this.GetComponentsInChildren<EquipmentSlot>();
            foreach(EquipmentSlot equip in equips)
            {
                equipmentSlots[equip.GetEquipmentType()]= equip;

            }
        }

        public void Equip(ItemController itemcontroller)
        {
            Debug.Log(itemcontroller.itemable.GetEquipmentType());
            if (equipmentSlots.ContainsKey(itemcontroller.itemable.GetEquipmentType()))
            {
                 equipmentSlots[itemcontroller.itemable.GetEquipmentType()].SetItem(itemcontroller);
            
            }
        }
        public bool IsCharacterMatch(List<Character> canUseCharacter)
        {
            return canUseCharacter.Contains(Player.instance.playerCharecterType);
        }
        public bool IsLevelEnough(int itemLevel)
        {
            return Player.instance.level>=itemLevel;
        }
        public void a(IItemable a,IItemable b)
        {
            OnEquipmentChanged?.Invoke(a, b);
        }
        public bool ControlCanEquip(IItemable item,ItemController itemController)
        {
            if (IsLevelEnough(item.GetLevel()) && IsCharacterMatch(item.GetCanUseCharacters()))
            {
                equipmentSlots[item.GetEquipmentType()].SetItem(itemController);
                return true;
            }
            return false;
        }
        public void SamePos()
        {
            /*if (InventoryManager.Instance.ChangeIViewableInventoryPosition())                )
            if (!InventoryManager.Instance.add(this.scriptableObjectIWiewable, 1))
        {
            return;
        }*/
        }
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