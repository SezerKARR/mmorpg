using System;
using Script.ScriptableObject;
using Unity.VisualScripting;
using UnityEngine.Events;

namespace Script.UI.Tooltip
{
    public class ToolTipEvent
    {
        public static Action<ObjectAbstract> OnTooltip;
        public static UnityAction OnTooltipClose;
    }
}