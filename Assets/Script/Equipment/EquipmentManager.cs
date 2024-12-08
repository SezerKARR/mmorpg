using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;
    
    public EquipmentBasic swordEquipment;
    public EquipmentBasic helmetEquipment;
    public event Action<ScriptableItemsAbstact, ScriptableItemsAbstact> OnEquipmentChanged;
    public  event Action<ScriptableItemsAbstact> OnEquip;
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
    public bool ControlCanEquip(InventorButton selectedButton)
    {
        if (selectedButton.inventorObjectAble is ScriptableItemsAbstact item)
        {
            if (IsLevelEnough(item.level) && IsCharacterMatch(item.canUseCharacters))
            {
                EquipItem(item);
                return true;
            }
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
    public bool NeedUnequipForEquip(IInventorObjectable UnequipIviewable)
    {
        return InventoryManager.Instance.NeedUnequip(UnequipIviewable);
        
    }
    private bool HandleEquip(EquipmentBasic equipment, ScriptableItemsAbstact item)
    {
        if (equipment.currentItem == null)
        {
            OnEquip?.Invoke(item);
            equipment.Equip(item);
            return true;
        }
        else if(NeedUnequipForEquip(equipment.inventorObjectAble))
        {
            OnEquipmentChanged?.Invoke(equipment.currentItem, item);
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
    public bool Unequip(EquipmentBasic unequipItem)
    {
        if (NeedUnequipForEquip(unequipItem.inventorObjectAble))
        {
            OnUnEquip?.Invoke();
            unequipItem.UnEquip();
            return true;
        }
        return false;
    }

 
    
}
