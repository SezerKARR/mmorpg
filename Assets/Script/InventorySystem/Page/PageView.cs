using System;
using System.Collections;
using System.Collections.Generic;
using Script.Inventory;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PageView : MonoBehaviour,IPointerClickHandler
{
    public int rowCount,columnCount;
    public PointerEventData EventData;
    public Action<Vector2> OnClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        this.EventData = eventData;
        Vector2 clickPosition = eventData.position;
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 localClickPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform, clickPosition, eventData.pressEventCamera, out localClickPosition);
        Vector2 topLeftAdjustedPosition = new Vector2(
            localClickPosition.x + rectTransform.rect.width / 2,
            localClickPosition.y - rectTransform.rect.height / 2
        );
        OnClick.Invoke(topLeftAdjustedPosition);
    }
    

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
}
