
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPage : MonoBehaviour
{
    public static InventoryPage Instance;
    public ScriptableObject upgradeItemsSO;
    public static Sprite sprite;
    public InventorButton[] inventoryButton;
    public List<ScriptableObject> itemsInInventory = new List<ScriptableObject>();
    
    private int buttonCount;
    private int inventoryColumnCount;
    private int inventoryRowCount;
    
    //public static 
    // private int x=5;
    private static int y;
    private void Awake()
    {
        Instance = this;
        buttonCount = inventoryButton.Length;
        inventoryColumnCount = GetComponent<GridLayoutGroup>().constraintCount;
        inventoryRowCount = buttonCount / inventoryColumnCount;
        print((buttonCount, inventoryColumnCount, inventoryRowCount));
        
    }
    private void OnMouseDown()
    {
        //print("geldi");
    }
    /*private void Start()
    {
        for (int i = 0; i < inventorySystems.Length; i++)
        {
            for (int j = 0; j < inventorySystems[i].buttonGameObject.Length; j++)
            {
                if (inventorySystems[i].GetScriptableObjects[j] == null)
                {
                    inventorySystems[i].GetScriptableObjects[j] = Instantiate()
                    return;

                }
            }
            x = 0;
        }
    }*/
    private void Update()
    {

        /*if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed left-click.");

        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed right-click.");

        if (Input.GetMouseButtonDown(2)) 
              GetObject(upgradeItemsSO); 
       */

    }

    public void add(ScriptableObject getObject)
    {
        if (getObject is UpgradeItemsSO upgradeItem)
        {
            itemsInInventory.Add(upgradeItem);
            foreach (var button in inventoryButton)
            {
                if (button.Image.sprite == null)
                {
                    changeSprite(1, upgradeItem.Image, button);
                   
                    return;
                }
            }
        }
        else if (getObject is SwordSO sword)
        {
            Debug.Log($"Sword Item Detected: {sword.name}");
            
        }
        else
        {
            Debug.Log($"Unknown Item Type: {getObject.GetType()}");
        }
        /*
      foreach(var item in inventorObjects)
      {
            try
            {
                if (item.scriptableObject == null && inventorObjects[y + 5].scriptableObject == null)
                {
                    item.howMany++;
                    item.scriptableObject = getObject;
                    inventorObjects[y + 5].scriptableObject = getObject;
                    item.ChangeSprite(2, sprite);
                    break;
                }
            }
            catch
            {
                //print("envanter dolu");
            }
            y++;
      }
        y = 0;
    }*/

    }
    private void changeSprite(int spriteLength,Sprite sprite,InventorButton button)
    {
        button.ChangeSprite(spriteLength, sprite);
    }
    public void ChangeLocationInventoryObject(ScriptableObject scriptableObject)
    {
        remove(scriptableObject);
        add(scriptableObject);
    }
    public void remove(ScriptableObject getObject)
    {
        if(getObject is UpgradeItemsSO upgradeItem) 
        { 
            itemsInInventory.Remove(getObject);  
            return; 
        }
        
    }

}

    
