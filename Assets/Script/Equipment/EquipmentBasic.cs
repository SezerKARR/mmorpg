using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentBasic : InventorObjectAbstract,IEquipmentAble
{
    public IItemable currentItem;
    public EquipmentType equipmentType;
    public override void Awake()
    {
        this.image=GetComponent<Image>();
        this.gameObject.tag = "Equipment";
        base.Awake();
    }
    public void Equip(IItemable equipItem)
    {


        EquipmentManager.Instance.a(equipItem, equipItem);
        this.inventorObjectAble = equipItem;
        this.currentItem = equipItem;
        this.currentItem.SetNewStats();
        this.image.sprite = equipItem.GetSprite(); ;
        this.image.color = new Color(this.image.color.r, this.image.color.g, this.image.color.b, 255);

    }


    public EquipmentType GetEquipmentType()
    {
        return equipmentType;
    }

    public IItemable GetItemable()
    {
        return this.currentItem;    
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