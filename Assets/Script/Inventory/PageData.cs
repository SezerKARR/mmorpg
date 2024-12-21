using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Inventory
{
    [System.Serializable]
    public class ObjectsRow
    {
        // Dynamic array size based on row count, this array will be resized based on the columnCount from PageData
        public ObjectController[] objectController; 

        // Constructor to dynamically allocate memory for objectController
        public ObjectsRow(int columnCount)
        {
            objectController = new ObjectController[columnCount];
        }
    }
    [CreateAssetMenu( menuName = "ScriptableObject/PageData")]
    public class PageData:UnityEngine.ScriptableObject
    {
        [SerializeField]
        private int rowCount = 5; // Default value
        [SerializeField]
        private int columnCount = 9; // Default value
      
        // Array of ObjectsRow, now it's dynamic based on rowCount
        [FormerlySerializedAs("_cotroller")] public ObjectsRow[] cotroller;
        
        // Initialize rows based on dynamic rowCount and columnCount
        public void Initialize()
        {
                cotroller = new ObjectsRow[rowCount];
                for (int i = 0; i< rowCount; i++)
                {
                    cotroller[i] = new ObjectsRow(columnCount); // Initialize each row with the dynamic column count
                }
            
        }

        // Expose getter methods to access row and column counts
        public int RowCount => rowCount;
        public int ColumnCount => columnCount;
        
    }
}