using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public  class EquipmentBasic : ScreenAbleButtonAbstract,IEquipmentAble
{
    
    
    public override void Awake()
    {

        base.Awake();
    }
    public  void Equip(ScriptableItemsAbstact ScriptableItemsAbstact)
    {
        if (NeedUnEquip())
        {
            if (!InventoryManager.Instance.add(this.scriptableObjectIWiewable,1))
            {
                return;
            }
            UnEquip();
        }
        this.scriptableObjectIWiewable = ScriptableItemsAbstact;
        this.image.sprite = ScriptableItemsAbstact.Image;
        this.image.color=new Color(this.image.color.a,this.image.color.g,this.image.color.b,255);
    }
    public  void UnEquip()
    {
        if (InventoryManager.Instance.add(this.scriptableObjectIWiewable, 1))
        {
            this.scriptableObjectIWiewable = null;
            this.image.sprite = null;
            this.image.color = new Color(this.image.color.a, this.image.color.g, this.image.color.b, 0);
        }
        else { Debug.Log("giyilemez"); }
        
    }
    public  bool NeedUnEquip() { 
        if(this.scriptableObjectIWiewable != null) return true;
        return false;        
    }
    public IViewable GetSOItem()
    {
        return scriptableObjectIWiewable;
    }

   
}
