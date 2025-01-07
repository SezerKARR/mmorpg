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
        public static int RowCount;
        public static int ColumnCount;
        private ObjectController _currentObjectController;
        private PageController _activePageController;
        public InventoryStorage inventoryStorage;
        [FormerlySerializedAs("pages")] [SerializeField] private RectTransform pagesStorage;
        public ItemPrefabList objectsPrefab;
        
        private ObjectPooler _objectPooler;
        public static float CellHeight;
        public static float CellWeight;

        private void Awake()
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            CellWeight = pagesStorage.rect.width / rowCount;
            CellHeight = pagesStorage.rect.height / columnCount;
            _activePageController = inventoryPage[0];
            

            _objectPooler = new ObjectPooler(objectsPrefab,this.transform,30);
        }

        private void OnEnable()
        {
            InventoryStorageSo storage = Resources.Load<InventoryStorageSo>("Inventory/InventoryStorageSo");
            storage.pageModels.Clear();
            foreach (PageController pageController in inventoryPage)
            {
                storage.pageModels.Add(pageController.PageModel);
            }

            InventoryEvent.OnDropObject += DeleteObjectInventory;
            ObjectEvents.OnPickUp += PickUp;
            PageChangeButton.OnChangePageClicked += ChangePage;
            InputPlayer.OnGroundClicked += GroundClicked;
            ObjectEvents.ObjectClicked += ObjectSelected;
            InventoryEvent.OnItemPickUp += CreateObjectModel;
            InventoryEvent.OnInitializeStoreageItem += SpawnObject;
            InventoryEvent.OnUnEquipItem += ChangePosition;
            PageEvent.OnClickPage += OnClickPage;
            InventoryEvent.OnChangedObjectPosition += ChangePosition;
            inventoryStorage = new InventoryStorage(storage);
            EquipmentEvent.OnEquip += inventoryStorage.RemoveObject;
            InventoryEvent.OnGetEmptyCells = inventoryStorage.ControlEmptyCellAndPage;
        }

        private void PickUp(IPickedUpAble pickedUp)
        {
            if (inventoryStorage.IsAdd(pickedUp.GetObjectInstance())) GameEvent.OnPickup?.Invoke(pickedUp);
        }

        private void OnClickPage( Vector2 position,int pageIndex )
        {
            if (this._currentObjectController != null)
            {
                if (inventoryStorage.IsCanChangePos(this._currentObjectController, GridPositionCalculate(position),
                        pageIndex))
                {
                    this._currentObjectController = null;
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

      
        public void CreateObjectModel(ObjectInstance objectToAdd)
        {
            objectToAdd.parentTransform=inventoryPage[objectToAdd.cellsInfo.pageIndex].transform;
            SpawnObject(objectToAdd);
        }

        private void SpawnObject(ObjectInstance objectToAdd)
        {
            _objectPooler.SpawnFromPool<ObjectController>(objectToAdd.type).Place(objectToAdd);

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
            
            
            this._currentObjectController = null;
        }

        private void DeleteObjectInventory(ObjectInstance objectToDelete)
        {
            inventoryStorage.RemoveObject(objectToDelete);
            _objectPooler.ReturnObject(objectToDelete.type,
                this._currentObjectController.gameObject);
        }
    }
}