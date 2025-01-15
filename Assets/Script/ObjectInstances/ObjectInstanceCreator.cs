using Script.ScriptableObject;
using Script.ScriptableObject.Equipment;

namespace Script.ObjectInstances
{
    public class ObjectInstanceCreator
    {
        public static ObjectInstance ObjectInstance(ObjectAbstract objectAbstract)
        {
            if (objectAbstract is ScriptableItemsAbstract scriptableItemsAbstact)
            {
                ItemInstance tempItemInstance = new ItemInstance
                {
                    scriptableItemsAbstract = scriptableItemsAbstact,
                    objectAbstract = objectAbstract
                    
                };
                return tempItemInstance;
            }

            if (objectAbstract.Type == ObjectType.Stack)
            {
                StackInstance stackInstance = new StackInstance() { objectAbstract = objectAbstract };
                return stackInstance;
            }
            // ObjectInstance tempObjectInstance = new ObjectInstance
            // {
            //     objectAbstract = objectAbstract
            // };
            return null;
        }
        public static ObjectInstance ObjectInstance(ObjectInstance objectAbstract)
        {
            if (objectAbstract is ItemInstance scriptableItemsAbstact)
            {
               
                return scriptableItemsAbstact;
            }
            
            return objectAbstract;
        }
        
    }
}