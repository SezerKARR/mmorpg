using System;
using Script.ObjectInstances;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.UI.Tooltip
{
    public class TooltipManager : MonoBehaviour
    {
        public ItemToolTip itemTooltip;
        public ObjectToolTip objectTooltip;
        
        private ToolTip _currentTooltip;

        private void Awake()
        {
           ToolTipEvent.OnTooltip += OpenTooltip;
           ToolTipEvent.OnItemTooltip += OpenTooltip;
           ToolTipEvent.OnTooltipClose += CloseToolTip;

        }

        private void CloseToolTip()
        {
            _currentTooltip.Hide();
        }

        public void OpenTooltip(ItemInstance objectInstance)
        {
            
            Opened(itemTooltip, objectInstance);
        }
        private void OpenTooltip(ObjectInstance objectInstance)
        {
            
            Opened(objectTooltip, objectInstance);
        }

        public void Opened(ToolTip toolTip,ObjectInstance objectInstance)
        {
            _currentTooltip = toolTip;
            _currentTooltip.Screen(objectInstance);
        }

        private void Start()
        {
        
              
        }
        private void Update() {
            /*if (UIManager.Instance.GetUIElementUnderPointer() != null&&ItemTooltip.GameObject().activeSelf==false)
        {
            if (UIManager.Instance.GetUIElementUnderPointer().GetComponent<IViewable>() != null)
            {
                rectTransform=UIManager.Instance.GetUIElementUnderPointer().GetComponent<RectTransform>();
                SetName(UIManager.Instance.GetUIElementUnderPointer().GetComponent<IViewable>());
            }
        }
        if (ItemTooltip.GameObject().activeSelf == true) {
            if (UIManager.Instance.IsPointerOutsideUI(rectTransform))
            {
                Debug.Log(rectTransform.gameObject.name);
                Hide();
            }
        }*/
        }


        // public void SetName(ObjectInstance objectInstance)
        // {
        //     
        //     ItemTooltip.GameObject().SetActive(true);
        //     ItemTooltip.SetName(objectInstance);
        //
        // }
        // public void SetName(ItemInstance itemInstance)
        // {
        //     _currentTooltip = ItemTooltip;
        //     ItemTooltip.GameObject().SetActive(true);
        //     ItemTooltip.SetName(itemInstance);
        //
        // }
    

    }
}
