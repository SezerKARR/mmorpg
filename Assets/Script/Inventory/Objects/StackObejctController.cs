using Script.ScriptableObject;

namespace Script.Inventory.Objects
{
    public class StackObejctController:ObjectController
    {
        
        public override string GetPoolType()
        {
            return ObjectType.Stack.ToString();
        }
    }
}