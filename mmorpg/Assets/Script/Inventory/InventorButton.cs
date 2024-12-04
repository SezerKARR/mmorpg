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
    public Image image;
    public int howMany=0;
    private float buttonOrginalHeight;
    private RectTransform imageRectTransform;
    public TextMeshProUGUI howManyText;
    private void Awake()
    {
        imageRectTransform = this.image.GameObject().GetComponent<RectTransform>();
        buttonOrginalHeight = imageRectTransform.rect.height;
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
    
    public void ChangeSprite(IViewable wiewable,int howMany)
    {

        scriptableObjectIWiewable = wiewable;

        ImageChangeSize(wiewable.GetWeightInInventory());
        image.sprite = wiewable.GetSprite();
        image.color = new Color(image.color.r,image.color.g,image.color.b,1f);
        if (this.howMany+howMany< wiewable.StackLimit() )
        {
            this.howMany+=howMany;
            howManyText.text= this.howMany.ToString();
        }
        return;

    }
    public void ResetButton()
    {

        howMany = 0;
        
        howManyText.gameObject.SetActive(false);
        image.sprite = null;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        image.enabled = true;
        ResetImageSize();
        scriptableObjectIWiewable =null;
        
    }
    public void ResetImageSize()
    {
        imageRectTransform.sizeDelta = new Vector2(imageRectTransform.sizeDelta.x, buttonOrginalHeight);

        imageRectTransform.anchoredPosition = new Vector2(0,0);
    }
    public void ImageChangeSize(int spriteHeight)
    {
        float newHeight = buttonOrginalHeight * spriteHeight;
        imageRectTransform.sizeDelta = new Vector2(imageRectTransform.sizeDelta.x, newHeight);
        float heightDifference = (newHeight - buttonOrginalHeight) / 2f;
        imageRectTransform.anchoredPosition = new Vector2(imageRectTransform.anchoredPosition.x, imageRectTransform.anchoredPosition.y - heightDifference);
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
