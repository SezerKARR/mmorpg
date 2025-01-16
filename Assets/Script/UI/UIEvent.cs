using System;
using Script.ObjectInstances;
using Script.ScriptableObject;
using UnityEngine.Events;

namespace Script.UI
{
    public static class UIEvent
    {
        public static Action<string, ConfirmAction> OnOpenConfirm;
        public delegate void ConfirmAction();

        public static Action<ItemInstance> OnUpgradePanel;
        public static UnityAction CloseUpgradePanel;
        public static Action<ObjectAbstract> OnImageUnderCursorOpen;
        public static Action OnImageUnderCursorClose;
    }
}