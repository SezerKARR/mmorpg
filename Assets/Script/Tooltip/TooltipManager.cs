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
    public GameObject confirm;
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

    public void Screen(IViewable scriptableObject)
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
