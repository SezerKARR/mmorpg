using System;
using System.Collections.Generic;
using Script.Inventory.Objects;
using Script.ScriptableObject.Prefab;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using Object = UnityEngine.Object;

namespace Script.Inventory
{ class pageAndCells
    {
        List<int> cells = new List<int>();
        int page;
    }
    public class InventoryStorage 
    {
        public List<PageModel> pageModels=new List<PageModel>();
        public HaveObjects haveObjects=new HaveObjects();
        
        [Serializable]
        public class HaveObjects : UnityDictionary<ObjectAbstract, int> { };
       
        public void AddObjectsToInventory(ObjectAbstract inventorObjectable, int howMany)
        {
            if (haveObjects.ContainsKey(inventorObjectable))
            {
                // Eğer key mevcutsa, listenin sonuna item ekle
                haveObjects[inventorObjectable]+=howMany;
                return;
            }
            haveObjects.Add(inventorObjectable, howMany);
        }
        public bool ControlUnequip(ItemController unEquipObject)
        {
            var result = ControlEmptyCellAndPage(unEquipObject.ObjectAbstract, 1);
            if (result.pageIndex != -1)
            {
                ChangeItemPos(unEquipObject, result.cells, result.pageIndex);
                return true;
            }

            return false;
        }
        private void ChangeItemPos(ItemController unEquipObject, List<int2> cells, int page)
        {
           
            InventoryEvent.OnUneqipItem?.Invoke(unEquipObject,cells,page);
            AddObjectsToInventory(unEquipObject.ObjectAbstract,1);
            pageModels[page].AddObjectToPage(unEquipObject,cells);
            
        }

        public bool ControlUnequipForEquip(ItemController unEquipObject, ItemController equipItem)
        {
            List<int2>temp = equipItem.cells;
            int page=equipItem.page;
            RemoveObject(equipItem);
            List<int2> unequipcells = pageModels[equipItem.page].ControlUnequipSamePos(unEquipObject,temp, equipItem.ObjectAbstract.weightInInventory);
            if ( unequipcells!=null)
            {
                ChangeItemPos(unEquipObject,unequipcells,page);
                return true;
            }
            
            return ControlUnequip(unEquipObject);
        }

        public void RemoveObject(ObjectController objectController)
        {
            pageModels[objectController.page].ResetButtons(objectController.cells);
            haveObjects[objectController.ObjectAbstract]-=objectController.howMany;
        }
        
        public void Equip(ItemController itemController)
        {
            pageModels[itemController.page].ResetButtons(itemController.cells);
        }
        public void ChangePos(ObjectController objectController,int2 cell,int pageIndex)
        {
            ObjectController temp = objectController;
            var result = pageModels[pageIndex].ControlEmptyCell(cell, objectController.ObjectAbstract.weightInInventory,
                objectController.howMany);
            if (result != null)
            {
                RemoveObject(objectController);
                InventoryEvent.OnAdd?.Invoke(result,pageIndex);
                return ;
            }
        }

        
        public bool Add(ObjectAbstract inventorObjectAble,int howMany)
        {

            if (CanAddStack(inventorObjectAble, howMany))return true;
            var result = ControlEmptyCellAndPage(inventorObjectAble, howMany);
            if (result.pageIndex != -1)
            {
                InventoryEvent.OnAdd?.Invoke(result.cells,result.pageIndex);
                return true;
            }

            return false;


        }
        public (List<int2> cells ,int pageIndex) ControlEmptyCellAndPage(ObjectAbstract inventorObjectAble, int howMany)
        {
            foreach (PageModel page in pageModels)
            {
                
                List<int2> cells = page.ControlEmpty(inventorObjectAble.weightInInventory, howMany);
                if (cells != null)
                {
                    return (cells,page.pageIndex);
                };
            }
            return (null,-1);
        }
        
        
        
        public bool CanAddStack(ObjectAbstract inventorObjectAble, int howMany)
        {
            if (inventorObjectAble.stackLimit > 1)
            {
                foreach (PageModel page in pageModels)
                {

          
                    if(page.AddStack(inventorObjectAble, howMany))
                    {
                        return true;
                    }
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