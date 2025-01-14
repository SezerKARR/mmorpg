using System;
using System.Collections.Generic;
using Script.DroppedItem;
using Script.Equipment;
using Script.Inventory;
using Script.Inventory.Objects;
using Script.InventorySystem.Objects;
using Script.InventorySystem.Page;
using Script.ObjectInstances;
using Script.Player;
using Script.ScriptableObject;
using Script.ScriptableObject.Prefab;
using Script.UI;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Script.InventorySystem.inventory
{
    
    public class InventoryManager : MonoBehaviour
    {

       [Inject] [SerializeField] private EquipmentManager equipmentManager;
       public static int MaxHealth { get; private set; }
       public static float MoveSpeed { get; private set; }
        public PageController[] inventoryPage;
        public int rowCount;
        public int columnCount;
        private ObjectController _currentObjectController;
        private PageController _activePageController;
        [SerializeField]
        public InventoryStorage inventoryStorage;
        [FormerlySerializedAs("pages")] [SerializeField] private RectTransform pagesStorage;
        public ItemPrefabList objectsPrefab;
        
        private ObjectPooler _objectPooler;
        public static float CellHeight;
        public static float CellWeight;

        private void Awake()
        {
            CellWeight = pagesStorage.rect.width / rowCount;
            CellHeight = pagesStorage.rect.height / columnCount;
            _activePageController = inventoryPage[0];
            

            _objectPooler = new ObjectPooler(objectsPrefab,this.transform,30);
        }
        public InventoryStorageSo storage;
        private void OnEnable()
        {
           

            InventoryEvent.OnDropObject += RemoveObject;
            ObjectEvents.OnPickUp += PickUp;
            PageChangeButton.OnChangePageClicked += ChangePage;
            InputPlayer.OnGroundClicked += GroundClicked;
            ObjectEvents.ObjectClicked += ObjectSelected;
            InventoryEvent.OnCreateItem += AddObject;
            InventoryEvent.OnInitializeStorageItem += SpawnObject;
            // InventoryEvent.OnUnEquipItem += ChangePosition;
            PageEvent.OnClickPage += OnClickPage;
            // InventoryEvent.OnChangedObjectPosition += ChangePosition;
            EquipmentEvent.OnEquip += RemoveObject;
            EquipmentEvent.OnUnequipItem = inventoryStorage.IsCreateObjectEmptyCell;
            EquipmentEvent.OnChangeItem = inventoryStorage.ChangeItem;
            storage.rowCount=rowCount;
            storage.columnCount = columnCount;
            inventoryStorage.Initialize();
        }

        private void PickUp(IPickedUpAble pickedUp)
        {
            if (inventoryStorage.IsAdd(pickedUp.GetObjectInstance())) GameEvent.OnPickup?.Invoke(pickedUp);
        }

        private void OnClickPage( Vector2 position,int pageIndex )
        {
            if (this._currentObjectController != null)
            {
                CellsInfo changePos = inventoryStorage.GetChangePos(this._currentObjectController.ObjectInstance, GridPositionCalculate(position), pageIndex);
                if (changePos!=null)
                {
                    RemoveObject(this._currentObjectController.ObjectInstance);
                    this._currentObjectController = null;
                    ImageUnderCursor.OnCloseImageUnderCursor?.Invoke();
                }
                
            }
        }

        private int2 GridPositionCalculate(Vector2 topLeftAdjustedPosition)
        {
            float x = topLeftAdjustedPosition.x / CellWeight;
             float y = Mathf.Abs(topLeftAdjustedPosition.y) / CellHeight;
             int2 gridposition = new int2(Mathf.FloorToInt(x), Mathf.FloorToInt(y));
             return gridposition;
        }

        public void ChangePosition(ObjectController objectController, CellsInfo cellsInfo)
        {
            objectController.Place(inventoryPage[cellsInfo.pageIndex].transform, cellsInfo);
        }

      
        
        private void ObjectSelected(ObjectController objectController)
        {
            this._currentObjectController = objectController;
        }

        public void ChangePage(int pageIndex)
        {
            _activePageController.ClosePage();
            _activePageController = inventoryPage[pageIndex];
            _activePageController.OpenPage();
        }

        public void GroundClicked()
        {
            if (this._currentObjectController != null)
            {
                UIEvent.OnOpenConfirm?.Invoke(
                    $"{_currentObjectController.ObjectInstance.objectAbstract.dropName} Do you want drop this object?.",
                    DropObject);
            }
        }

        private void DropObject()
        {
            InventoryEvent.OnDropObject?.Invoke(_currentObjectController.ObjectInstance);
        }
        private void RemoveObject(ObjectInstance objectInstanceToRemove)
        {
            this._currentObjectController = null;
            inventoryStorage.RemoveObject(objectInstanceToRemove);
            _objectPooler.ReturnObject(objectInstanceToRemove.controllerPool);

        }
        public void AddObject(ObjectInstance objectToAdd,CellsInfo cellsInfo)
        {
            objectToAdd.cellsInfo = cellsInfo;
            inventoryStorage.AddObjectsToInventory(objectToAdd);
            SpawnObject(objectToAdd);
        }

        public void SpawnObject(ObjectInstance objectToSpawn)
        {
            _objectPooler.SpawnFromPool<ObjectController>(objectToSpawn.type.ToString(),inventoryPage[objectToSpawn.cellsInfo.pageIndex].transform).Place(objectToSpawn);

        }

        
    }
}