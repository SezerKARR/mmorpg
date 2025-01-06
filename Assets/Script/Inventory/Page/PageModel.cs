using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Script.Inventory.Objects;
using Script.Inventory.Script.Inventory;
using Script.ScriptableObject;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Inventory
{
    
    public class PageModel:MonoBehaviour
    {
        [FormerlySerializedAs("PageData")] public PageData pageData;
        public denemedata denemedata;
        [FormerlySerializedAs("PageIndex")] public int pageIndex;
        private string path;

       

        public void Initialize(int rowCount, int columnCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                
                for (int j = 0; j < columnCount; j++)
                {
                    if (pageData.cotroller[i].objectController[j] != null)
                    {
                        List<int2> columns = new List<int2>();
                        columns.Add(new int2(i, j));
                        for (int k = 0; k < pageData.cotroller[i].objectController[j].weightInInventory - 1; k++)
                        {
                            j++;

                            columns.Add(new int2(i, j));
                        }

                        InventoryEvent.OnCreateItem?.Invoke(columns, pageIndex,
                            pageData.cotroller[i].objectController[j],
                            pageData.cotroller[i].objectController[j].howMany);
                    }

                }
            }
            
            
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
                Debug.Log("Yüklendi: Satır=" + pageData.cotroller.Length );
                return pageData;
            }
            return null;   
        }

        public float ColumnCount => pageData.ColumnCount;
        public float RowCount => pageData.RowCount;
        public bool AddStack(ObjectAbstract inventorObjectable, int howMany)
        {
            var filteredControllers = pageData.cotroller.Cast<ObjectController>()
                .Where(item => item != null && item.ObjectAbstract == inventorObjectable)
                .ToList();
            foreach (var item in filteredControllers)
            {
                // Gerekli işlemi yap
                int newCount = item.ObjectAbstract.howMany + howMany;

                if (newCount <= item.ObjectAbstract.stackLimit)
                {
                    item.UpdateCount(newCount); // Güncelleme işlemi
                    return true; // İlk eşleşmede işlem yap ve döngüden çık
                }
            }
            return false;
        }
        public bool ChangePos(ObjectController inventorObjectable)
        {
            // List<int2> cells =ControlEmpty(inventorObjectable.Model.WeightInInventory, inventorObjectable.howMany);
            // if ( cells != null)
            // {
            //     CreateObjectModel(cells, inventorObjectable, howMany);
            //     return true;
            // }
            return false;
        }
        public List<int2> ControlUnequipSamePos(ItemController unEquipObject, List<int2> tempcells ,int weightInInventory)
        {
            if (unEquipObject.ObjectAbstract.weightInInventory <= weightInInventory)
            {
               
                return tempcells.GetRange(0,unEquipObject.ObjectAbstract.weightInInventory);
            }
            
            List<int2> tempcel2 = ControlEmptyCell(
                new int2(tempcells[0].x, tempcells[^1 ].y+1),
                unEquipObject.ObjectAbstract.weightInInventory -weightInInventory, 1);
            if( tempcel2!=null)
            {
                foreach (var cell in tempcel2)
                {
                    tempcells.Add(cell);
                }
                return tempcells;
                
            }
            return null;
        }

        
        public List<int2>  ControlEmpty(int weightInInventory,int howMany)
        {   
            
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    List<int2> cells=new List<int2>();
                    if (pageData.cotroller[i].objectController[j] == null)
                    {
                        cells.Add(new int2(i,j));
                        if (weightInInventory == 1)
                        {
                            return cells;
                        }

                        if (weightInInventory > 1)
                        {
                            List<int2> tempCells = ControlEmptyCell(new int2(i, j + 1), weightInInventory - 1, howMany);
                            if (tempCells != null)
                            {
                                cells.AddRange(tempCells);
                                return cells;

                            }
                            
                        }
                    }
                }
                
            }
            return null;
        }
        public  List<int2> ControlEmptyCell(int2 rowAndColumnCount, int weightInInventory,int howMany)
        {
            if (weightInInventory + rowAndColumnCount.y>ColumnCount)
            {
                return  null;
            }
            List<int2> cells = new List<int2>(); 
            
            for (int i = 0; i < weightInInventory; i++)
            {
                // Nesnenin sütunu aşmaması gerektiğini kontrol et
                if (pageData.cotroller[rowAndColumnCount.x].objectController[rowAndColumnCount.y+i] ==null)
                {
                    cells.Add(new int2(rowAndColumnCount.x, rowAndColumnCount.y+i));
                    if (cells.Count == weightInInventory)
                    {
                        return cells;
                    }
                }
                else
                {
                    return null;
                }
                
            }
            return null;
            
           
        }
        public void AddObjectToPage(ObjectAbstract ObjectAbstract,List<int2> celss)
        {
            foreach (var cell in celss)
            {
                pageData.cotroller[ cell.x].objectController[cell.y] = ObjectAbstract;
                if(denemedata==null)return;
                denemedata.cotroller[cell.x].objectController[cell.y] = new ItemInstance{objectSo = ObjectAbstract};
            }
        }
        
        
        
      
        public void ResetButtons(List<int2> resetCells)
        {
            
            foreach (var cell in resetCells)
            {
                pageData.cotroller[ cell.x].objectController[cell.y] = null;
            }
        }

        
    }
}