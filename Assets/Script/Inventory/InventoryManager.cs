
using System;
using System.Collections.Generic;
using Script.Equipment;
using Script.Inventory;
using Script.Inventory.Objects;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class InventoryManager : MonoBehaviour,IWaitConfirmable
{
    [SerializeField] private ImageUnderCursor _imageUnderCursor;
    [Inject] [SerializeField] private EquipmentManager _equipmentManager;
    [SerializeField] private InventoryPage[] inventoryPage;
    private ObjectController currentObjectController;
    private int activePage = 0;
    [SerializeField]
    private PageChangeButton[] pageChangeButton;
     private InventoryStorage inventoryStorage;
   // public 
    private void Awake()
    {
        inventoryStorage=new InventoryStorage();
        InventoryPage.OnObjectAddToPage += AddObjectsToInventory;
        InputPlayer.OnGrounClicked += DropObject;
        ObjectEvents.OnPickUp += AddObject;
        ObjectEvents.ObjectClicked += ObjectSelected;
        inventoryStorage.inventoryPage = inventoryPage;

    }

    private void AddObjectsToInventory(ObjectAbstract inventorObjectable, int howMany)
    {
        inventoryStorage.AddObjectsToInventory(inventorObjectable, howMany);
    }

    public void Equip(ItemController itemController)
    {
        inventoryPage[activePage].ResetButtons(itemController.cells);
    }
    public bool ControlUnequip(ItemController unEquipObject)
    {

        return inventoryStorage.ControlChangePos(unEquipObject);

    }
    private void ObjectSelected(ObjectController objectController,ObjectAbstract selectedObject)
    {
        if (this.currentObjectController == null)
        {
            this.currentObjectController = objectController;
            _imageUnderCursor.Open(selectedObject);
        }
        else
        {
            _imageUnderCursor.Close();
            inventoryStorage.ChangePos(objectController);
        }
    }
    public void ChangePage(int page)
    {
        activePage = page;
        ClosePage(activePage);
        OpenPage(page);
    
    }
    public void ClosePage(int page)
    {
        inventoryPage[page].ClosePage(); 

        pageChangeButton[page].ChangeColorForNormal();
    }
    
    public void OpenPage(int page)
    {
        activePage = page; 
        inventoryPage[page].OpenPage(); 
        pageChangeButton[page].ChangeColorForPressed();
    }
    
    public void AddObject(ObjectAbstract inventorObjectAble,int howMany,GameObject destroyIfPickUp=null)
    {
        if(inventoryStorage.Add(inventorObjectAble,howMany))Destroy(destroyIfPickUp);
    }
   
   
    private void ResetButtons(List<int> buttonPoss)
    {
        //inventoryPage[buttonPos.x].ResetButtons(buttonPos.y);
    }
    

    public void ConfirmValue(bool confirmValue)
    {
        
        throw new NotImplementedException();
    }

    public void DropObject()
    {
        throw new NotImplementedException();
    }

    
}
