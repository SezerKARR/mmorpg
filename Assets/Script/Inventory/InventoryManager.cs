using System.Collections.Generic;
using Script.Equipment;
using Script.Inventory.Objects;
using Script.Player;
using Script.ScriptableObject.Prefab;
using Script.UI;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Script.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [FormerlySerializedAs("_imageUnderCursor")] [SerializeField]
        private ImageUnderCursor imageUnderCursor;

        [FormerlySerializedAs("_equipmentManager")] [Inject] [SerializeField]
        private EquipmentManager equipmentManager;

        public PageController[] inventoryPage;
        public int rowCount;
        public int columnCount;
        private ObjectController _currentObjectController;
        private PageController _activePageController;
        public InventoryStorage inventoryStorage;
        [FormerlySerializedAs("pages")] [SerializeField] private RectTransform pagesStorage;
        public ItemPrefabList objectsPrefab;

        private ObjectPooler _objectPooler;
        private float _rowheight;
        private float _rowWidth;

        private void Awake()
        {
            inventoryStorage = new InventoryStorage(inventoryPage, rowCount, columnCount);
            _rowWidth = pagesStorage.rect.width / rowCount;
            _rowheight = pagesStorage.rect.height / columnCount;
            _activePageController = inventoryPage[0];
            

            _objectPooler = new ObjectPooler(objectsPrefab,this.transform,30);
        }

        private void OnEnable()
        {
            ObjectEvents.OnPickUp += PickUp;
            PageChangeButton.OnChangePageClicked += ChangePage;
            InputPlayer.OnGroundClicked += GroundClicked;
            ObjectEvents.ObjectClicked += ObjectSelected;
            InventoryEvent.OnAdd += CreateObjectModel;
            InventoryEvent.OnUneqipItem += ChangePosition;
            PageEvent.OnClickPage += OnClickPage;
            InventoryEvent.OnChangedObjectPosition += ChangePosition;
            EquipmentEvent.OnEquip += inventoryStorage.RemoveObject;
        }

        private void OnClickPage( Vector2 position,int pageIndex )
        {
            if (this._currentObjectController != null)
            {
                inventoryStorage.ChangePos(this._currentObjectController,GridPositionCalculate(position), pageIndex);
                
            }
            imageUnderCursor.Close();
        }

        private int2 GridPositionCalculate(Vector2 topLeftAdjustedPosition)
        {
            float x = topLeftAdjustedPosition.x / _rowWidth;
             float y = Mathf.Abs(topLeftAdjustedPosition.y) / _rowheight;
             int2 gridposition = new int2(Mathf.FloorToInt(x), Mathf.FloorToInt(y));
             return gridposition;
        }
        private ObjectAbstract _objectToAdd;
        private int _howMany;

        private void PickUp(ObjectAbstract inventoryObjectAbstract, int howMany, GameObject selectedObject)
        {
            _objectToAdd = inventoryObjectAbstract;
            this._howMany = howMany;
            if (inventoryStorage.Add(inventoryObjectAbstract, howMany)) Destroy(selectedObject);
        }

        public void ChangePosition(ObjectController objectController, List<int2> cells, int pageIndex)
        {
            objectController.Place(inventoryPage[pageIndex], cells, _rowheight, _rowWidth);
        }

        public void CreateObjectModel(List<int2> cellInt2, int pageIndex)
        {
            _objectPooler.SpawnFromPool<ObjectController>(_objectToAdd.Type.ToString()).Place(_objectToAdd, inventoryPage[pageIndex], cellInt2,
                _howMany,
                _rowheight, _rowWidth);
            inventoryStorage.AddObjectsToInventory(_objectToAdd, _howMany);
        }

        private void ObjectSelected(ObjectController objectController)
        {
            this._currentObjectController = objectController;
            imageUnderCursor.Open(objectController.ObjectAbstract);
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
                    $"{_currentObjectController.ObjectAbstract.dropName} eşyayı yere atmak istediğinden emin misiniz.",
                    DropObject);
            }
        }

        private void DropObject()
        {
            imageUnderCursor.Close();
            inventoryStorage.RemoveObject(this._currentObjectController);
            _objectPooler.ReturnObject(this._currentObjectController.ObjectAbstract.Type.ToString(),
                this._currentObjectController.gameObject);
            
            this._currentObjectController = null;
        }
    }
}