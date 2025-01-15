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
    public ToolTip tooltip;
    [SerializeField]
    private ScriptableObject swords;
    public RectTransform rectTransform;
    private ToolTip _currentTooltip;
    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        //ToolTipEvent.OnTooltip += Open;
        // ToolTipEvent.OnTooltipClose += Hide;
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
    // public void Screen(ItemInstance itemInstance)
    // {
    //     _currentTooltip = tooltip;
    //     tooltip.GameObject().SetActive(true);
    //     tooltip.Screen(itemInstance);
    //
    // }
    

}
