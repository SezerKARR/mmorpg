using System;
using System.Collections.Generic;
using System.Linq;
using Game.Extensions.Unity;
using Script.Inventory.Objects;
using Script.ScriptableObject.Prefab;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Script.Inventory
{
    public class InventoryPage:MonoBehaviour
    {
        
        // ReSharper disable once InconsistentNaming
        [SerializeField] RectTransform _buttonPanel;
        [SerializeField] private ObjectDatas _objects;
        [Serializable]
        public class ObjectDatas : UnityDictionary<int2, ObjectController> { }

        public ItemPrefabList objectsPrefab;
        private float _width;
        private float _height; 
        public int rowCount=5;
        public int columnCount=9;
        private ObjectController _currentObjectController;
        
        
        public void Awake()
        { 
            
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
            foreach (var item in _objects.Where(entry => 
                         entry.Value.Model.ObjectAbstract == inventorObjectable).ToList())
            {
                // Gerekli işlemi yap
                int newCount = item.Value.howMany + howMany;

                if (newCount <= item.Value.Model.StackLimit)
                {
                    item.Value.UpdateCount(newCount); // Güncelleme işlemi
                    return true; // İlk eşleşmede işlem yap ve döngüden çık
                }
            }
            return false;
        }
        public bool CanGetObject(ObjectAbstract inventorObjectable,int howMany)
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if( ControlCanAdd(new int2(i,j), inventorObjectable, howMany))
                        return true;
                }
                
            }
            return false;
        }
        public bool ControlCanAdd(int2 rowAndColumnCount, ObjectAbstract inventorObjectable,int howMany)
        {
            int weightInInventory = inventorObjectable.weightInInventory;
            if (weightInInventory + rowAndColumnCount.y> columnCount)
            {
                return false;
            }

            if ( !_objects.ContainsKey((rowAndColumnCount)) )
            {
                if (weightInInventory == 1)
                {
                    AddScriptableObjectInPage(rowAndColumnCount, howMany,inventorObjectable);
                    
                    return true;
                }
                else if (weightInInventory + 1 + rowAndColumnCount.y <= columnCount &&
                         !_objects.ContainsKey(new int2(rowAndColumnCount.x , rowAndColumnCount.y+1)) )
                {
                    
                    if (weightInInventory == 2)
                    {
                        AddScriptableObjectInPage(rowAndColumnCount, howMany,inventorObjectable);
                    
                        return true;
                    }
                    else if (weightInInventory + 2 + rowAndColumnCount.y <= columnCount &&
                             !_objects.ContainsKey(new int2(rowAndColumnCount.x , rowAndColumnCount.y+2)))
                    {
                    
                        if (weightInInventory == 3)
                        {
                            AddScriptableObjectInPage(rowAndColumnCount, howMany,inventorObjectable);
                    
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        void AddScriptableObjectInPage(int2 cellInt2 , int howMany,ObjectAbstract iInventorObjectable)
        {
            CreateObjectModel(cellInt2, iInventorObjectable, howMany);
            for (int i = 0; i < iInventorObjectable.weightInInventory; i++)
            {
                _objects[ new int2(cellInt2.x, cellInt2.y + i)] = _currentObjectController;
            }

            _currentObjectController = null;
        }
        void CreateObjectModel(int2 cellInt2, ObjectAbstract inventorObjectable, int howMany)
        {
            GameObject objectControllerGameObject=null;
            if (objectsPrefab != null)
            {
                Debug.Log(inventorObjectable.Type);
                objectControllerGameObject= Instantiate(objectsPrefab.GetPrefabByType(inventorObjectable.Type));
                
               
            }
            
            _currentObjectController = objectControllerGameObject.GetComponent<ObjectController>();
            _currentObjectController.Place(inventorObjectable,this.transform,cellInt2,howMany,_height,_width);
        }
        
    }
}