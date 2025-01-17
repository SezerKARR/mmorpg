using System;
using Script.ScriptableObject;

namespace Script.ObjectInstances
{
    [Serializable]
    public class StackInstance:ObjectInstance
    {
        public StackInstance(ObjectAbstract objectAbstract) : base(objectAbstract)
        {
        }

        public override string DropName()
        {
           return base.DropName();
        }
    }
}