using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentButton : InventorObjectAbstract
{
    
    public void Equip(ScriptableItemsAbstact scriptableItemsAbstact)
    {
        this.inventorObjectAble = scriptableItemsAbstact;
        this.image.sprite = scriptableItemsAbstact.Image;
        this.image.color = new Color(this.image.color.r, this.image.color.g, this.image.color.b, 255);

    }

    public override void OnPointerClick(PointerEventData eventData)
    {


        if (eventData.button == PointerEventData.InputButton.Right)
        {
            EquipmentManager.Instance.Unequip(this);

        }


    }
    public void UnEquip()
    {
        this.inventorObjectAble = null;
        this.image.sprite = null;
        this.image.color = new Color(this.image.color.r, this.image.color.g, this.image.color.b, 0);

    }
    //public override void ChangeSprite(IInventorObjectable inventorObjectAble)
    //{
    //    base.ChangeSprite(inventorObjectAble);
    //}
}
