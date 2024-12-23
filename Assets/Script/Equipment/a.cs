using System;
using System.Collections;
using System.Collections.Generic;
using Script.Inventory;
using Script.Inventory.Objects;
using Script.ScriptableObject.Equipment;
using UnityEngine;
using UnityEngine.Events;

   /* public static EquipmentManager Instance;
    private Dictionary<EquipmentType, IEquipmentAble> equippedItems = new Dictionary<EquipmentType, IEquipmentAble>();
    //public EquipmentBasic swordEquipment;
    //    public EquipmentBasic helmetEquipment;
    public event Action<IItemable, IItemable> OnEquipmentChanged;
    //public  event Action<ScriptableItemsAbstact> OnEquip;
    public  event Action OnUnEquip;
    private void Awake()
    {
        IEquipmentAble[] equips = this.GetComponentsInChildren<IEquipmentAble>();
        foreach(IEquipmentAble equip in equips)
        {
            equippedItems[equip.GetEquipmentType()]= equip;

        }
    }

    public bool Equip(ItemController itemcontroller)
    {
        if (equippedItems[itemcontroller.Itemable.GetEquipmentType()] == null)
        {
            
        }
    }
    public bool IsCharacterMatch(List<Character> canUseCharacter)
    {
        return canUseCharacter.Contains(PlayerController.instance.playerCharecterType);
    }
    public bool IsLevelEnough(int itemLevel)
    {
        return PlayerController.instance.level>=itemLevel;
    }
    public void a(IItemable a,IItemable b)
    {
        OnEquipmentChanged?.Invoke(a, b);
    }
    public bool ControlCanEquip(IItemable item)
    {
        if (IsLevelEnough(item.GetLevel()) && IsCharacterMatch(item.GetCanUseCharacters()))
        {
            EquipItem(item);
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
        }
    }
    private bool NeedUnequipForEquip(IInventorObjectable UnequipIviewable)
    {
        //return InventoryManager.Instance.NeedUnequip(UnequipIviewable);

        return false;
    }
    private bool HandleEquip(IEquipmentAble equipment, IItemable item)
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
    }
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
    }

 
    
}*/
   
