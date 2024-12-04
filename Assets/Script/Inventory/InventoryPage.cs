
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
   
    public List<(ScriptableObject scriptableObject, int howMany)> itemsInPage = new List<(ScriptableObject scriptableObject, int howMany)>();
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

        
        
        buttonCount = inventorButtons.Length;
        inventoryColumnCount = GetComponent<GridLayoutGroup>().constraintCount;
        inventoryRowCount = buttonCount / inventoryColumnCount;
        print((buttonCount, inventoryColumnCount, inventoryRowCount));
        GetComponent<GridLayoutGroup>().cellSize = new Vector2(width / cellSizeRatio, width / cellSizeRatio);

    }
    public void GiveNumber(int number)
    {
        inventorButtons = GetComponentsInChildren<InventorButton>();
        this.pageCount = number;
        for (int i = 0; i < inventorButtons.Length; i++)
        {
            inventorButtons[i].ButtonCount = new Vector2Int(number, i);

        }
    }
    public bool CanGetObject(IViewable viewable,int howMany)
    {
        
        


        for (int i = 0; i < inventorButtons.Length; i++)
        {
            if( ControlCanAdd(i, viewable, howMany))
                return true;

            
        }
        return false;
    }
    public bool CanChangePosition(int inventorButtonPos)
    {
        return ControlCanAdd(inventorButtonPos, InventoryManager.Instance.selectedButton.inventorButton.scriptableObjectIWiewable, InventoryManager.Instance.selectedButton.inventorButton.howMany);
    }
    public bool ControlCanAdd(int i, IViewable viewable,int howMany)
    {
        int weightInInventory = viewable.GetWeightInInventory();
        if (weightInInventory + i > buttonCount)
        {
            return false;
        }
        if (inventorButtons[i].scriptableObjectIWiewable == null)
        {
            if (weightInInventory == 1)
            {
                AddScriptableObjectInPage(viewable, howMany, inventorButtons[i]);
                return true;
            }
            else if (i + 1 < inventorButtons.Length && inventorButtons[i + 1].scriptableObjectIWiewable == null)
            {
                if ((i + 1) % 9 != 0)
                {
                    if (weightInInventory == 2)
                    {
                        AddScriptableObjectInButton(viewable, inventorButtons[i + 1]);
                        AddScriptableObjectInPage(viewable, howMany, inventorButtons[i]);
                        return true;
                    }

                    if (i + 2 < inventorButtons.Length && (i + 2) % 9 != 0)
                    {
                        if (weightInInventory == 3 && inventorButtons[i + 2].scriptableObjectIWiewable == null)
                        {
                            AddScriptableObjectInButton(viewable, inventorButtons[i + 1]);
                            AddScriptableObjectInButton(viewable, inventorButtons[i + 2]);
                            AddScriptableObjectInPage(viewable, howMany, inventorButtons[i]);
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
        
        int t = inventorButtons[ResetButtonIndex].scriptableObjectIWiewable.GetWeightInInventory();
        for (int i = ResetButtonIndex; i< ResetButtonIndex + t; i++)
        {
            inventorButtons[ResetButtonIndex].ResetButton();
        }
       
    }
    public bool AddStack(IViewable wiewable, int howMany)
    {
        int i = 0;
        foreach (var itemSlot in inventorButtons.Where(item => item.scriptableObjectIWiewable == wiewable))
        {
            i++;
            int newCount = itemSlot.howMany + howMany;

            if (newCount <= wiewable.StackLimit())
            {

                itemSlot.AddStack(newCount); // Güncelleme lazým todo

                return true; // Ýlk eþleþen item için iþlem yapýlýr
            }
        }

        return false;
    }
    public void AddScriptableObjectInPage(IViewable wiewable,int howMany,InventorButton inventorButton)
    {
        Debug.Log("pivk upbastý2");
        itemsInPage.Add((wiewable.GetScriptableObject(),howMany));

        inventorButton.ChangeSprite( wiewable,howMany);
    }
    public void AddScriptableObjectInButton(IViewable wiewable,InventorButton inventorButton)
    {
        
        inventorButton.SetScriptableObject(wiewable);
        
        
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




