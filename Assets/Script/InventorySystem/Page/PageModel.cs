using System;
using System.Collections.Generic;
using System.IO;
using Script.InventorySystem.inventory;
using Script.InventorySystem.Objects;
using Script.ObjectInstances;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.InventorySystem.Page
{
    [Serializable]
    public class PageModel
    {
        [FormerlySerializedAs("PageData")] public PageData pageData;
        [FormerlySerializedAs("PageIndex")] public int pageIndex;
        private string path;

       

        public void Initialize(int rowCount, int columnCount)
        {
           
            pageData.Initialize(rowCount, columnCount); //todo if row or column count changed chang the page system
        }
        // private void OnApplicationQuit()
        // {
        //    
        //     string jsonData = JsonUtility.ToJson(pageData);
        //
        //     // 3. JSON'u dosyaya yaz
        //    
        //     File.WriteAllText(path, jsonData);
        // }

        private void InstantiatePageDate()
        {
            pageData = UnityEngine.ScriptableObject.CreateInstance<PageData>();
            

            // 2. JSON'a çevir
            string jsonData = JsonUtility.ToJson(pageData);
            
            // 3. JSON'u dosyaya yaz
           
            File.WriteAllText(path, jsonData);

            Debug.Log("Dosya kaydedildi: " + path);
        }
        private PageData LoadPageData( string path )
        {            Debug.Log(path);

            if (File.Exists(path))
            {
                
                string loadedJson = File.ReadAllText(path);
                PageData pageData = UnityEngine.ScriptableObject.CreateInstance<PageData>();
                JsonUtility.FromJsonOverwrite(loadedJson, pageData);
                Debug.Log("Yüklendi: Satır=" + pageData.controller.Length );
                return pageData;
            }
            return null;   
        }

        public float ColumnCount => pageData.columnCount;
        public float RowCount => pageData.rowCount;
        // public bool AddStack(ObjectAbstract inventorObjectable, int howMany)
        // {
        //     var filteredControllers = pageData.controller.Cast<ObjectController>()
        //         .Where(item => item != null && item.ObjectInstance == inventorObjectable)
        //         .ToList();
        //     foreach (var item in filteredControllers)
        //     {
        //         // Gerekli işlemi yap
        //         int newCount = item.ObjectInstance.howMany + howMany;
        //
        //         if (newCount <= item.ObjectInstance.stackLimit)
        //         {
        //             item.UpdateCount(newCount); // Güncelleme işlemi
        //             return true; // İlk eşleşmede işlem yap ve döngüden çık
        //         }
        //     }
        //     return false;
        // }
        public bool ChangePos(ObjectController inventorObjectable)
        {
            // List<int2> cells =ControlEmpty(inventorObjectable.Model.WeightInInventory, inventorObjectable.howMany);
            // if ( cells != null)
            // {
            //     AddObject(cells, inventorObjectable, howMany);
            //     return true;
            // }
            return false;
        }
        public CellsInfo ControlUnequipSamePos(ItemInstance unEquipObject, List<int2> tempcells ,int weightInInventory)
        {
            if (unEquipObject.weightInInventory <= weightInInventory)
            {

                return new CellsInfo()
                    { cells = tempcells.GetRange(0, unEquipObject.weightInInventory), pageIndex = pageIndex };
            }
            
            CellsInfo tempcel2 = ControlEmptyCell(new int2(tempcells[0].x, tempcells[^1 ].y+1),
                unEquipObject.weightInInventory -weightInInventory, 1);
            if( tempcel2!=null)
            {
                foreach (var cell in tempcel2.cells)
                {
                    tempcells.Add(cell);
                }

                return new CellsInfo() { cells = tempcells, pageIndex = pageIndex };

            }
            return null;
        }

        
        public CellsInfo  ControlEmpty(int weightInInventory,int howMany)
        {   
            
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    List<int2> cells=new List<int2>();
                    if (pageData.controller[i].objectController[j]==null||pageData.controller[i].objectController[j].objectAbstract == null )
                    {
                        cells.Add(new int2(i,j));
                        if (weightInInventory == 1)
                        {
                            return new CellsInfo() { cells = cells, pageIndex = pageIndex };
                        }

                        if (weightInInventory > 1)
                        {
                            CellsInfo tempCells = ControlEmptyCell(new int2(i, j + 1), weightInInventory - 1, howMany);
                            if (tempCells != null)
                            {
                                cells.AddRange(tempCells.cells);
                                return new CellsInfo() { cells = cells, pageIndex = pageIndex };

                            }
                            
                        }
                    }
                }
                
            }
            return null;
        }
        public  CellsInfo ControlEmptyCell(int2 rowAndColumnCount, int weightInInventory,int howMany)
        {
            if (weightInInventory + rowAndColumnCount.y>ColumnCount)
            {
                return  null;
            }
            List<int2> cells = new List<int2>(); 
            
            for (int i = 0; i < weightInInventory; i++)
            {
                // Nesnenin sütunu aşmaması gerektiğini kontrol et
                if (pageData.controller[rowAndColumnCount.x].objectController[rowAndColumnCount.y+i]==null||pageData.controller[rowAndColumnCount.x].objectController[rowAndColumnCount.y+i].objectAbstract ==null)
                {
                    cells.Add(new int2(rowAndColumnCount.x, rowAndColumnCount.y+i));
                    if (cells.Count == weightInInventory)
                    {
                        return new CellsInfo() { cells = cells, pageIndex = pageIndex };
                    }
                }
                else
                {
                    return null;
                }
                
            }
            return null;
            
           
        }
        public void AddObjectToPage(ObjectInstance objectInstance)
        {
            foreach (var cell in objectInstance.cellsInfo.cells)
            {
                pageData.controller[ cell.x].objectController[cell.y] = objectInstance;
            }
        }
        
        
        
      
        public void ResetButtons(List<int2> resetCells)
        {
            foreach (var cell in resetCells)
            {
                pageData.controller[ cell.x].objectController[cell.y] = null;
            }
        }

        
    }
}