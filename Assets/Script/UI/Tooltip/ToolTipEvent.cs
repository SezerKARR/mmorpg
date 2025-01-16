using System;
using Script.ObjectInstances;
using Script.ScriptableObject;
using Unity.VisualScripting;
using UnityEngine.Events;

namespace Script.UI.Tooltip
{
    public class ToolTipEvent
    {
        public static Action<ObjectInstance> OnTooltip;
        public static Action<ItemInstance> OnItemTooltip;
        public static UnityAction OnTooltipClose;
    }
}