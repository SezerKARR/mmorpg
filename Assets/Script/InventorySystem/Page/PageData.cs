using Script.ObjectInstances;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.InventorySystem.Page
{
    [System.Serializable]
    public class ObjectsRow
    {
        public ObjectInstance[] objectController; 

        public ObjectsRow(int columnCount)
        {
            objectController = new ObjectInstance[columnCount];
        }
    }
    [CreateAssetMenu( menuName = "ScriptableObject/PageData")]
    public class PageData:UnityEngine.ScriptableObject
    {
       
       [FormerlySerializedAs("cotroller")] public ObjectsRow[] controller;
        
        public void Initialize(int rowCountInit, int columnCountInit)
        {
            if(rowCountInit==rowCount&&columnCountInit==columnCount)return;
            if (controller.Length==0)
            {
                controller = new ObjectsRow[rowCountInit];
                for (int i = 0; i< rowCountInit; i++)
                {
                    controller[i] = new ObjectsRow(columnCountInit); 
                }
            }
            
                
            
        }

        public int rowCount => controller.Length;
        public int columnCount => controller!=null? controller[0].objectController.Length:0;
    }
}