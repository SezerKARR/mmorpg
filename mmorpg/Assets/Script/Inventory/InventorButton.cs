using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler,IScreenAble
{
    public Vector2Int ButtonCount;
    //public GameObject ScriptableObjectScreener;
    public IViewable scriptableObjectIWiewable;
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
        howMany=newValue;
        howManyText.text = howMany.ToString();
    }
    public void SetScriptableObject(IViewable wiewable)
    {

        scriptableObjectIWiewable=wiewable;
        image.enabled = false;
    }
    
    public void ChangeSprite(IViewable wiewable)
    {

        scriptableObjectIWiewable = wiewable;

        ImageChangeSize(wiewable.GetWeightInInventory());
        image.sprite = wiewable.GetSprite();
        image.color = new Color(image.color.r,image.color.g,image.color.b,1f);
        if (wiewable.StackLimit() > 1)
        {
            Debug.Log(howMany);
            howMany++;
            howManyText.text=howMany.ToString();
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
        ImageUnderCursor.Instance.GameObject().SetActive(false);
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
   
    /*
    public void ChangeSprite(IWiewable wiewable,int howMany)
    {
       
       if (wiewable.GetWeightInInventory() == 1)
        {
            if (wiewable.GetSprite() != null)
            {
                Image.sprite = wiewable.GetSprite();
            }
            this.howMany += howMany;
            Image.enabled = true;
            return;
        }
    }*/
    /*public void TakeScriptableObject(ScriptableObject takedScriptableObject)
    {
        scriptableObjectIWiewable = takedScriptableObject;
    }*/

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.scriptableObjectIWiewable != null)
        {
            Screen();
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hide();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (InventoryManager.Instance.selectedButton == null&&this.scriptableObjectIWiewable!=null)
        {
            Debug.Log(this.gameObject.name);
            ImageUnderCursor.Instance.GetComponent<Image>().sprite = this.scriptableObjectIWiewable.GetSprite();
            ImageUnderCursor.Instance.GameObject().SetActive(true);
            InventoryManager.Instance.selectedButton=new SelectedButton(this, ButtonCount);
            return;
        }
        else if(InventoryManager.Instance.selectedButton != null)
        {
            Debug.Log(ButtonCount.y);
            InventoryManager.Instance.ChangeIViewableInventoryPosition(ButtonCount.y);
            
        }
        


    }
    
    public void Screen()
    {
        TooltipManager.Instance.Screen(this.scriptableObjectIWiewable);
    }

    public void Hide()
    {
        TooltipManager.Instance.Hide();
    }
    /*
public void OnPointerEnter(PointerEventData eventData)
{
print("mouseover");
//ToolTipUISystem.Show(scriptableObject, 1);
}

public void OnPointerExit(PointerEventData eventData)
{
//ToolTipUISystem.Hide( 1);
}*/

    /*public void ScreenerSetActive()
    {
        ScriptableObjectScreener.gameObject.SetActive(true);
        //ScriptableObjectScreener.GetComponent<UpgradeItemScreener>().Screen(scriptableObject);
    }*/
}
