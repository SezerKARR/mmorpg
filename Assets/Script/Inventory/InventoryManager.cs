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
        public InventoryStorage InventoryStorage;
        [SerializeField] private RectTransform pages;
        public ItemPrefabList objectsPrefab;

        private ObjectPooler _objectPooler;
        private float _rowheight;
        private float _rowWidth;

        private void Awake()
        {
            InventoryStorage = new InventoryStorage();
            _rowWidth = pages.rect.width / rowCount;
            _rowheight = pages.rect.height / columnCount;
            _activePageController = inventoryPage[0];
            foreach (PageController pageController in inventoryPage)
            {
                InventoryStorage.pageModels.Add(pageController.PageModel);
            }

            _objectPooler = new ObjectPooler(objectsPrefab);
        }

        private void OnEnable()
        {
            ObjectEvents.OnPickUp += PickUp;
            PageChangeButton.OnChangePageClicked += ChangePage;
            InputPlayer.OnGroundClicked += GroundClicked;
            ObjectEvents.ObjectClicked += ObjectSelected;
            InventoryEvent.OnAdd += CreateObjectModel;
            InventoryEvent.OnUneqipItem += ChangePosition;
            InventoryEvent.OnClickInventory += OnClickInventory;
        }

        private void OnClickInventory( )
        {
            if()
            imageUnderCursor.Close();
            Debug.Log(gridposition);
        }

        private ObjectAbstract _objectToAdd;
        private int _howMany;

        private void PickUp(ObjectAbstract inventoryObjectAbstract, int howMany, GameObject selectedObject)
        {
            EquipmentEvent.OnEquip += InventoryStorage.RemoveObject;
            _objectToAdd = inventoryObjectAbstract;
            this._howMany = howMany;
            if (InventoryStorage.Add(inventoryObjectAbstract, howMany)) Destroy(selectedObject);
        }

        public void ChangePosition(ItemController unEquipItem, List<int2> cells, int pageIndex)
        {
            unEquipItem.Place(inventoryPage[pageIndex], cells, _rowheight, _rowWidth);
        }

        public void CreateObjectModel(List<int2> cellInt2, int pageIndex)
        {
            _objectPooler.SpawnFromPool(_objectToAdd.Type).Place(_objectToAdd, inventoryPage[pageIndex], cellInt2,
                _howMany,
                _rowheight, _rowWidth);
            InventoryStorage.AddObjectsToInventory(_objectToAdd, _howMany);
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
                    $"{_currentObjectController.ObjectAbstract.DropName} eşyayı yere atmak istediğinden emin misiniz.",
                    DropObject, null);
            }
        }

        private void DropObject()
        {
            imageUnderCursor.Close();
            InventoryStorage.RemoveObject(this._currentObjectController);
            _objectPooler.ReturnObject(this._currentObjectController.ObjectAbstract.Type,
                this._currentObjectController.gameObject);

            this._currentObjectController = null;
        }
    }
}