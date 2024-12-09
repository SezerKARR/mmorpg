
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPage : MonoBehaviour
{
    public static Sprite sprite;
    public  InventorButton[] inventorButtons;
   
    private int pageCount;
    private int buttonCount;
    private int inventoryColumnCount;
    private int inventoryRowCount;
    private float cellSizeRatio = 5.085714285714286f;
    //public static 
    // private int x=5;
    private static int y;
    private void Awake()
    {
        RectTransform rectTransform = this.GetComponent<RectTransform>();

        // Boyutlarý alýyoruz
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        
        
       
        GetComponent<GridLayoutGroup>().cellSize = new Vector2(width / cellSizeRatio, width / cellSizeRatio);

    }
    public void GiveNumber(int number)
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
    }
    public bool CanGetObject(IInventorObjectable inventorObjectable,int howMany)
    {
        
        


        for (int i = 0; i < inventorButtons.Length; i++)
        {
            if( ControlCanAdd(i, inventorObjectable, howMany))
                return true;

            
        }
        return false;
    }
    public bool CanChangePosition(int inventorButtonPos,IInventorObjectable inventorObjectable,int selectedButtonhowMany)
    {
        return ControlCanAdd(inventorButtonPos, inventorObjectable, selectedButtonhowMany);
    }
    public bool ControlCanAdd(int i, IInventorObjectable inventorObjectable,int howMany)
    {
        int weightInInventory = inventorObjectable.GetWeightInInventory();
        if (weightInInventory + i > buttonCount)
        {
            return false;
        }
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
    public int FindButton(InventorButton inventorButton)
    {
        return Array.FindIndex(inventorButtons, button => button == inventorButton);
    }
   
    public void ResetButtons(int ResetButtonIndex)
    {
        
        int t = inventorButtons[ResetButtonIndex].inventorObjectAble.GetWeightInInventory();
        for (int i = ResetButtonIndex; i< ResetButtonIndex + t; i++)
        {
            inventorButtons[i].ResetButton();
        }
       
    }
    public bool AddStack(IInventorObjectable inventorObjectAble, int howMany)
    {
        int i = 0;
        foreach (var itemSlot in inventorButtons.Where(item => item.inventorObjectAble == inventorObjectAble))
        {
            i++;
            int newCount = itemSlot.howMany + howMany;

            if (newCount <= inventorObjectAble.GetStackLimit())
            {

                itemSlot.AddStack(newCount); // Güncelleme lazým todo

                return true; // Ýlk eþleþen item için iþlem yapýlýr
            }
        }

        return false;
    }
    public void AddScriptableObjectInPage(IInventorObjectable inventorObjectAble,int howMany,InventorButton inventorButton)
    {

        inventorButton.ChangeSprite(inventorObjectAble);
        inventorButton.AddStack(howMany);

    }
    public void AddScriptableObjectInButton(IInventorObjectable inventorObjectAble, InventorButton inventorButton)
    {
        
        inventorButton.SetScriptableObject(inventorObjectAble);
        
        
    }
    
    private void changeSprite(int spriteLength, Sprite sprite, InventorButton button)
    {
            //button.ChangeSprite(spriteLength, sprite);
        }
    public void ChangeLocationInventoryObject(ScriptableObject scriptableObject)
    {
        remove(scriptableObject);
        //add(scriptableObject);
    }
    public void remove(ScriptableObject getObject)
    {
        if (getObject is UpgradeItemsSO upgradeItem)
        {
            //itemsInPage.Remove((getObject,));
            return;
        }

    }

}




