using System;
using System.Collections.Generic;
using System.Linq;
using Script.Inventory;
using Script.Inventory.Objects;
using Script.ScriptableObject.Prefab;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
[System.Serializable]
public class ObjectsRow
{
    public ObjectController[] objectController=new ObjectController[9];
}
namespace Script.Inventory
{

//usage
    public class InventoryPage:MonoBehaviour
    {
        [SerializeField] RectTransform _buttonPanel;
        public List<List<float>> twoDimensionalList = new List<List<float>>();
        public ItemPrefabList objectsPrefab;
        private float _width;
        private float _height; 
        private ObjectController _currentObjectController;
        public static Action<ObjectAbstract,int> OnObjectAddToPage;
        public ObjectsRow[] _cotroller = new ObjectsRow[5];
        public int rowCount,columnCount;
        public void Awake()
        {
            rowCount = _cotroller.Length;
            columnCount = _cotroller[0].objectController.Length;
            _width = _buttonPanel.rect.width/rowCount;
            _height = _buttonPanel.rect.height/columnCount;
        }
        /*public void GiveNumber(int number)
        {
            inventorButtons = GetComponentsInChildren<InventorButton>();

            buttonCount = inventorButtons.Length;
            inventoryColumnCount = GetComponent<GridLayoutGroup>().constraintCount;
            inventoryRowCount = buttonCount / inventoryColumnCount;
            print((buttonCount, inventoryColumnCount, inventoryRowCount));
            this.pageCount = number;
            for (int i = 0; i < inventorButtons.Length; i++)
            {
                inventorButtons[i].ButtonPos = new Vector2Int(number, i);

            }
        }*/
        
        public bool AddStack(ObjectAbstract inventorObjectable, int howMany)
        {
            var filteredControllers = _cotroller.Cast<ObjectController>()
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

        public void ClosePage()
        {
            CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false; 
            canvasGroup.blocksRaycasts = false; 

        }
        public void OpenPage()
        {
            CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true; 
            canvasGroup.blocksRaycasts = true; 

        }
        public bool ControlChangePos(ItemController itemController)
        {
            List<int2> cells = ControlEmpty(itemController.itemModel.ObjectAbstract.weightInInventory, 1);
            if ( cells != null)
            {
                
                itemController.Place(this.transform,cells,_height,_width);
                return true;
            }
            return false;
        }

        
        public List<int2>  ControlEmpty(int weightInInventory,int howMany)
        {   
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    List<int2> celss = ControlEmptyCell(new int2(i, j), weightInInventory, howMany);
                    if (celss != null) return celss ;
                }
                
            }
            return null;
        }
        public  List<int2> ControlEmptyCell(int2 rowAndColumnCount, int weightInInventory,int howMany)
        {
            if (weightInInventory + rowAndColumnCount.y>columnCount)
            {
                return  null;
            }
            List<int2> cells = new List<int2>(); 
            
            for (int i = 0; i < weightInInventory; i++)
            {
                // Nesnenin sütunu aşmaması gerektiğini kontrol et
                if (_cotroller[rowAndColumnCount.x].objectController[rowAndColumnCount.y] ==null)
                {
                    cells.Add(new int2(rowAndColumnCount.x, rowAndColumnCount.y+i));
                }
                else
                {
                    return null;
                }
                
            }

            return cells;
            
            // if ( !_objects.ContainsKey((rowAndColumnCount)) )
            // {
            //     if (weightInInventory == 1)
            //     {
            //         
            //         
            //         return true;
            //     }
            //     else if (weightInInventory + 1 + rowAndColumnCount.y <= columnCount &&
            //              !_objects.ContainsKey(new int2(rowAndColumnCount.x , rowAndColumnCount.y+1)) )
            //     {
            //         
            //         if (weightInInventory == 2)
            //         {
            //            
            //         
            //             return true;
            //         }
            //         else if (weightInInventory + 2 + rowAndColumnCount.y <= columnCount &&
            //                  !_objects.ContainsKey(new int2(rowAndColumnCount.x , rowAndColumnCount.y+2)))
            //         {
            //         
            //             if (weightInInventory == 3)
            //             {
            //               
            //         
            //                 return true;
            //             }
            //         }
            //     }
            // }
            
        }

        public void AddObjectToPage(ObjectController objectController,List<int2> celss)
        {
            foreach (var cell in celss)
            {
                _cotroller[ cell.x].objectController[cell.y] = objectController;
            }
        }
        
        
        public void CreateObjectModel(List<int2> cellInt2, ObjectAbstract inventorObjectable, int howMany)
        {
            GameObject objectControllerGameObject= Instantiate(objectsPrefab.GetPrefabByType(inventorObjectable.Type));
            
            objectControllerGameObject.GetComponent<ObjectController>().Place(inventorObjectable,this.transform,cellInt2,howMany,
                _height,_width);
            AddObjectToPage(objectControllerGameObject.GetComponent<ObjectController>(),cellInt2);
            OnObjectAddToPage?.Invoke(inventorObjectable,howMany);
        }
        public void ResetButtons(List<int2> resetCells)
        {
            foreach (var cell in resetCells)
            {
                _cotroller[ cell.x].objectController[cell.y] = null;
            }
    
        }
        
    }
}