
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPage : MonoBehaviour
{
    public ScriptableObject upgradeItemsSO;
    public static Sprite sprite;
    private InventorButton[] inventoryButton;
    public List<ScriptableObject> itemsInPage = new List<ScriptableObject>();

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
    public bool CanGetObject(IWiewable wiewable)
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
                    AddScriptableObjectInPage(wiewable, inventoryButton[i]);

                    
                    return true;
                }
                else if (inventoryButton[i + inventoryColumnCount].scriptableObject == null)
                {

                    if (weightInInventory == 2)
                    {
                        AddScriptableObjectInPage(wiewable, inventoryButton[i]);
                        return true;
                    }
                    else if (weightInInventory == 3 && inventoryButton[i + inventoryColumnCount * 2].scriptableObject == null)
                    {
                        AddScriptableObjectInPage(wiewable, inventoryButton[i]);
                        return true;
                    }
                }
            }
            i++;
            
        }
        return false;
    }
    public void AddScriptableObjectInPage(IWiewable wiewable,InventorButton inventorButton)
    {
        Debug.Log("pivk upbastý2");
        itemsInPage.Add(wiewable.GetScriptableObject());

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
            itemsInPage.Remove(getObject);
            return;
        }

    }

}




