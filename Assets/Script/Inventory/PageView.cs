using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageView : MonoBehaviour,IPointerClickHandler
{
    public float _width;
    public float _height;
    [SerializeField] RectTransform _buttonPanel;
    public int rowCount,columnCount;
   

    public void ClosePage()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false; 
        canvasGroup.blocksRaycasts = false; 

    }
    public void OpenPage()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true; 
        canvasGroup.blocksRaycasts = true; 

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // Ekran koordinatındaki tıklama pozisyonunu al
        Vector2 clickPosition = eventData.position;

        // UI elementinin RectTransform'ını al
        RectTransform rectTransform = GetComponent<RectTransform>();

        // RectTransform'daki sol üst köşeye göre pozisyonu hesapla
        Vector2 localClickPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform, clickPosition, eventData.pressEventCamera, out localClickPosition);

        // Sol üst köşeyi (0, 0) yapmak için yerel pozisyonu dönüştür
        Vector2 topLeftAdjustedPosition = new Vector2(
            localClickPosition.x + rectTransform.rect.width / 2,
            localClickPosition.y - rectTransform.rect.height / 2
        );
        float x =  topLeftAdjustedPosition.x / _width;
        float y = Mathf.Abs(topLeftAdjustedPosition.y) / _height;
        int2 gridposition=new int2( Mathf.FloorToInt( x),Mathf.FloorToInt(y) );
        Debug.Log(gridposition);    
    }
}
