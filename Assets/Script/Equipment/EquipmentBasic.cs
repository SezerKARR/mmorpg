using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentBasic : InventorObjectAbstract
{
    public ScriptableItemsAbstact currentItem;

    public override void Awake()
    {
        this.gameObject.tag = "Equipment";
        base.Awake();
    }
    public void Equip(ScriptableItemsAbstact scriptableItemsAbstact)
    {
        
        
        EquipmentManager.Instance.a(scriptableItemsAbstact, scriptableItemsAbstact);
        this.inventorObjectAble = scriptableItemsAbstact;
        this.currentItem = scriptableItemsAbstact;
        this.currentItem.SetNewStats();
        this.image.sprite = scriptableItemsAbstact.Image;
        this.image.color = new Color(this.image.color.r, this.image.color.g, this.image.color.b, 255);
        
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        throw new NotImplementedException();
        //item çýkarma equipment basic te yapýlacak sað týklama ile 
    }

    public void UnEquip()
    {   
        this.currentItem.SetOldStats();
        this.inventorObjectAble = null;
        this.image.sprite = null;
        this.image.color = new Color(this.image.color.r, this.image.color.g, this.image.color.b, 0);
        
    }

    /*public ScriptableItemsAbstact GetSOItem()
    {
        return inventorObjectAble;
    }*/


}
