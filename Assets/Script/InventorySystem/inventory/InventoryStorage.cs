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
        private InventoryStorageSo _inventoryStorageSo;

        public  InventoryStorage(InventoryStorageSo storageSo)
        {
            _inventoryStorageSo = storageSo;
            foreach (var pageModel in storageSo.pageModels)
            {
                pageModel.Initialize(rowCount:storageSo.rowCount,columnCount:storageSo.columnCount);
            }
            // foreach (PageModel pageModel in inventoryStorageSo.pageModels)
            // {
            //     pageModel.Initialize(storageSo.rowCount, storageSo.columnCount);
            // }
            foreach (ObjectInstance objectInstance in storageSo.objectInstances)
            {
                InventoryEvent.OnInitializeStoreageItem(objectInstance);

            }

        }

        
        public void AddObjectsToInventory(ObjectInstance objectInstance)
        {
            _inventoryStorageSo.pageModels[objectInstance.cellsInfo.pageIndex].AddObjectToPage(objectInstance);

            _inventoryStorageSo.objectInstances.Add(objectInstance);
            if (_inventoryStorageSo.haveObjects.ContainsKey(objectInstance.objectAbstract))
            {
                _inventoryStorageSo.haveObjects[objectInstance.objectAbstract]+=objectInstance.howMany;
                return;
            }
           
            _inventoryStorageSo.haveObjects.Add(objectInstance.objectAbstract,objectInstance.howMany);
            
        }
        private void RemoveObjectInventory(ObjectInstance removeObject)
        {
            _inventoryStorageSo.objectInstances.Remove(removeObject);
            _inventoryStorageSo.haveObjects[removeObject.objectAbstract]-=removeObject.howMany;
            if (_inventoryStorageSo.haveObjects[removeObject.objectAbstract] == 0)
            {
                _inventoryStorageSo.haveObjects.Remove(removeObject.objectAbstract);
            }
           
        }
        public CellsInfo ControlUnEquipCell(ItemInstance unEquipObject)
        {
            return ControlEmptyCellAndPage(unEquipObject.weightInInventory, unEquipObject.howMany);

        }
        private void ChangeItemPos(ItemController unEquipObject, CellsInfo cellsInfo)
        {
           
            
            AddObjectsToInventory(unEquipObject.ObjectInstance);
            InventoryEvent.OnUnEquipItem?.Invoke(unEquipObject,cellsInfo);
            _inventoryStorageSo.pageModels[cellsInfo.pageIndex].AddObjectToPage(unEquipObject.ObjectInstance);
            
        }
        public CellsInfo GetChangePos(ObjectInstance objectInstance,int2 cell,int pageIndex)
        {
           return new CellsInfo{cells = _inventoryStorageSo.pageModels[pageIndex].ControlEmptyCell(cell, objectInstance.weightInInventory,
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

        // public bool IsCanChangeItem(ItemController unEquipObject, ItemController equipItem)
        // {
        //     List<int2>temp = equipItem.ObjectInstance.cellsInfo.cells;
        //     int page=equipItem.ObjectInstance.cellsInfo.pageIndex;
        //     List<int2> unequipcells = pageModels[page].ControlUnequipSamePos(unEquipObject,temp, equipItem.ObjectInstance.weightInInventory);
        //     if ( unequipcells!=null)
        //     {
        //         ChangeItemPos(unEquipObject,new CellsInfo{cells = unequipcells,pageIndex=page});
        //         return true;
        //     }
        //     CellsInfo cellsInfo=ControlEmptyCellAndPage(unEquipObject.ObjectInstance.weightInInventory, 1);
        //     return ControlUnEquipCell(unEquipObject);
        // } todo ekipman çıkarma

        public void RemoveObject(ObjectInstance objectInstance)
        {
            _inventoryStorageSo.pageModels[objectInstance.cellsInfo.pageIndex].ResetButtons(objectInstance.cellsInfo.cells);
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
            foreach (PageModel page in _inventoryStorageSo.pageModels)
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
                foreach (PageModel page in _inventoryStorageSo.pageModels)
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