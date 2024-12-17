


using System.Collections.Generic;
using System.Linq;
using Script.Inventory.Objects;
using Unity.Mathematics;

namespace Script.Inventory
{
    
  
    public class PageModel
    {
        public PageData pageData;
        public PageController pageController;
        public float ColumnCount => pageData.ColumnCount;
        public float RowCount => pageData.RowCount;
        public bool AddStack(ObjectAbstract inventorObjectable, int howMany)
        {
            var filteredControllers = pageData._cotroller.Cast<ObjectController>()
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
        public bool ControlAdd(ObjectAbstract inventorObjectable, int howMany)
        {
            List<int2> cells =ControlEmpty(inventorObjectable.weightInInventory, howMany);
            if ( cells != null)
            {
                CreateObjectModel(cells, inventorObjectable, howMany);
                return true;
            }
            return false;
        }
        // public List<int2> ControlUnequip(ItemController inventorObjectable, int howMany)
        // {
        //     return ControlEmpty(inventorObjectable.Model.WeightInInventory, howMany);
        //     if ( cells != null)
        //     {
        //         ChangeControllerPos(inventorObjectable, cells);
        //         return true;
        //     }
        //     return false;
        // }
        // private void ChangeControllerPos(ObjectController inventorObjectable,List<int2> cells)
        // {
        //     AddObjectToPage(inventorObjectable, cells);
        //     
        // }
        
        public bool ControlUnequipSamePos(ItemController unEquipObject, List<int2> tempcells ,int weightInInventory)
        {
            if (unEquipObject.Model.WeightInInventory <= weightInInventory)
            {
                List<int2> cells =new List<int2>();
                for (int i = 0; i < unEquipObject.Model.WeightInInventory; i++)
                {
                    cells.Add(tempcells[i]);
                }
                
                ChangeControllerPos(unEquipObject,cells);
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
                ChangeControllerPos(unEquipObject,tempcells);
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
                    if (pageData._cotroller[i].objectController[j] == null)
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
                if (pageData._cotroller[rowAndColumnCount.x].objectController[rowAndColumnCount.y+i] ==null)
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
                pageData._cotroller[ cell.x].objectController[cell.y] = objectController;
            }
        }
        
        
      
        public void ResetButtons(List<int2> resetCells)
        {
            
            foreach (var cell in resetCells)
            {
                pageData._cotroller[ cell.x].objectController[cell.y] = null;
            }
        }
    }
}