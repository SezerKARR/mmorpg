using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorButton : InventorObjectAbstract
{
    public Vector2Int ButtonPos;
    //public GameObject ScriptableObjectScreener;
    
    //public SwordSO swordso;
    
    public int howMany=0;
    
    public TextMeshProUGUI howManyText;
    public override void Awake()
    {
        base.Awake();
        howManyText.gameObject.SetActive(false);
    }
    
    public void AddStack(int newValue)
    {
        Debug.Log("geldi");
        howMany=newValue;
        howManyText.text = howMany.ToString();
        howManyText.gameObject.SetActive(true);
    }
    public void SetScriptableObject(IInventorObjectable inventorObjectAble)
    {

        this.inventorObjectAble= inventorObjectAble;
        image.enabled = false;
    }
    
    
    public void ResetButton()
    {

        howMany = 0;
        
        howManyText.gameObject.SetActive(false);
        image.sprite = null;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        image.enabled = true;
        ResetImageSize();
        inventorObjectAble =null;
        
    }
    public override void ResetImageSize()
    {
        base.ResetImageSize();
    }
    public override void ImageChangeSize(int spriteHeight)
    {
        base.ImageChangeSize(spriteHeight);
    }
    public override void ChangeSprite(IInventorObjectable inventorObjectAble, int howMany)
    {

       base.ChangeSprite(inventorObjectAble, howMany);
        if (this.howMany + howMany <= inventorObjectAble.GetStackLimit())
        {
            this.howMany += howMany;
            howManyText.text = this.howMany.ToString();
        }
        InventoryManager.Instance.lastTakedButton = this;
        return;

    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (InventoryManager.Instance.selectedButton == null && this.inventorObjectAble != null)
            {
                Debug.Log(this.gameObject.name);
                ImageUnderCursor.Instance.GetComponent<Image>().sprite = this.inventorObjectAble.GetSprite();
                ImageUnderCursor.Instance.GameObject().SetActive(true);
                InventoryManager.Instance.selectedButton = this;
                return;
            }
            else if (InventoryManager.Instance.selectedButton != null)
            {
                InventoryManager.Instance.ChangeIViewableInventoryPosition(ButtonPos.y, InventoryManager.Instance.selectedButton);

            }
        }
        
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if(this.inventorObjectAble is ScriptableItemsAbstact)
            {
                InventoryManager.Instance.EquipThisItem(this);
            }
            
        }


    }
}
