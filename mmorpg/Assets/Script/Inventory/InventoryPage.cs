
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPage : MonoBehaviour
{
    public static Sprite sprite;
    private InventorButton[] inventorButton;
    public List<(ScriptableObject scriptableObject, int howMany)> itemsInPage = new List<(ScriptableObject scriptableObject, int howMany)>();

    private int buttonCount;
    private int inventoryColumnCount;
    private int inventoryRowCount;
    private float leftValueRatio = 59.33333333333333f;
    private float rightValueRatio = 59.33333333333333f;
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

        Debug.Log("Width: " + width + " Height: " + height);
        inventorButton = GetComponentsInChildren<InventorButton>();
        
        buttonCount = inventorButton.Length;
        inventoryColumnCount = GetComponent<GridLayoutGroup>().constraintCount;
        inventoryRowCount = buttonCount / inventoryColumnCount;
        print((buttonCount, inventoryColumnCount, inventoryRowCount));
        GetComponent<GridLayoutGroup>().cellSize = new Vector2(width / cellSizeRatio, width / cellSizeRatio);

    }
    public bool CanGetObject(IWiewable wiewable,int howMany)
    {
        
        int i = 0;
        int weightInInventory = wiewable.GetWeightInInventory();
        Debug.Log("pivk upbastý");


        foreach (InventorButton button in inventorButton)
        {

            if (weightInInventory + i > buttonCount)
            {
                return false;
            }
            if (button.scriptableObject == null)
            {
                
                if (weightInInventory == 1)
                {
                    AddScriptableObjectInPage(wiewable,howMany, inventorButton[i]);

                    
                    return true;
                }
                else if (inventorButton[i + 1].scriptableObject == null)
                {
                    if ((i + 1) % 9 != 0) {
                        if (weightInInventory == 2)
                        {
                            AddScriptableObjectInButton(wiewable, inventorButton[i + 1]);
                            AddScriptableObjectInPage(wiewable, howMany, inventorButton[i]);
                            return true;
                        }
                        if ((i + 2) % 9 != 0)
                        {
                            if (weightInInventory == 3 && inventorButton[i + 2].scriptableObject == null)
                            {
                                AddScriptableObjectInButton(wiewable, inventorButton[i + 1]);
                                AddScriptableObjectInButton(wiewable, inventorButton[i + 2]); ;
                                AddScriptableObjectInPage(wiewable, howMany, inventorButton[i]);
                                return true;
                            } 
                        }
                    }
                    
                }
            }
            
                i++;
            
        }
        return false;
    }
    public bool AddStack(IWiewable wiewable, int howMany)
    {
        foreach (var itemSlot in itemsInPage.Where(item => item.scriptableObject == wiewable.GetScriptableObject()))
        {
            int newCount = itemSlot.howMany + howMany;
            Debug.Log(itemSlot.howMany + " " + howMany);

            if (newCount <= wiewable.StackLimit())
            {
                int index = itemsInPage.IndexOf(itemSlot);
                itemsInPage[index] = (itemSlot.scriptableObject, newCount); // Güncelleme

                return true; // Ýlk eþleþen item için iþlem yapýlýr
            }
        }

        return false;
    }
    public void AddScriptableObjectInPage(IWiewable wiewable,int howMany,InventorButton inventorButton)
    {
        Debug.Log("pivk upbastý2");
        itemsInPage.Add((wiewable.GetScriptableObject(),howMany));

        inventorButton.ChangeSprite( wiewable);
    }
    public void AddScriptableObjectInButton(IWiewable wiewable,InventorButton inventorButton)
    {
        Debug.Log("pivk upbastý23");
        inventorButton.scriptableObject=wiewable.GetScriptableObject();
        inventorButton.gameObject.SetActive(false);
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




