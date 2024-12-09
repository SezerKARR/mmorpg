
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour , IWaitConfirmable
{
    public static InventoryManager Instance;
    [SerializeField]
    private InventoryPage[] inventoryPage;
    public  List<(IInventorObjectable inventorObject, int howMany)> itemsInInventory = new List<(IInventorObjectable inventorObject, int howMany)>();
    [SerializeField]
    private PageChangeButton[] pageChangeButton;
    public InventorButton selectedButton=null;
    private int activePage;
    private InventorButton EquipButton;
    bool reduce = true;
    public InventorButton lastTakedButton;
    
    private void Awake()
    {
        
        Instance = this;
        for (int i = 0; i < inventoryPage.Length; i++) {
            inventoryPage[i].GiveNumber(i);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        OpenPage(0);
    }
   
    public void DropItemYes(IDropable dropable)
    {
        Player.instance.DropItem(dropable);

        ReduceObjectInInventoryList( selectedButton);
        
        CloseImageUnderCursor();
        
        ResetSelectedObject();
        
        
    }
    
    public void ResetSelectedObject()
    {
        this.selectedButton = null;
    }
    public void DropItemNo()
    {
        CloseImageUnderCursor();
        ResetSelectedObject();
        
    }
    private void ReduceObjectInInventoryList(InventorButton selectedButton)
    {
        int howMany = selectedButton.howMany;


        int index = itemsInInventory.FindIndex(item => item.inventorObject == selectedButton.inventorObjectAble);
        if (itemsInInventory[index].howMany - howMany > 0)
        {
            itemsInInventory[index] = (itemsInInventory[index].inventorObject, itemsInInventory[index].howMany - howMany);
        }
        else if (itemsInInventory[index].howMany - howMany == 0)
        {
            itemsInInventory.Remove(itemsInInventory[index]);
            ResetButtons(selectedButton.ButtonPos);
        }
        else {Debug.Log("hata var"); }
        
    }
    private void ResetButtons(Vector2Int buttonPos)
    {
        inventoryPage[buttonPos.x].ResetButtons(buttonPos.y);
    }
    private bool SomePos(IInventorObjectable unEquipItem,InventorButton newButton)
    {
        
        ResetButtons(newButton.ButtonPos);


        return inventoryPage[activePage].CanChangePosition(newButton.ButtonPos.y, unEquipItem, 1);
    }
    public bool NeedUnequip(IInventorObjectable inventorObjectAble)
    {
        reduce = false;
        if (this.EquipButton != null)
        {
            if (SomePos(inventorObjectAble, this.EquipButton)) return true;
        }
       
        if (add(inventorObjectAble, 1))
        {
            
            return true;
        }
        return false;
    }
   
    public bool add(IInventorObjectable inventorObjectAble,int howMany)
    {
        

        foreach (InventoryPage page in inventoryPage)
        {

            if (inventorObjectAble.GetStackLimit() > 1)
            {
                if(page.AddStack(inventorObjectAble, howMany))
                {
                    int index = itemsInInventory.FindIndex(x => x.Item1 == inventorObjectAble);
                    if (index != -1)
                    {
                        itemsInInventory[index] = (itemsInInventory[index].inventorObject, itemsInInventory[index].howMany + howMany);
                    }
                    return true;
                }
            }
            if (page.CanGetObject(inventorObjectAble, howMany)) {

                itemsInInventory.Add((inventorObjectAble, howMany));
                return true;
            }
        }
        return false;

    }
    public bool ChangeIViewableInventoryPosition(int  newButtonPos,InventorButton selectedButton)
    {
        if (CanChange(newButtonPos, selectedButton))
        {
            CloseImageUnderCursor();
            inventoryPage[activePage].inventorButtons[newButtonPos].Screen();
            
                inventoryPage[selectedButton.ButtonPos.x].ResetButtons(selectedButton.ButtonPos.y);
                this.selectedButton = null;
            
            
            return true;
        }
        return false;
    }
    public bool CanChange(int newButtonPos,InventorButton selectedButton)
    {
        return inventoryPage[activePage].CanChangePosition(newButtonPos,selectedButton.inventorObjectAble,selectedButton.howMany);
    }
    
    public void ChangePage(int page)
    {
        ClosePage(activePage);
        OpenPage(page);
        
    }
    public void ClosePage(int page)
    {
        inventoryPage[page].GetComponent<CanvasGroup>().alpha = 0;
        inventoryPage[page].GetComponent<CanvasGroup>().interactable = false; 
        inventoryPage[page].GetComponent<CanvasGroup>().blocksRaycasts = false; 

        pageChangeButton[page].ChangeColorForNormal();
    }
    public void CloseImageUnderCursor()
    {
        ImageUnderCursor.Instance.GameObject().SetActive(false);
        
    }
    public void OpenPage(int page)
    {
        activePage = page;
        inventoryPage[page].GetComponent<CanvasGroup>().alpha = 1;      
        inventoryPage[page].GetComponent<CanvasGroup>().interactable = true; 
        inventoryPage[page].GetComponent<CanvasGroup>().blocksRaycasts = true; 
        pageChangeButton[page].ChangeColorForPressed();
    }
    public void CloseInventory()
    {
        this.GetComponent<CanvasGroup>().alpha = 0; 
        this.GetComponent<CanvasGroup>().interactable = false;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true; 
    }
    public void EquipThisItem(InventorButton selectedButton)
    {
        this.EquipButton = selectedButton;
        if (EquipmentManager.Instance.ControlCanEquip(selectedButton.inventorObjectAble is ScriptableItemsAbstact item ? item : null) &&reduce)
        {
            ReduceObjectInInventoryList(selectedButton);    
        }
        reduce = true;
        this.EquipButton = null;
    }

    public void ConfirmValue(bool confirmValue)
    {
        if (confirmValue)
        {
            ConfirmYesToDrop();
        }
        else
        {
            ConfirmNoToDrop();
        }

    }
    private void ConfirmNoToDrop()
    {
        this.selectedButton = null;
    }
    private void ConfirmYesToDrop()
    {
        if (selectedButton.inventorObjectAble is IDropable dropable)
        {
            DropItemYes(dropable);
        }
    }
}
