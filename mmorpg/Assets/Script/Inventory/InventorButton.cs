using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject ScriptableObjectScreener;
    public ScriptableObject scriptableObject;
    public SwordSO swordso;
    public Image Image;
    public int howMany;
    public void ChangeSprite(int spriteLenght,Sprite sprite)
    {

        if (spriteLenght == 2)
        {
            print(Image.rectTransform.localScale.x / 2);
            

            Image.rectTransform.anchoredPosition = new Vector2(Image.rectTransform.anchoredPosition.x,  (Image.rectTransform.anchoredPosition.y-35));
            Image.rectTransform.localScale = new Vector2(Image.rectTransform.localScale.x, Image.rectTransform.localScale.y * 2);
            Image.sprite =sprite;
            Image.enabled = true;
            return;
        }
        else if (spriteLenght == 1)
        {
            Image.sprite = sprite;
            Image.enabled = true;
            return;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("mouseover");
        ToolTipUISystem.Show(scriptableObject, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipUISystem.Hide( 1);
    }

    public void ScreenerSetActive()
    {
        ScriptableObjectScreener.gameObject.SetActive(true);
        //ScriptableObjectScreener.GetComponent<UpgradeItemScreener>().Screen(scriptableObject);
    }
}
