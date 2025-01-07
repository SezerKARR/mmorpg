using Script.ScriptableObject;

namespace Script.ObjectInstances
{
    public class ObjectInstanceCreator
    {
        public static ObjectInstance ObjectInstance(ObjectAbstract objectAbstract)
        {
            ObjectInstance tempObjectInstance = new ObjectInstance
            {
                objectAbstract = objectAbstract
            };
            return tempObjectInstance;
        }
    }
}