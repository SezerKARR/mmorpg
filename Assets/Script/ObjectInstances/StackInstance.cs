using System;

namespace Script.ObjectInstances
{
    [Serializable]
    public class StackInstance:ObjectInstance
    {
        public override string DropName()
        {
           return base.DropName();
        }
    }
}