
using System;
using System.Collections.Generic;
using Game.Extensions.Unity;
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
    [Inject] [SerializeField] private EquipmentManager _equipmentManager;
    [SerializeField]private InventoryPage[] inventoryPage;
    [SerializeField] private HaveObjects haveObjects;

    [Serializable]
    public class HaveObjects : UnityDictionary<ObjectAbstract, int> { };
    private ObjectController objectController;
    private int activePage = 0;
    [SerializeField]
    private PageChangeButton[] pageChangeButton;
   // public 
    private void Awake()
    {
        InventoryPage.OnObjectAddToPage += AddObjectsToInventory;
        InputPlayer.OnGrounClicked += DropObject;
        ObjectEvents.OnPickUp += AddObject;
        ObjectEvents.ObjectClicked += ObjectSelected;
        
    }
    private void AddObjectsToInventory(ObjectAbstract inventorObjectable, int howMany)
    {
        if (haveObjects.ContainsKey(inventorObjectable))
        {
            // Eğer key mevcutsa, listenin sonuna item ekle
            haveObjects[inventorObjectable]+=howMany;
            return;
        }
        haveObjects.Add(inventorObjectable, howMany);
    }
    public void Equip(ItemController itemController)
    {
        inventoryPage[activePage].ResetButtons(itemController.cells);
    }
    public bool Unequip(ItemController unEquipObject)
    {
       
            foreach (InventoryPage page in inventoryPage)
            {
           
                return page.ControlUnequip(unEquipObject);
            
            }

            return false;
      
      
    }
    private void ObjectSelected(ObjectController objectController)
    {
        if (this.objectController == null)
        {
            this.objectController = objectController;
        }
        else
        {
            ChangePos(objectController);
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
        inventoryPage[page].GetComponent<CanvasGroup>().alpha = 0;
        inventoryPage[page].GetComponent<CanvasGroup>().interactable = false; 
        inventoryPage[page].GetComponent<CanvasGroup>().blocksRaycasts = false; 

        pageChangeButton[page].ChangeColorForNormal();
    }
    
    public void OpenPage(int page)
    {
        activePage = page;
        inventoryPage[page].GetComponent<CanvasGroup>().alpha = 1;      
        inventoryPage[page].GetComponent<CanvasGroup>().interactable = true; 
        inventoryPage[page].GetComponent<CanvasGroup>().blocksRaycasts = true; 
        pageChangeButton[page].ChangeColorForPressed();
    }
    private void ChangePos(ObjectController objectController)
    {
        ObjectController temp = objectController;
        
    }
    public void AddObject(ObjectAbstract inventorObjectAble,int howMany,GameObject destroyIfPickUp=null)
    {
        Debug.Log("geldi");
        if(Add(inventorObjectAble,howMany))Destroy(destroyIfPickUp);
    }
    public bool Add(ObjectAbstract inventorObjectAble,int howMany)
    {

        if (CanAddStack(inventorObjectAble, howMany)) {return true;}
        
        return CanAdd(inventorObjectAble, howMany);

    }
    public bool CanAdd(ObjectAbstract inventorObjectAble, int howMany)
    {
        foreach (InventoryPage page in inventoryPage)
        {
           
            if( page.ControlAdd(inventorObjectAble, howMany)){return true;};
            
        }

        return false;
    }
    public bool CanAddStack(ObjectAbstract inventorObjectAble, int howMany)
    {
        if (inventorObjectAble.stackLimit > 1)
        {
            foreach (InventoryPage page in inventoryPage)
            {

          
                if(page.AddStack(inventorObjectAble, howMany))
                {
                    return true;
                }
            }
            
        }
        return false;   
    }
    private void ResetButtons(List<int> buttonPoss)
    {
        //inventoryPage[buttonPos.x].ResetButtons(buttonPos.y);
    }
   /* public void DropObject()
    {
        if (objectController.inventorObjectable is IDropable dropable)
        {
            if (dropable.GetPlayerCanDrop())
            {
                string confirmText = $"{dropable.GetDropName()} yere atmak istedi�ine emin misin";
                UIManager.Instance.OpenConfirm(confirmText,this);
            }
            else { Debug.Log("bu obje yere at�lamaz"); }
        }
    }*/

    public void ConfirmValue(bool confirmValue)
    {
        
        throw new NotImplementedException();
    }

    public void DropObject()
    {
        throw new NotImplementedException();
    }

    
}
