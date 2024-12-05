using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorButton : ScreenAbleButtonAbstract
{
    public Vector2Int ButtonCount;
    //public GameObject ScriptableObjectScreener;
    
    //public SwordSO swordso;
    
    public int howMany=0;
    
    public TextMeshProUGUI howManyText;
    public override void Awake()
    {
        base.Awake();
    }
    
    public void AddStack(int newValue)
    {
        Debug.Log("geldi");
        howMany=newValue;
        howManyText.text = howMany.ToString();
    }
    public void SetScriptableObject(IViewable wiewable)
    {

        scriptableObjectIWiewable=wiewable;
        image.enabled = false;
    }
    
    
    public void ResetButton()
    {

        howMany = 0;
        
        howManyText.gameObject.SetActive(false);
        Debug.Log(image);
        image.sprite = null;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        image.enabled = true;
        ResetImageSize();
        scriptableObjectIWiewable =null;
        
    }
    public override void ResetImageSize()
    {
        base.ResetImageSize();
    }
    public override void ImageChangeSize(int spriteHeight)
    {
        base.ImageChangeSize(spriteHeight);
    }
    public override void ChangeSprite(IViewable wiewable, int howMany)
    {

       base.ChangeSprite(wiewable, howMany);
        if (this.howMany + howMany <= wiewable.StackLimit())
        {
            this.howMany += howMany;
            howManyText.text = this.howMany.ToString();
        }
        return;

    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (InventoryManager.Instance.selectedButton == null && this.scriptableObjectIWiewable != null)
            {
                Debug.Log(this.gameObject.name);
                ImageUnderCursor.Instance.GetComponent<Image>().sprite = this.scriptableObjectIWiewable.GetSprite();
                ImageUnderCursor.Instance.GameObject().SetActive(true);
                InventoryManager.Instance.selectedButton = this;
                return;
            }
            else if (InventoryManager.Instance.selectedButton != null)
            {
                InventoryManager.Instance.ChangeIViewableInventoryPosition(ButtonCount.y);

            }
        }
        
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            InventoryManager.Instance.EquipThisItem(this);
        }


    }
}
