using System;
using Script.ScriptableObject;

namespace Script.UI
{
    public static class UIEvent
    {
        public static Action<string, ConfirmAction> OnOpenConfirm;
        public delegate void ConfirmAction();
        public static Action<ObjectAbstract> OnImageUnderCursorOpen;
        public static Action OnImageUnderCursorClose;
    }
}