using System;

namespace Script.UI
{
    public static class UIEvent
    {
        public static Action<string, ConfirmAction,ConfirmAction> OnOpenConfirm;
        public delegate void ConfirmAction();
        public static Action<ObjectAbstract> OnImageUnderCursorOpen;
        public static Action OnImageUnderCursorClose;
    }
}