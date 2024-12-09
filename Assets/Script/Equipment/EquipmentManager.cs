using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;
    
    public EquipmentButton swordEquipment;
    public EquipmentButton helmetEquipment;
    public event Action<ScriptableItemsAbstact, ScriptableItemsAbstact> OnEquipmentChanged;
    //public  event Action<ScriptableItemsAbstact> OnEquip;
    public  event Action OnUnEquip;
    private void Awake()
    {
        Instance = this;
    }
    public bool IsCharacterMatch(List<Character> canUseCharacter)
    {
        return canUseCharacter.Contains(Player.instance.playerCharecterType);
    }
    public bool IsLevelEnough(int itemLevel)
    {
        return Player.instance.level>=itemLevel;
    }
    public void a(ScriptableItemsAbstact a,ScriptableItemsAbstact b)
    {
        OnEquipmentChanged?.Invoke(a, b);
    }
    public bool ControlCanEquip(ScriptableItemsAbstact item)
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
        }*/
    }
    private bool NeedUnequipForEquip(IInventorObjectable UnequipIviewable)
    {
        return InventoryManager.Instance.NeedUnequip(UnequipIviewable);
        
    }
    private bool HandleEquip(EquipmentButton equipment, ScriptableItemsAbstact item)
    {
        if (equipment.inventorObjectAble == null)
        {
            //OnEquip?.Invoke(item);
            equipment.Equip(item);
            return true;
        }
        else if(CanUnequip(equipment))
        {
            //OnEquipmentChanged?.Invoke(equipment.inventorObjectAble, item);
            equipment.UnEquip();
            equipment.Equip(item);
            return true;
        }
        return false;
    }
    private bool EquipItem(ScriptableItemsAbstact item)
    {
        switch (item)
        {
            case SwordSO :
                return HandleEquip(swordEquipment, item);
                

            case HelmetSo:
                return HandleEquip(helmetEquipment, item);


            default:
                return false;
                
        }
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
    private bool CanUnequip(EquipmentButton unequipItem)
    {
        if (NeedUnequipForEquip(unequipItem.inventorObjectAble))
        {
            //unequipItem.UnEquip();
            return true;
        }
        return false;
    }
    public void Unequip(EquipmentButton unEquipItem)
    {
        if (CanUnequip(unEquipItem))
        {
            OnUnEquip?.Invoke();
            unEquipItem.UnEquip();
        }
    }

 
    
}
