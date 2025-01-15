using System;
using System.Collections;
using System.Collections.Generic;
using Script.ObjectInstances;
using Script.ScriptableObject;
using Script.UI.Tooltip;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;
    public ItemToolTip tooltip;
    [SerializeField]
    private ScriptableObject swords;
    public RectTransform rectTransform;
    private void Awake()
    {
        Instance = this;
        Hide();
    }

    private void OnEnable()
    {
        ToolTipEvent.OnTooltip += Open;
        ToolTipEvent.OnTooltipClose += Hide;
    }

    private void Open(ObjectInstance obj)
    {
        if(obj is ItemInstance a){Screen(a);}
    }

    private void Start()
    {
        
              
    }
    private void Update() {
        /*if (UIManager.Instance.GetUIElementUnderPointer() != null&&tooltip.GameObject().activeSelf==false)
        {
            if (UIManager.Instance.GetUIElementUnderPointer().GetComponent<IViewable>() != null)
            {
                rectTransform=UIManager.Instance.GetUIElementUnderPointer().GetComponent<RectTransform>();
                Screen(UIManager.Instance.GetUIElementUnderPointer().GetComponent<IViewable>());
            }
        }
        if (tooltip.GameObject().activeSelf == true) {
            if (UIManager.Instance.IsPointerOutsideUI(rectTransform))
            {
                Debug.Log(rectTransform.gameObject.name);
                Hide();
            }
        }*/
    }


    // public void Screen(ObjectInstance objectInstance)
    // {
    //     
    //     tooltip.GameObject().SetActive(true);
    //     tooltip.Screen(objectInstance);
    //
    // }
    public void Screen(ItemInstance itemInstance)
    {
        
        tooltip.GameObject().SetActive(true);
        tooltip.Screen(itemInstance);

    }
    public void Hide()
    {
        if (tooltip.GameObject().activeSelf)
        {
            tooltip.hide();
            tooltip.gameObject.SetActive(false);
        }
            
        
    }

}
