using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class TooltipManager : MonoBehaviour
{
    public static TooltipManager instance;
    public ToolTip tooltip;
    [SerializeField]
    private ScriptableObject swords;
    public RectTransform rectTransform;
    private void Awake()
    {
        instance = this;
        Hide();
    }
    private void Start()
    {
        Debug.Log(tooltip.GameObject().activeSelf);
              
    }
    private void Update() {
        if (UIManager.Instance.GetUIElementUnderPointer() != null&&tooltip.GameObject().activeSelf==false)
        {
            if (UIManager.Instance.GetUIElementUnderPointer().GetComponent<IWiewable>() != null)
            {
                rectTransform=UIManager.Instance.GetUIElementUnderPointer().GetComponent<RectTransform>();
                Screen(UIManager.Instance.GetUIElementUnderPointer().GetComponent<IWiewable>().GetScriptableObject());
            }
        }
        if (tooltip.GameObject().activeSelf == true) {
            if (UIManager.Instance.IsPointerOutsideUI(rectTransform))
            {
                Debug.Log(rectTransform.gameObject.name);
                Hide();
            }
        }
    }

    /*public void screen(ScriptableObject scriptableObject)
    {
        tooltip.enabled = true;
        if (scriptableObject is UpgradeItemsSO sword)
        { 
            tooltip.swordNameText.text = sword.name;
            tooltip.attackValueText.text = sword.info;
            tooltip.swordNameText.enabled = true;
            tooltip.attackValueText.enabled = true;
        }
        
    }*/

    public void Screen(ScriptableObject scriptableObject)
    {
        tooltip.GameObject().SetActive(true);
        tooltip.Screen(scriptableObject);

    }
    public void Hide()
    {
        tooltip.hide();
        tooltip.GameObject().SetActive(false);
        
    }

}
