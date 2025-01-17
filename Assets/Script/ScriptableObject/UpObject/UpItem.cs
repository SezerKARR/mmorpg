using System;
using Script.InventorySystem;
using Script.ObjectInstances;
using Script.UI;
using UnityEngine;
using UnityEngine.Events;

namespace Script.ScriptableObject.UpObject
{
    [CreateAssetMenu(menuName ="ScriptableObject/UpItemInstance")]
    public class UpItem : ObjectAbstract
    {
        public int upResultTrue;
        public int upResultFalse;
        public float changeForUp;
        public override ObjectType Type => ObjectType.UpItem;
        
       
      

        


        


        // public override ObjectType GetTypeController()
        // {
        //     return ObjectType.Up;
        // }

    
    }
}
