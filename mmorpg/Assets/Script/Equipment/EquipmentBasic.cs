using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class EquipmentBasic : ScreenAbleButtonAbstract,IEquipmentAble
{
    private ScriptableItemsAbstact ScriptableItemsAbstact;
    private Image image;
    public virtual void Equip(ScriptableItemsAbstact ScriptableItemsAbstact)
    {
        this.ScriptableItemsAbstact = ScriptableItemsAbstact;
        this.image.sprite = ScriptableItemsAbstact.Image;
        this.image.color=new Color(this.image.color.a,this.image.color.g,this.image.color.b,255);
    }
    public virtual void Unequip()
    {
        this.image.sprite = null;
        this.image.color = new Color(this.image.color.a, this.image.color.g, this.image.color.b, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public ScriptableItemsAbstact GetSOItem()
    {
        return ScriptableItemsAbstact;
    }

   
}
