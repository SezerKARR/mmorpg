
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
     public static PageController[] inventoryPage;
    private ObjectController currentObjectController;
    private PageController _activePageController ;
   // public 
    private void Awake()
    {
        _activePageController = inventoryPage[0];
        PageChangeButton.OnChangePageClicked += ChangePage;
        
        
        InputPlayer.OnGrounClicked += DropObject;
        ObjectEvents.OnPickUp += AddObject;
        ObjectEvents.ObjectClicked += ObjectSelected;

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
    public void ChangePage(int pageIndex)
    {
        
        _activePageController.ClosePage();
        
        OpenPage(pageIndex);
    
    }
    public void OpenPage(int pageIndex)
    {
        _activePageController = inventoryPage[pageIndex];
        
        _activePageController.OpenPage(); 
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
