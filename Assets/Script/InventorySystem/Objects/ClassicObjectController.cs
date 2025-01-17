using Script.ObjectInstances;
using Script.ScriptableObject;
using Script.ScriptableObject.UpObject;
using Script.UI.Tooltip;
using Unity.VisualScripting;

namespace Script.InventorySystem.Objects
{
    public class ClassicObjectController:ObjectController
    {
        public ObjectType objectType;
        protected override void OnEnter()
        {
            base.OnEnter();
            ToolTipEvent.OnTooltip?.Invoke(objectInstance);
        }

        protected override void OnExit()
        {
            base.OnExit();
            ToolTipEvent.OnTooltipClose?.Invoke();
        }

        public override string GetPoolType()
        {
            return objectType.ToString();
        }

       

    }
}