using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class InventorObjectAbstract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IScreenAble
{
    
    public IInventorObjectable inventorObjectAble;
    
    public float buttonOrginalHeight;
    public RectTransform imageRectTransform;
    public Image image;
    public virtual void Awake()
    {
        imageRectTransform = this.image.GameObject().GetComponent<RectTransform>();
        buttonOrginalHeight = imageRectTransform.rect.height;
    }
   
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (this.inventorObjectAble != null)
        {
            Screen();
        }

    }
    public virtual void ImageChangeSize(int spriteHeight)
    {
        float newHeight = buttonOrginalHeight * spriteHeight;
        imageRectTransform.sizeDelta = new Vector2(imageRectTransform.sizeDelta.x, newHeight);
        float heightDifference = (newHeight - buttonOrginalHeight) / 2f;
        imageRectTransform.anchoredPosition = new Vector2(imageRectTransform.anchoredPosition.x, imageRectTransform.anchoredPosition.y - heightDifference);
    }
    public virtual void ChangeSprite(IInventorObjectable inventorObjectAble, int howMany)
    {

        this.inventorObjectAble = inventorObjectAble;

        ImageChangeSize(inventorObjectAble.GetWeightInInventory());
        image.sprite = inventorObjectAble.GetSprite();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        

    }
    public virtual void ResetImageSize()
    {
        imageRectTransform.sizeDelta = new Vector2(imageRectTransform.sizeDelta.x, buttonOrginalHeight);

        imageRectTransform.anchoredPosition = new Vector2(0, 0);
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        Hide();
    }

    public abstract void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void Screen()
    {
        TooltipManager.Instance.Screen(this.inventorObjectAble);
    }

    public void Hide()
    {
        
        TooltipManager.Instance.Hide();
    }
}
