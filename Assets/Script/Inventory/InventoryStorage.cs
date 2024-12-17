using System;
using System.Collections.Generic;
using Script.Inventory.Objects;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Script.Inventory
{
    public class InventoryStorage:MonoBehaviour
    {
        public PageModel[] PageModels;
        public HaveObjects haveObjects=new HaveObjects();
        private float _height;
        private float _width;

        [Serializable]
        public class HaveObjects : UnityDictionary<ObjectAbstract, int> { };

        private void Awake()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            _width = rectTransform.rect.width/PageModels[];
            _height = rectTransform.rect.height/columnCount;
            int i = 0;
            foreach (var VARIABLE in InventoryManager.inventoryPage)
            {
                PageModels[i] = VARIABLE.PageModel;
                i++;
            }
            PageController.OnObjectAddToPage += AddObjectsToInventory;
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
        public bool ControlUnequip(ItemController unEquipObject,ItemController equipItem)
        {
            List<int2>temp = equipItem.cells;
            PageModels[equipItem.page].ResetButtons(equipItem.cells);
            if ( PageModels[equipItem.page].ControlUnequipSamePos(unEquipObject,temp,equipItem.Model.WeightInInventory))
            {
                return true;
            }
            
            foreach (PageModel pageModel in PageModels)
            {
                List<int2> tempCell = pageModel.ControlEmpty(unEquipObject.Model.WeightInInventory, 1);
                if (tempCell!=null)
                {
                    
                    return true;
                }
                
            }
            PageModels[equipItem.page].AddObjectToPage(equipItem,temp);
            return false;   
        }

        public void ChangePosition(ItemController unEquipObject,PageModel pageModel,List<int2> cells)
        {
            pageModel.AddObjectToPage(unEquipObject,cells);
            unEquipObject.Place(this.transform,cells,_height,_width);
        }
        public void Equip(ItemController itemController)
        {
            PageModels[itemController.page].ResetButtons(itemController.cells);
        }
        public void ChangePos(ObjectController objectController)
        {
            ObjectController temp = objectController;
            
        }
        public bool Add(ObjectAbstract inventorObjectAble,int howMany)
        {

            if (CanAddStack(inventorObjectAble, howMany)) {return true;}
        
            return CanAdd(inventorObjectAble, howMany);

        }
        public bool CanAdd(ObjectAbstract inventorObjectAble, int howMany)
        {
            foreach (PageModel page in PageModels)
            {
           
                if( page.ControlAdd(inventorObjectAble, howMany)){return true;};
            
            }

            return false;
        }
        public bool CanAddStack(ObjectAbstract inventorObjectAble, int howMany)
        {
            if (inventorObjectAble.stackLimit > 1)
            {
                foreach (PageModel page in PageModels)
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