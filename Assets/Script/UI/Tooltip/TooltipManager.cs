using System.Collections;
using System.Collections.Generic;
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
    private void Awake()
    {
        Instance = this;
        Hide();
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


    public void Screen(IInventorObjectable scriptableObject)
    {
        
        tooltip.GameObject().SetActive(true);
        tooltip.Screen(scriptableObject);

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
