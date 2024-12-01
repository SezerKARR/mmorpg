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
    public int howMany;
    private float buttonLenght;
    public void SetScriptableObject(IWiewable wiewable)
    {

        scriptableObject=wiewable.GetScriptableObject();
    }
    public void ChangeSprite(IWiewable wiewable)
    {
        scriptableObject = wiewable.GetScriptableObject();
        buttonLenght =this.gameObject.GetComponent<RectTransform>().rect.height;
        int spriteLenght=wiewable.GetWeightInInventory();
        if (spriteLenght == 3)
        {
            print(Image.rectTransform.localScale.x / 3);


            Image.rectTransform.anchoredPosition = new Vector2(Image.rectTransform.anchoredPosition.x, (Image.rectTransform.anchoredPosition.y - buttonLenght/3));
            Image.rectTransform.localScale = new Vector2(Image.rectTransform.localScale.x, Image.rectTransform.localScale.y * 3);
            Image.sprite = wiewable.GetSprite();
            Image.enabled = true;
            return;
        }
        else if (spriteLenght == 2)
        {
            print(Image.rectTransform.localScale.x / 2);
            

            Image.rectTransform.anchoredPosition = new Vector2(Image.rectTransform.anchoredPosition.x,  (Image.rectTransform.anchoredPosition.y/2));
            Image.rectTransform.localScale = new Vector2(Image.rectTransform.localScale.x, Image.rectTransform.localScale.y * 2);
            Image.sprite = wiewable.GetSprite();
            Image.enabled = true;
            return;
        }
        else if (spriteLenght == 1)
        {
            if (wiewable.GetSprite() != null)
            {
                Image.sprite = wiewable.GetSprite();
            }
            howMany++;
                Image.enabled = true;
            return;
        }
    }
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
    }
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
