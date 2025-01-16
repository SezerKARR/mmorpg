using System;
using Script.ObjectInstances;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.UI.Tooltip
{
    public class ObjectToolTip:ToolTip
    {
        public TextMeshProUGUI description;


        public override void Screen(ObjectInstance obj)
        {
            base.Screen(obj);
            SetText(description,obj.Description());
            
        }
    }
}