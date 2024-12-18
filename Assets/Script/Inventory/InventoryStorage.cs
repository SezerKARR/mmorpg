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
    public class InventoryStorage : MonoBehaviour
    {
       public List<PageModel> pageModels=new List<PageModel>();
        public HaveObjects haveObjects=new HaveObjects();
        private float _height;
        private float _width;
        [Serializable]
        public class HaveObjects : UnityDictionary<ObjectAbstract, int> { };
        public ItemPrefabList objectsPrefab;
        [Inject] InventoryManager inventoryManager;
        private void Awake()
        { 
            
            ObjectEvents.OnPickUp += PickUp;
            RectTransform rectTransform = GetComponent<RectTransform>();
            _width = rectTransform.rect.width/inventoryManager.rowCount;
            _height = rectTransform.rect.height/inventoryManager.columnCount;
            
            
            
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
            pageModels[equipItem.page].ResetButtons(equipItem.cells);
            if ( pageModels[equipItem.page].ControlUnequipSamePos(unEquipObject,temp,equipItem.Model.WeightInInventory))
            {
                ChangePosition(unEquipObject,pageModels[equipItem.page],equipItem.cells);
                return true;
            }
            
            foreach (PageModel pageModel in pageModels)
            {
                List<int2> tempCell = pageModel.ControlEmpty(unEquipObject.Model.WeightInInventory, 1);
                if (tempCell!=null)
                {
                    
                    return true;
                }
                
            }
            pageModels[equipItem.page].AddObjectToPage(equipItem,temp);
            return false;   
        }

        public void ChangePosition(ItemController unEquipObject,PageModel pageModel,List<int2> cells)
        {
            pageModel.AddObjectToPage(unEquipObject,cells);
            unEquipObject.Place(this.transform,cells,_height,_width);
        }
        public void Equip(ItemController itemController)
        {
            pageModels[itemController.page].ResetButtons(itemController.cells);
        }
        public void ChangePos(ObjectController objectController)
        {
            ObjectController temp = objectController;
            
        }

        public void PickUp(ObjectAbstract objectToPickUp, int howMany, GameObject pickUpObject)
        {
            if (Add(objectToPickUp, howMany))
            {
                
                Destroy(pickUpObject);
            }
        }
        public bool Add(ObjectAbstract inventorObjectAble,int howMany)
        {

            if (CanAddStack(inventorObjectAble, howMany)) {return true;}
        
            return CanAdd(inventorObjectAble, howMany);

        }
        public bool CanAdd(ObjectAbstract inventorObjectAble, int howMany)
        {
            foreach (PageModel page in pageModels)
            {
                List<int2> cells = page.ControlEmpty(howMany, howMany);
                if (cells != null)
                {
                    CreateObjectModel(cells,inventorObjectAble, howMany,page);
                    return true;
                };
            
            }

            return false;
        }
        
        public void CreateObjectModel(List<int2> cellInt2, ObjectAbstract inventorObjectable, int howMany,PageModel pageModel)
        {
            GameObject objectControllerGameObject= Instantiate(objectsPrefab.GetPrefabByType(inventorObjectable.Type));
            
            objectControllerGameObject.GetComponent<ObjectController>().Place(inventorObjectable,this.transform,cellInt2,howMany,
                _height,_width);
            pageModel.AddObjectToPage(objectControllerGameObject.GetComponent<ObjectController>(),cellInt2);
            AddObjectsToInventory( inventorObjectable,howMany );
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