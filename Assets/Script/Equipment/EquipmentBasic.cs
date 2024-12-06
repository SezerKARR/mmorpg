using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentBasic : InventorObjectAbstract, IEquipmentAble
{


    public override void Awake()
    {

        base.Awake();
    }
    public int armorModifier()
    {
        return 0;
    }
    public bool Equip(ScriptableItemsAbstact scriptableItemsAbstact)
    {
        if (NeedUnEquip())
        {
            if(!UnEquip())
            {
                return false;
            }

        }
        EquipmentManager.Instance.a(scriptableItemsAbstact, this.inventorObjectAble.GetScriptableItemsAbstact());
        this.inventorObjectAble = scriptableItemsAbstact;
        this.image.sprite = scriptableItemsAbstact.Image;
        this.image.color = new Color(this.image.color.r, this.image.color.g, this.image.color.b, 255);
        return true;
    }
    public bool UnEquip()
    {   //yer var mý diye kontrol ediyor
        if (!EquipmentManager.Instance.NeedUnequip(this.inventorObjectAble))
        {
            return false;

        }
        this.inventorObjectAble = null;
        this.image.sprite = null;
        this.image.color = new Color(this.image.color.r, this.image.color.g, this.image.color.b, 0);
        return true;
    }
    public bool NeedUnEquip()
    {
        if (this.inventorObjectAble != null) return true;
        return false;
    }
    public ItemViewable GetSOItem()
    {
        return inventorObjectAble;
    }


}
