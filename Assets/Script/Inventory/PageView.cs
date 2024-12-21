using System;
using System.Collections;
using System.Collections.Generic;
using Script.Inventory;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageView : MonoBehaviour
{
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
}
