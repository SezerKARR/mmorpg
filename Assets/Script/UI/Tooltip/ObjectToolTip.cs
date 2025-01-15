using System;
using Script.ObjectInstances;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.UI.Tooltip
{
    public class ObjectToolTip:ToolTip
    {
        public static Action<ObjectInstance> OnScreen;
        public TextMeshProUGUI description;
        protected override void Awake()
        {
            OnScreen += Screen;
            base.Awake();
        }

        private void Screen(ObjectInstance obj)
        {
            SetText(itemName,obj.ObjectName());
            SetText(description,obj.Description());
        }
    }
}