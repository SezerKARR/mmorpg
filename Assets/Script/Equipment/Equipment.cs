using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public IItemable currentItem;

    public void Equip(ScriptableItemsAbstact scriptableItemsAbstact)
    {
        
        
        //EquipmentManager.Instance.a(scriptableItemsAbstact, scriptableItemsAbstact);
        
        this.currentItem = scriptableItemsAbstact;
        this.currentItem.SetNewStats();
       
        
    }

  

    public void UnEquip()
    {
       
        this.currentItem.SetOldStats();
        this.currentItem = null;
        
    }

    /*public ScriptableItemsAbstact GetSOItem()
    {
        return inventorObjectAble;
    }*/


}
