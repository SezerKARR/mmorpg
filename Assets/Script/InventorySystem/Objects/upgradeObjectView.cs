using Script.ObjectInstances;

namespace Script.InventorySystem.Objects
{
    public class UpgradeObjectView: ObjectView
    {
        public override void SetObject(ObjectInstance objectInstance)
        {
            howManyText.gameObject.SetActive(true);
            howManyText.text=objectInstance.howMany.ToString();
            base.SetObject(objectInstance);
        }
    }
}