using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;
    
    public EquipmentBasic swordEquipment;
    public EquipmentBasic helmetEquipment;
    public event Action<ScriptableItemsAbstact, ScriptableItemsAbstact> OnEquipmentChanged;
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
    public bool NeedUnequip(IInventorObjectable UnequipIviewable)
    {
        return InventoryManager.Instance.NeedUnequip(UnequipIviewable);
        
    }
    private bool EquipItem(ScriptableItemsAbstact item)
    {
        switch (item)
        {
            case SwordSO :
                return swordEquipment.Equip(item);
                

            case HelmetSo:
                return helmetEquipment.Equip(item);
                

            default:
                return false;
                
        }
    }

 
    
}
