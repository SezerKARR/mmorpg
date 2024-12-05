
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField]
    private InventoryPage[] inventoryPage;
    public  List<(IViewable IViewable, int howMany)> itemsInInventory = new List<(IViewable IViewable, int howMany)>();
    [SerializeField]
    private PageChangeButton[] pageChangeButton;
    public InventorButton selectedButton=null;
    private int activePage;
    
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
    public void DropItemYes()
    {
        Player.instance.DropItem();
        ReduceObjectInInventoryList( selectedButton);
        
        CloseImageUnderCursor();
        CloseConfirm();
        ResetSelectedObject();
        
        
    }
    public void CloseConfirm()
    {
        TooltipManager.Instance.confirm.SetActive(false);
    }
    public void ResetSelectedObject()
    {
        this.selectedButton = null;
    }
    public void DropItemNo()
    {
        CloseImageUnderCursor();
        ResetSelectedObject();
        CloseConfirm();
    }
    private void ReduceObjectInInventoryList(InventorButton selectedButton)
    {
        int howMany = selectedButton.howMany;


        Debug.Log(selectedButton.scriptableObjectIWiewable);
        int index = itemsInInventory.FindIndex(item => item.IViewable == selectedButton.scriptableObjectIWiewable);
        if (itemsInInventory[index].howMany - howMany > 0)
        {
            itemsInInventory[index] = (itemsInInventory[index].IViewable, itemsInInventory[index].howMany - howMany);
        }
        else if (itemsInInventory[index].howMany - howMany == 0)
        {
            itemsInInventory.Remove(itemsInInventory[index]);
            ResetButtons(selectedButton.ButtonCount);
        }
        else {Debug.Log("hata var"); }
        
    }
    private void ResetButtons(Vector2Int buttonPos)
    {
        inventoryPage[buttonPos.x].ResetButtons(buttonPos.y);
    }
    public bool add(IViewable wiewable,int howMany)
    {
        

        foreach (InventoryPage page in inventoryPage)
        {

            if (wiewable.StackLimit() > 1)
            {
                if(page.AddStack(wiewable, howMany))
                {
                    int index = itemsInInventory.FindIndex(x => x.Item1 == wiewable);
                    if (index != -1)
                    {
                        itemsInInventory[index] = (itemsInInventory[index].IViewable, itemsInInventory[index].howMany + howMany);
                    }
                    return true;
                }
            }
            Debug.Log("pivk upbastý3");
            if (page.CanGetObject(wiewable, howMany)) {

                itemsInInventory.Add((wiewable, howMany));
                return true;
            }
        }
        return false;

    }
    public void ChangeIViewableInventoryPosition(int  newButtonPos)
    {
        if ( inventoryPage[activePage].CanChangePosition(newButtonPos))
        {
            CloseImageUnderCursor();
            inventoryPage[activePage].inventorButtons[newButtonPos].Screen();
           
            inventoryPage[this.selectedButton.ButtonCount.x].ResetButtons(this.selectedButton.ButtonCount.y);
            this.selectedButton = null;
        }
        
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
        
        if (EquipmentManager.Instance.ControlCanEquip(selectedButton.scriptableObjectIWiewable))
        {
            ReduceObjectInInventoryList(selectedButton);
            
        }
        
    }
}
