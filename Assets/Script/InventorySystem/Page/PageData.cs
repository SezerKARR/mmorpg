using Script.ObjectInstances;
using UnityEngine;

namespace Script.Inventory.Page
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
       
       public ObjectsRow[] cotroller;
        
        public void Initialize(int rowCountInit, int columnCountInit)
        {
            
                cotroller = new ObjectsRow[rowCount];
                for (int i = 0; i< rowCount; i++)
                {
                    cotroller[i] = new ObjectsRow(columnCount); 
                }
            
        }

        public int rowCount => cotroller.Length;
        public int columnCount => cotroller.Length>0? cotroller[0].objectController.Length:0;
    }
}