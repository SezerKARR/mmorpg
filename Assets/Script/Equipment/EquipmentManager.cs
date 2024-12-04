using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;
    
    public SwordSO swordSO;
    public HelmetSo helmetSO;

    private void Awake()
    {
        Instance = this;
        
    }
    

    public void ControlCanEquip(ScriptableItemsAbstact scriptableItemsAbstact)
    {
        switch (scriptableItemsAbstact)
        {
            case SwordSO sword:
                HandleEquipment(sword, ref swordSO);
                break;

            case HelmetSo helmet:
                HandleEquipment(helmet, ref helmetSO);
                break;

            default:
                Debug.Log("Unknown item type");
                break;
        }
    }

    private void HandleEquipment<T>(T item, ref T currentItem) where T : ScriptableItemsAbstact
    {
        if (currentItem == null)
        {
            Equip(item);
        }
        else
        {
            UnEquip(currentItem);
            Equip(item);
        }
        currentItem = item;
    }
    public void Equip(ScriptableItemsAbstact scriptableItemsAbstact)
    {

    } 
    public void UnEquip(ScriptableItemsAbstact scriptableItemsAbstact)
    {
        switch (scriptableItemsAbstact)
        {
            case SwordSO swordSO:
                Debug.Log(swordSO.ToString());
                break;

            case HelmetSo helmetSO:
                Debug.Log(helmetSO.ToString());
                break;

            // Add more cases as needed
            default:
                Debug.Log("Unknown item type");
                break;
        }

    }
}
