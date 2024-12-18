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
{
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
        public bool ControlUnequip(ItemController unEquipObject,ItemController equipItem)
        {
            List<int2>temp = equipItem.cells;
            pageModels[equipItem.page].ResetButtons(equipItem.cells);
            if ( pageModels[equipItem.page].ControlUnequipSamePos(unEquipObject,temp,equipItem.ObjectAbstract.weightInInventory))
            {
                InventoryEvent.OnChange?.Invoke(unEquipObject,equipItem);
                return true;
            }
            
            foreach (PageModel pageModel in pageModels)
            {
                List<int2> tempCell = pageModel.ControlEmpty(unEquipObject.ObjectAbstract.weightInInventory, 1);
                if (tempCell!=null)
                {
                    
                    return true;
                }
                
            }
            pageModels[equipItem.page].AddObjectToPage(equipItem,temp);
            return false;   
        }

        
        public void Equip(ItemController itemController)
        {
            pageModels[itemController.page].ResetButtons(itemController.cells);
        }
        public void ChangePos(ObjectController objectController)
        {
            ObjectController temp = objectController;
            
        }

        
        public void Add(ObjectAbstract inventorObjectAble,int howMany)
        {

            if (CanAddStack(inventorObjectAble, howMany))return;
        
             CanAdd(inventorObjectAble, howMany);

        }
        public void CanAdd(ObjectAbstract inventorObjectAble, int howMany)
        {
            int pageIndex=0;
            foreach (PageModel page in pageModels)
            {
                pageIndex++;
                List<int2> cells = page.ControlEmpty(howMany, howMany);
                if (cells != null)
                {
                    InventoryEvent.OnAdd?.Invoke(cells,pageIndex);
                    return ;
                };
            
            }

          
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