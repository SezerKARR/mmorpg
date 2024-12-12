using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*public class EquipmentBasic : InventorObjectAbstract,IEquipmentAble
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
        this.currentItem = equipItem;
        this.currentItem.SetNewStats();
        base.ChangeSprite(equipItem);

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
        //item ��karma equipment basic te yap�lacak sa� t�klama ile 
    }

    public void UnEquip()
    {
        
        this.currentItem.SetOldStats();
        this.currentItem = null;
        base.ResetButton();
    }

    /*public ScriptableItemsAbstact GetSOItem()
    {
        return inventorObjectAble;
    }*/


