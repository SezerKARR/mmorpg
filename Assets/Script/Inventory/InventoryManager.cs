
using System;
using System.Collections.Generic;
using Script.Equipment;
using Script.Inventory;
using Script.Inventory.Objects;
using Script.Player;
using Script.ScriptableObject.Prefab;
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
    public   InventoryStorage inventoryStorage;
    [SerializeField] private RectTransform pages;
    public ItemPrefabList objectsPrefab;
    ObjectPooler objectPooler;
   // public 
   private float _rowheight;
   private float _rowWidth;
    private void Awake()
    {
        inventoryStorage = new InventoryStorage();
        _rowWidth = pages.rect.width/rowCount;
        _rowheight = pages.rect.height/columnCount;
        _activePageController = inventoryPage[0];
        foreach (PageController pageController in inventoryPage)
        {
            inventoryStorage.pageModels.Add(pageController.PageModel);
           
        }
        objectPooler = new ObjectPooler(objectsPrefab);
    }
    private void OnEnable()
    {
        ObjectEvents.OnPickUp += PickUp;
        PageChangeButton.OnChangePageClicked += ChangePage;
        InputPlayer.OnGroundClicked += DropObject;
        ObjectEvents.ObjectClicked += ObjectSelected;
        InventoryEvent.OnAdd += CreateObjectModel;
        InventoryEvent.OnUneqipItem += ChangePosition;
    }
    private ObjectAbstract objectToAdd;
    private int howMany;
    private void PickUp(ObjectAbstract inventoryObjectAbstract, int howMany, GameObject selectedObject)
    {
        EquipmentEvent.OnEquip += inventoryStorage.RemoveObject;
        objectToAdd = inventoryObjectAbstract;
        this.howMany= howMany;
        if(inventoryStorage.Add(inventoryObjectAbstract, howMany))Destroy(selectedObject);
       
    }
    public void ChangePosition(ItemController unEquipItem ,List<int2> cells,int pageIndex)
    {
        unEquipItem.Place(inventoryPage[pageIndex],cells,_rowheight,_rowWidth);
    }
    public void CreateObjectModel(List<int2> cellInt2,int pageIndex)
    {  // GameObject objectControllerGameObject= Instantiate(objectsPrefab.GetPrefabByType(inventorObjectable.Type));
        //
        // objectControllerGameObject.GetComponent<ObjectController>().
        // pageModel.AddObjectToPage(objectControllerGameObject.GetComponent<ObjectController>(),cellInt2);
       
        objectPooler.SpawnFromPool(objectToAdd.Type).Place(objectToAdd,inventoryPage[pageIndex],cellInt2,howMany,
            _rowheight,_rowWidth);  
        inventoryStorage.AddObjectsToInventory( objectToAdd,howMany );
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
