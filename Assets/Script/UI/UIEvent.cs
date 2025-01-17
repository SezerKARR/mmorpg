using System;
using Script.ObjectInstances;
using Script.ScriptableObject;
using Script.ScriptableObject.UpObject;
using UnityEngine.Events;

namespace Script.UI
{
    public static class UIEvent
    {
        public static Action<string, UnityAction,UnityAction> OnOpenConfirm;

        public static Action<ItemInstance,UpItemInstance> OnUpgradePanel;
        public static UnityAction CloseUpgradePanel;
        public static Action<ObjectAbstract> OnImageUnderCursorOpen;
        public static Action OnImageUnderCursorClose;
    }
}