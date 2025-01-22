using System;
using Script.ObjectInstances;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Script.UI.Tooltip
{
    public abstract class ToolTip:MonoBehaviour
    {
        [SerializeField]protected TextMeshProUGUI itemName;
        public static UnityAction OnHide;
        protected virtual void Awake()
        {
            OnHide += Hide;
        }

        public virtual void Screen(ObjectInstance obj)
        {
            this.gameObject.SetActive(true);
            SetText(itemName,obj.ObjectName());
        }
        protected void SetText(TextMeshProUGUI textMeshProUGUI,string writeText)
        {
            if (writeText != "")
            {
                textMeshProUGUI.gameObject.SetActive(true);
                textMeshProUGUI.text = writeText;
            }
        }
        public void Hide()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            this.gameObject.SetActive(false);
            
        }
    }
}