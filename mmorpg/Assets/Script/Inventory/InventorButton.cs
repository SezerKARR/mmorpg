using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorButton : MonoBehaviour
{
    public GameObject ScriptableObjectScreener;
    public ScriptableObject scriptableObject;
    public SwordSO swordso;
    public Image Image;
    public int howMany=1;
    private float buttonOrginalHeight;
    private RectTransform button;
    private void Awake()
    {
        button = this.gameObject.GetComponent<RectTransform>();
        buttonOrginalHeight = button.rect.height;
    }
    public void SetScriptableObject(IWiewable wiewable)
    {

        scriptableObject=wiewable.GetScriptableObject();
    }
    
    public void ChangeSprite(IWiewable wiewable)
    {

        scriptableObject = wiewable.GetScriptableObject();

        int spriteLenght = wiewable.GetWeightInInventory();
        ButtonChangeSize(spriteLenght);
        Image.sprite = wiewable.GetSprite();
        Image.enabled = true;
        if (wiewable.StackLimit() > 1)
        {
            howMany++;
        }
        return;

    }

    public void ResetButtonSize()
    {
        button.sizeDelta = new Vector2(button.sizeDelta.x, buttonOrginalHeight);

        button.anchoredPosition = new Vector2(button.anchoredPosition.x, button.anchoredPosition.y + (buttonOrginalHeight));
    }
    public void ButtonChangeSize(int spriteHeight)
    {
        float newHeight = buttonOrginalHeight * spriteHeight;
        button.sizeDelta = new Vector2(button.sizeDelta.x, newHeight);
        float heightDifference = (newHeight - buttonOrginalHeight) / 2f;
        button.anchoredPosition = new Vector2(button.anchoredPosition.x, button.anchoredPosition.y - heightDifference);
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
    public void TakeScriptableObject(ScriptableObject takedScriptableObject)
    {
        scriptableObject = takedScriptableObject;
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

    public void ScreenerSetActive()
    {
        ScriptableObjectScreener.gameObject.SetActive(true);
        //ScriptableObjectScreener.GetComponent<UpgradeItemScreener>().Screen(scriptableObject);
    }
}
