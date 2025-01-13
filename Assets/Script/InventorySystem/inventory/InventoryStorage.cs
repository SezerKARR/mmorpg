using System;
using System.Collections.Generic;
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

        public InventoryStorage(InventoryStorageSo storageSo)
        {
            inventoryStorageSo = storageSo;

            Initialize();

        }

        public void Initialize()
        {
            foreach (var pageModel in inventoryStorageSo.pageModels)  
            {
                pageModel.Initialize(rowCount: inventoryStorageSo.rowCount, columnCount: inventoryStorageSo.columnCount);
            }
            // foreach (ItemInstance objectInstance in InventoryStorageSo.itemInstances)  
            // {
            //     InventoryEvent.OnInitializeStoreageItem(ObjectInstanceCreator.ObjectInstance(objectInstance));
            // }
            inventoryStorageSo.İnitialize();
        }

        

        
        public void AddObjectsToInventory(ObjectInstance objectInstance)
        {
            inventoryStorageSo.pageModels[objectInstance.cellsInfo.pageIndex].AddObjectToPage(objectInstance);
            inventoryStorageSo.objects[objectInstance.type].Add(objectInstance);
            
           
            
        }
        private void RemoveObjectInventory(ObjectInstance removeObject)
        {
            inventoryStorageSo.objectInstances.Remove(removeObject);
            inventoryStorageSo.objects[removeObject.type].Add(removeObject);
            
           
        }
        public CellsInfo ControlUnEquipCell(ItemInstance unEquipObject)
        {
            return ControlEmptyCellAndPage(unEquipObject.weightInInventory, unEquipObject.howMany);

        }
        private void ChangeItemPos(ItemController unEquipObject, CellsInfo cellsInfo)
        {
           
            
            AddObjectsToInventory(unEquipObject.ObjectInstance);
            InventoryEvent.OnUnEquipItem?.Invoke(unEquipObject,cellsInfo);
            inventoryStorageSo.pageModels[cellsInfo.pageIndex].AddObjectToPage(unEquipObject.ObjectInstance);
            
        }
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

        public bool IsCanChangeItem(ItemInstance unEquipObject, ItemInstance equipItem)
        {
            List<int2>temp = equipItem.cellsInfo.cells;
            int page=equipItem.cellsInfo.pageIndex;
            List<int2> unequipcells = inventoryStorageSo.pageModels[page].ControlUnequipSamePos(unEquipObject,temp, equipItem.weightInInventory);
            if ( unequipcells!=null)
            {
                //ChangeItemPos(unEquipObject,new CellsInfo{cells = unequipcells,pageIndex=page});
                return true;
            }
            CellsInfo cellsInfo=ControlEmptyCellAndPage(unEquipObject.weightInInventory, 1);
            // return ControlUnEquipCell(unEquipObject);
            return true;
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
        

        
        public bool IsAdd(ObjectInstance objectInstance)
        {

            if (CanAddStack(objectInstance))return true;
            CellsInfo result = ControlEmptyCellAndPage(objectInstance.weightInInventory,objectInstance.howMany);
            if (result != null)
            {
                objectInstance.cellsInfo = result;
                InventoryEvent.OnItemPickUp?.Invoke(objectInstance);
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