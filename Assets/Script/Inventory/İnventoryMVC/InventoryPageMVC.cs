using System;
using System.Collections.Generic;
using Game.Components.EnvanterSistemiTest;
using Game.Extensions.Unity;
using Unity.Mathematics;
using UnityEngine;

namespace Script.Inventory.İnventoryMVC
{
    public class InventoryPageMvc:MonoBehaviour
    {
        // ReSharper disable once InconsistentNaming
        [SerializeField] private ObjectDatas _objects;
        

        [Serializable]
        public class ObjectDatas : UnityDictionary<int2, ObjectController> { }
        
        private float _width;
        private float _height; 
        public int rowCount=5;
        public int columnCount=9;
        public void Awake()
        {
            var rectTransform = GetComponent<RectTransform>();
            _width = rectTransform.rect.width/rowCount;
            _height = rectTransform.rect.height/columnCount;
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
        public bool CanGetObject(IInventorObjectable inventorObjectable,int howMany)
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
        public bool ControlCanAdd(int2 rowAndColumnCount, IInventorObjectable inventorObjectable,int howMany)
        {
            int weightInInventory = inventorObjectable.GetWeightInInventory();
            if (weightInInventory + rowAndColumnCount.y> columnCount)
            {
                return false;
            }

            if ( _objects[rowAndColumnCount] == null)
            {
                if (weightInInventory == 1)
                {
                    AddScriptableObjectInPage(inventorObjectable, howMany, inventorButtons[i]);
                    return true;
                }
            }
            
                
            _objects.Keys[]
            if (inventorButtons[i].inventorObjectAble == null)
            {
                if (weightInInventory == 1)
                {
                    AddScriptableObjectInPage(inventorObjectable, howMany, inventorButtons[i]);
                    return true;
                }
                else if (i + 1 < inventorButtons.Length && inventorButtons[i + 1].inventorObjectAble == null)
                {
                    if ((i + 1) % 9 != 0)
                    {
                        if (weightInInventory == 2)
                        {
                            AddScriptableObjectInButton(inventorObjectable, inventorButtons[i + 1]);
                            AddScriptableObjectInPage(inventorObjectable, howMany, inventorButtons[i]);
                            return true;
                        }

                        if (i + 2 < inventorButtons.Length && (i + 2) % 9 != 0)
                        {
                            if (weightInInventory == 3 && inventorButtons[i + 2].inventorObjectAble == null)
                            {
                                AddScriptableObjectInButton(inventorObjectable, inventorButtons[i + 1]);
                                AddScriptableObjectInButton(inventorObjectable, inventorButtons[i + 2]);
                                AddScriptableObjectInPage(inventorObjectable, howMany, inventorButtons[i]);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}