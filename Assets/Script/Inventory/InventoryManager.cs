
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
     public PageController[] inventoryPage;
     public  int rowCount;
     public  int columnCount;
     private ObjectController currentObjectController;
    private PageController _activePageController ;
    [Inject] [SerializeField] private InventoryStorage inventoryStorage;
   // public 
    private void Awake()
    {
        _activePageController = inventoryPage[0];
        PageChangeButton.OnChangePageClicked += ChangePage;
        InputPlayer.OnGrounClicked += DropObject;
        ObjectEvents.ObjectClicked += ObjectSelected;
       
        foreach (PageController pageController in inventoryPage)
        {
            inventoryStorage.pageModels.Add(pageController.PageModel);
           
        }
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
