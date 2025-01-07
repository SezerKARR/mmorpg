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
        public InventoryStorageSo inventoryStorageSo;

        public  InventoryStorage(InventoryStorageSo storageSo)
        {
            inventoryStorageSo = storageSo;
            // foreach (PageModel pageModel in inventoryStorageSo.pageModels)
            // {
            //     pageModel.Initialize(storageSo.rowCount, storageSo.columnCount);
            // }
            foreach (ObjectInstance objectInstance in inventoryStorageSo.objectInstances)
            {
                InventoryEvent.OnInitializeStoreageItem(objectInstance);

            }
        }


        
        public void AddObjectsToInventory(ObjectInstance objectInstance)
        {
            inventoryStorageSo.objectInstances.Add(objectInstance);
            if (inventoryStorageSo.haveObjects.ContainsKey(objectInstance.objectAbstract))
            {
                // Eğer key mevcutsa, listenin sonuna item ekle
                inventoryStorageSo.haveObjects[objectInstance.objectAbstract]+=objectInstance.howMany;
                return;
            }
           
            inventoryStorageSo.haveObjects.Add(objectInstance.objectAbstract,objectInstance.howMany);
            
        }
        private void RemoveObjectInventory(ObjectInstance removeObject)
        {
            inventoryStorageSo.objectInstances.Remove(removeObject);
            inventoryStorageSo.haveObjects[removeObject.objectAbstract]-=removeObject.howMany;
            if (inventoryStorageSo.haveObjects[removeObject.objectAbstract] == 0)
            {
                inventoryStorageSo.haveObjects.Remove(removeObject.objectAbstract);
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
            inventoryStorageSo.pageModels[cellsInfo.pageIndex].AddObjectToPage(unEquipObject.ObjectInstance);
            
        }
        public bool IsCanChangePos(ObjectController objectController,int2 cell,int pageIndex)
        {
            List<int2> cells = inventoryStorageSo.pageModels[pageIndex].ControlEmptyCell(cell, objectController.ObjectInstance.weightInInventory,
                objectController.ObjectInstance.howMany);
            if (cells != null)
            {
                inventoryStorageSo.pageModels[objectController.ObjectInstance.cellsInfo.pageIndex].ResetButtons(objectController.ObjectInstance.cellsInfo.cells);
                InventoryEvent.OnChangedObjectPosition?.Invoke(objectController,new CellsInfo{cells = cells,pageIndex = pageIndex}); 
                inventoryStorageSo.pageModels[objectController.ObjectInstance.cellsInfo.pageIndex].AddObjectToPage(objectController.ObjectInstance);
                return true;
            }
            return false;
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
                AddObjectsToInventory(objectInstance);
                inventoryStorageSo.pageModels[result.pageIndex].AddObjectToPage(objectInstance);
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