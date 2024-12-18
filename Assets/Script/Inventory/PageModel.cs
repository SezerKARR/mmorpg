


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Script.Inventory.Objects;
using Unity.Mathematics;
using UnityEngine;

namespace Script.Inventory
{
    
  
    public class PageModel:MonoBehaviour
    {
        public PageData PageData;
        public int PageIndex;
       
        private void Start()
        {
            string path = Application.persistentDataPath + $"/{PageIndex}.json";
            if (!LoadPageData(path))
            {
                PageData = UnityEngine.ScriptableObject.CreateInstance<PageData>();
                PageData.Initialize();

                // 2. JSON'a çevir
                string jsonData = JsonUtility.ToJson(PageData);

                // 3. JSON'u dosyaya yaz
           
                File.WriteAllText(path, jsonData);

                Debug.Log("Dosya kaydedildi: " + path);
            }
           
        }
        private void OnApplicationQuit()
        {
            string path = Application.persistentDataPath + $"/{PageIndex}.json";
            string jsonData = JsonUtility.ToJson(PageData);

            // 3. JSON'u dosyaya yaz
           
            File.WriteAllText(path, jsonData);
        }

        private bool LoadPageData( string path )
        {
            if (File.Exists(path))
            {
                
                string loadedJson = File.ReadAllText(path);
                PageData = UnityEngine.ScriptableObject.CreateInstance<PageData>();
                JsonUtility.FromJsonOverwrite(loadedJson, PageData);
                Debug.Log("Yüklendi: Satır=" + PageData.RowCount + ", Sütun=" + PageData.ColumnCount);
                return true;
            }
            return false;   
        }

        public float ColumnCount => PageData.ColumnCount;
        public float RowCount => PageData.RowCount;
        public bool AddStack(ObjectAbstract inventorObjectable, int howMany)
        {
            var filteredControllers = PageData._cotroller.Cast<ObjectController>()
                .Where(item => item != null && item.Model.ObjectAbstract == inventorObjectable)
                .ToList();
            foreach (var item in filteredControllers)
            {
                // Gerekli işlemi yap
                int newCount = item.howMany + howMany;

                if (newCount <= item.Model.StackLimit)
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
        public bool ControlUnequipSamePos(ItemController unEquipObject, List<int2> tempcells ,int weightInInventory)
        {
            if (unEquipObject.Model.WeightInInventory <= weightInInventory)
            {
                List<int2> cells =new List<int2>();
                for (int i = 0; i < unEquipObject.Model.WeightInInventory; i++)
                {
                    cells.Add(tempcells[i]);
                }
                return true;
            }

            List<int2> tempcel2 = ControlEmptyCell(
                new int2(tempcells[0].x, tempcells[tempcells.Count-1 ].y+1),
                unEquipObject.Model.WeightInInventory -weightInInventory, 1);
            if( tempcel2!=null)
            {
                foreach (var VARIABLE in tempcel2)
                {
                    tempcells.Add(VARIABLE);
                }
                return true;
                
            }
            return false;
        }

        
        public List<int2>  ControlEmpty(int weightInInventory,int howMany)
        {   
            
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    List<int2> cells=new List<int2>();
                    if (PageData._cotroller[i].objectController[j] == null)
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
                if (PageData._cotroller[rowAndColumnCount.x].objectController[rowAndColumnCount.y+i] ==null)
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
        public void AddObjectToPage(ObjectController objectController,List<int2> celss)
        {
            foreach (var cell in celss)
            {
                PageData._cotroller[ cell.x].objectController[cell.y] = objectController;
            }
        }
        
        
        
      
        public void ResetButtons(List<int2> resetCells)
        {
            
            foreach (var cell in resetCells)
            {
                PageData._cotroller[ cell.x].objectController[cell.y] = null;
            }
        }
    }
}