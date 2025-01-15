using System;
using System.Collections.Generic;
using Script.Equipment;
using Script.Inventory;
using Script.Inventory.Objects;
using Script.InventorySystem.Objects;
using Script.InventorySystem.Page;
using Script.ObjectInstances;
using Script.ScriptableObject;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.InventorySystem.inventory
{
    [Serializable]
    public class CellsInfo
    {
        public List<int2> cells = new List<int2>();
        public int pageIndex;
    }
    [Serializable]
    public class InventoryStorage 
    {
        public InventoryStorageSo inventoryStorageSo;

       

        public void Initialize()
        {
            inventoryStorageSo.Initialize();

           
            
            foreach (var list in inventoryStorageSo.objects)
            {
                foreach (ObjectInstance objectInstance in list.Value.GetVariables())
                {
                    Debug.Log(objectInstance.objectAbstract);
                    Debug.Log(objectInstance);
                    InventoryEvent.OnInitializeStorageItem(objectInstance,objectInstance.cellsInfo);
                }
                
            }
        }

        

        
        public void AddObjectsToInventory(ObjectInstance objectInstance)
        {
            inventoryStorageSo.pageModels[objectInstance.cellsInfo.pageIndex].AddObjectToPage(objectInstance);
            inventoryStorageSo.AddItem(objectInstance);
            
        }
        private void RemoveObjectInventory(ObjectInstance removeObject)
        {
            inventoryStorageSo.objectInstances.Remove(removeObject);
            inventoryStorageSo.RemoveItem(removeObject);;
            
           
        }
        public CellsInfo ControlUnEquipCell(ItemInstance unEquipObject)
        {
            return ControlEmptyCellAndPage(unEquipObject.weightInInventory, unEquipObject.howMany);

        }
        // private void ChangeItemPos(ItemInstance changeInstance, CellsInfo cellsInfo)
        // {
        //    
        //     
        //     AddObjectsToInventory(changeInstance);
        //     InventoryEvent.
        //     inventoryStorageSo.pageModels[cellsInfo.pageIndex].AddObjectToPage(changeInstance.ObjectInstance);
        //     
        // }
        public CellsInfo GetChangePos(ObjectInstance objectInstance,int2 cell,int pageIndex)
        {
           return new CellsInfo{cells = inventoryStorageSo.pageModels[pageIndex].ControlEmptyCell(cell, objectInstance.weightInInventory,
               objectInstance.howMany),pageIndex = pageIndex};
            // if (cells != null)
            // {
            //     _inventoryStorageSo.pageModels[objectController.ObjectInstance.cellsInfo.pageIndex].ResetButtons(objectController.ObjectInstance.cellsInfo.cells);
            //     InventoryEvent.OnChangedObjectPosition?.Invoke(objectController,new CellsInfo{cells = cells,pageIndex = pageIndex}); 
            //     _inventoryStorageSo.pageModels[objectController.ObjectInstance.cellsInfo.pageIndex].AddObjectToPage(objectController.ObjectInstance);
            //     return true;
            // }
            // return false;
        }
        public bool ChangeItem(ItemInstance unequipped, ItemInstance equipped)
        {
            List<int2>temp = equipped.cellsInfo.cells;
            
            int page=equipped.cellsInfo.pageIndex;
            
            List<int2> unequipcells = inventoryStorageSo.pageModels[page].ControlUnequipSamePos(unequipped,temp, equipped.weightInInventory);
            
            if ( unequipcells!=null)
            {
                equipped.currentHolder.RemoveObject(equipped);

                InventoryEvent.OnCreateItem( unequipped, new CellsInfo() { cells = unequipcells, pageIndex = page });
                return true;
            }

            return IsCreateObjectEmptyCell(unequipped);
        }
        

        public void RemoveObject(ObjectInstance objectInstance)
        {
            
            inventoryStorageSo.pageModels[objectInstance.cellsInfo.pageIndex].ResetButtons(objectInstance.cellsInfo.cells);
            RemoveObjectInventory(objectInstance);
        }

       
        
        // public void Equip(ItemController itemController)
        // {
        //     pageModels[itemController.page].ResetButtons(itemController.cells);
        // }
        

        
        public void Add(ObjectInstance objectInstance)
        {
            if (!CanAddStack(objectInstance)) IsCreateObjectEmptyCell(objectInstance);
        }

        public bool IsCreateObjectEmptyCell(ObjectInstance objectInstance)
        {
            CellsInfo result = ControlEmptyCellAndPage(objectInstance.weightInInventory,objectInstance.howMany);
            if (result != null)
            {
                InventoryEvent.OnCreateItem?.Invoke(objectInstance,result);
                return true;
            }

            return false;
        }
        public CellsInfo ControlEmptyCellAndPage(int weightInInventory,int howMany)
        {
            foreach (PageModel page in inventoryStorageSo.pageModels)
            {
                
                List<int2> cells = page.ControlEmpty(weightInInventory, howMany);
                if (cells != null)
                {
                    return new CellsInfo { cells = cells, pageIndex = page.pageIndex };
                }
            }

            return null;
        }
        
        
        
        public bool CanAddStack(ObjectInstance objectInstance)
        {
            if (objectInstance.objectAbstract.stackLimit > 1)
            {
                foreach (PageModel page in inventoryStorageSo.pageModels)
                {

          
                    // if(page.AddStack(inventorObjectAble, howMany))
                    // {
                    //     return true;
                    // }
                }
            
            }
            return false;   
        }
        // public void DropObject()
        // {
        //     if (objectController.inventorObjectable is IDropable dropable)
        //     {
        //         if (dropable.GetPlayerCanDrop())
        //         {
        //             string confirmText = $"{dropable.GetDropName()} yere atmak istedi�ine emin misin";
        //             UIManager.Instance.OpenConfirm(confirmText,this);
        //         }
        //         else { Debug.Log("bu obje yere at�lamaz"); }
        //     }
        // }


        
    }
   
}