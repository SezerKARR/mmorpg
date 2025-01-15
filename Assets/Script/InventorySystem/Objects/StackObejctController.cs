using Script.ScriptableObject;
using Script.UI.Tooltip;

namespace Script.InventorySystem.Objects
{
    public class StackObejctController:ObjectController
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            ObjectToolTip.OnScreen?.Invoke(objectInstance);
        }

        protected override void OnExit()
        {
            base.OnExit();
            ObjectToolTip.OnHide?.Invoke();
        }

        public override string GetPoolType()
        {
            return ObjectType.Stack.ToString();
        }
    }
}