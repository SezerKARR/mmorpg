using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;
    
    public EquipmentBasic swordEquipment;
    public EquipmentBasic helmetEquipment;

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

    public bool ControlCanEquip(IViewable scriptableIViewable)
    {
        if (scriptableIViewable is ScriptableItemsAbstact item)
        {
            if (IsLevelEnough(item.level) && IsCharacterMatch(item.canUseCharacters))
            {
                EquipItem(item);
                return true;
            }
        }
        return false;
    }

    private void EquipItem(ScriptableItemsAbstact item)
    {
        switch (item)
        {
            case SwordSO :
                swordEquipment.Equip(item);
                break;

            case HelmetSo:
                helmetEquipment.Equip(item);
                break;

            default:
                Debug.Log("Unknown item type");
                break;
        }
    }

 
    
}
