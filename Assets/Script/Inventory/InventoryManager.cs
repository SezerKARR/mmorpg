
using System;
using System.Collections.Generic;
using Script.Equipment;
using Script.Inventory;
using Script.Inventory.Objects;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class InventoryManager : MonoBehaviour,IWaitConfirmable
{
    [Inject] [SerializeField] private EquipmentManager _equipmentManager;
    [SerializeField]private InventoryPage[] inventoryPage;
    public ObjectController objectController;
    private int activePage=1;
    [SerializeField]
    private PageChangeButton[] pageChangeButton;
   // public 
    private void Awake()
    {
        ObjectEvents.OnPickUp += AddObject;
        ObjectEvents.ObjectClicked += ObjectSelected;
        
    }

    public bool NeedUnequip(ObjectAbstract addObject)
    {
        //reduce = false;
        /*if (this.EquipButton != null)
        {
            if (SomePos(addObject, this.EquipButton)) return true;
        }*/
   
        if (Add(addObject, 1))
        {
        
            return true;
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
        

        foreach (InventoryPage page in inventoryPage)
        {

            if (inventorObjectAble.stackLimit > 1)
            {
                if(page.AddStack(inventorObjectAble, howMany))
                {
                    return true;
                }
            }
            if (page.CanGetObject(inventorObjectAble, howMany)) {

                //itemsInInventory.Add((inventorObjectAble, howMany));
                return true;
            }
        }
        return false;

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
