namespace Script.Inventory.Objects
{
    public class UpgradeController : ObjectController
    {
        public override string GetPoolType()
        {
            return ObjectType.LeftClickStack.ToString();
        }
    }
}
