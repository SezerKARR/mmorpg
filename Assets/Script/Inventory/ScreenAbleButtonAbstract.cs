using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ScreenAbleButtonAbstract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IScreenAble
{
    public IViewable scriptableObjectIWiewable;
    
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
        if (this.scriptableObjectIWiewable != null)
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
    public virtual void ChangeSprite(IViewable wiewable, int howMany)
    {

        scriptableObjectIWiewable = wiewable;

        ImageChangeSize(wiewable.GetWeightInInventory());
        image.sprite = wiewable.GetSprite();
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

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        



    }

    public void Screen()
    {
        TooltipManager.Instance.Screen(this.scriptableObjectIWiewable);
    }

    public void Hide()
    {
        TooltipManager.Instance.Hide();
    }
}
