using System;
using System.Collections.Generic;
using Script.Inventory.Objects;
using Script.ScriptableObject;
using Unity.Mathematics;

namespace Script.Inventory
{ 
    public class InventoryStorage 
    {
        public List<PageModel> pageModels=new List<PageModel>();
        public HaveObjects haveObjects=new HaveObjects();
        
        [Serializable]
        public class HaveObjects : UnityDictionary<ObjectAbstract, int> { };

        public  InventoryStorage(PageController[] pageControllers,int rowCount,int columnCount)
        {
            foreach (PageController pageController in pageControllers)
            {
                pageController.PageModel.Initialize(rowCount, columnCount);
                pageModels.Add(pageController.PageModel);
            }
        }
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
            var (cells, pageIndex) = ControlEmptyCellAndPage(unEquipObject.ObjectAbstract, 1);

            if (pageIndex == -1)
                return false;

            ChangeItemPos(unEquipObject, cells, pageIndex);
            return true;
        }
        private void ChangeItemPos(ItemController unEquipObject, List<int2> cells, int page)
        {
           
            InventoryEvent.OnUneqipItem?.Invoke(unEquipObject,cells,page);
            AddObjectsToInventory(unEquipObject.ObjectAbstract,1);
            pageModels[page].AddObjectToPage(unEquipObject,cells);
            
        }
        public void ChangePos(ObjectController objectController,int2 cell,int pageIndex)
        {
            var cells = pageModels[pageIndex].ControlEmptyCell(cell, objectController.ObjectAbstract.weightInInventory,
                objectController.ObjectAbstract.howMany);
            if (cells != null)
            {
                pageModels[objectController.page].ResetButtons(objectController.cells);
                InventoryEvent.OnChangedObjectPosition?.Invoke(objectController,cells,pageIndex); 
                pageModels[pageIndex].AddObjectToPage(objectController,cells);
            }
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
            haveObjects[objectController.ObjectAbstract]-=objectController.ObjectAbstract.howMany;
        }
        
        public void Equip(ItemController itemController)
        {
            pageModels[itemController.page].ResetButtons(itemController.cells);
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
                }
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