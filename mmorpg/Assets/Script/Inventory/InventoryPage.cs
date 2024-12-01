
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPage : MonoBehaviour
{
    public ScriptableObject upgradeItemsSO;
    public static Sprite sprite;
    private InventorButton[] inventoryButton;
    public List<(ScriptableObject scriptableObject, int howMany)> itemsInPage = new List<(ScriptableObject scriptableObject, int howMany)>();

    private int buttonCount;
    private int inventoryColumnCount;
    private int inventoryRowCount;

    //public static 
    // private int x=5;
    private static int y;
    private void Awake()
    {
        inventoryButton = GetComponentsInChildren<InventorButton>();
        buttonCount = inventoryButton.Length;
        inventoryColumnCount = GetComponent<GridLayoutGroup>().constraintCount;
        inventoryRowCount = buttonCount / inventoryColumnCount;
        print((buttonCount, inventoryColumnCount, inventoryRowCount));

    }
    public bool CanGetObject(IWiewable wiewable,int howMany)
    {
        
        int i = 0;
        int weightInInventory = wiewable.GetWeightInInventory();
        Debug.Log("pivk upbastý");


        foreach (InventorButton button in inventoryButton)
        {
            

            if (button.scriptableObject == null)
            {
                
                if (weightInInventory == 1)
                {
                    AddScriptableObjectInPage(wiewable,howMany, inventoryButton[i]);

                    
                    return true;
                }
                else if (inventoryButton[i + inventoryColumnCount].scriptableObject == null)
                {

                    if (weightInInventory == 2)
                    {
                        AddScriptableObjectInPage(wiewable,howMany, inventoryButton[i]);
                        return true;
                    }
                    else if (weightInInventory == 3 && inventoryButton[i + inventoryColumnCount * 2].scriptableObject == null)
                    {
                        AddScriptableObjectInPage(wiewable,howMany, inventoryButton[i]);
                        return true;
                    }
                }
            }
            else if (button.scriptableObject == wiewable.GetScriptableObject())
            {

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




