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
    
    
    public override void ResetButton()
    {

        howMany = 0;
        
        howManyText.gameObject.SetActive(false);
        
        base.ResetButton();
        
    }
    public override void ResetImageSize()
    {
        base.ResetImageSize();
    }
    public override void ImageChangeSize(int spriteHeight)
    {
        base.ImageChangeSize(spriteHeight);
    }
    public override void ChangeSprite(IInventorObjectable inventorObjectAble)
    {

       base.ChangeSprite(inventorObjectAble);
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
                
                InventoryManager.onButtonSelect(this);
                return;
            }
            else if (InventoryManager.Instance.selectedButton != null && this.inventorObjectAble == null)
            {
                InventoryManager.Instance.ChangeIViewableInventoryPosition(ButtonPos.y, InventoryManager.Instance.selectedButton);
                return;
            }
            else if (InventoryManager.Instance.selectedButton != null && this.inventorObjectAble != null)
            {
                if (InventoryManager.Instance.selectedButton.inventorObjectAble is IMakeJobable makeJobable)
                {
                    makeJobable.MakeJob(this);
                }
                return;
            }
        }
        
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (this.inventorObjectAble is IRightClickAble rightClickAble)
            {
                rightClickAble.RightClick(this);
            }

        }


    }
}
