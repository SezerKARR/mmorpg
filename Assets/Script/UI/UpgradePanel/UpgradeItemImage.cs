using System.Collections;
using System.Collections.Generic;
using Script.UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItemImage : MonoBehaviour
{
    public RectTransform imageRectTransform;
    public Image image;
    public float buttonOrginalHeight;
    private void Awake()
    {
        UIManager.OnUpgradePanelNeed += UIManager_UpgradePanelNeed;
        
        imageRectTransform = this.image.GameObject().GetComponent<RectTransform>();
        buttonOrginalHeight = imageRectTransform.rect.height;
    }
    

    private void UIManager_UpgradePanelNeed(IInventorObjectable inventorObjectable)
    {
        gameObject.SetActive(true);
        ChangeSprite(inventorObjectable);
    }
    public virtual void ImageChangeSize(int spriteHeight)
    {
        float newHeight = buttonOrginalHeight * spriteHeight;
        imageRectTransform.sizeDelta = new Vector2(imageRectTransform.sizeDelta.x, newHeight);
        float heightDifference = (newHeight - buttonOrginalHeight) / 2f;
        imageRectTransform.anchoredPosition = -new Vector2(imageRectTransform.anchoredPosition.x, imageRectTransform.anchoredPosition.y - heightDifference);
    }
    public virtual void ChangeSprite(IInventorObjectable inventorObjectAble)
    {


        ImageChangeSize(inventorObjectAble.GetWeightInInventory());
        image.sprite = inventorObjectAble.GetSprite();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);


    }
}
