using Script.Inventory.Objects;
using Script.ScriptableObject;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Inventory
{
    namespace Script.Inventory
    {
        [System.Serializable]
        public class ObjectsRow
        {
            // Dynamic array size based on row count, this array will be resized based on the columnCount from PageData
            public ItemInstance[] objectController; 

            // Constructor to dynamically allocate memory for objectController
            public ObjectsRow(int columnCount)
            {
                objectController = new ItemInstance[columnCount];
            }
        }
        [CreateAssetMenu( menuName = "ScriptableObject/PageDatasadsa")]
        public class denemedata:UnityEngine.ScriptableObject
        {
       
            [FormerlySerializedAs("_cotroller")] public ObjectsRow[] cotroller;
        
            // Initialize rows based on dynamic rowCount and columnCount
            public void Initialize(int rowCount, int columnCount)
            {
            
                cotroller = new ObjectsRow[rowCount];
                for (int i = 0; i< rowCount; i++)
                {
                    cotroller[i] = new ObjectsRow(columnCount); // Initialize each row with the dynamic column count
                }
            
            }

            public int RowCount => cotroller.Length;
            public int ColumnCount => cotroller.Length>0? cotroller[0].objectController.Length:0;
        }
    }
}