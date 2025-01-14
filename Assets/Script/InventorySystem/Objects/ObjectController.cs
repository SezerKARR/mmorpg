using System;
using Script.Equipment;
using Script.Interface;
using Script.Inventory.Objects;
using Script.InventorySystem.inventory;
using Script.ObjectInstances;
using Script.ScriptableObject;
using Script.UI.Tooltip;
using UnityEngine;

namespace Script.InventorySystem.Objects
{
    
    public abstract class ObjectController :MonoBehaviour,IPool
    {
        [SerializeField] protected ObjectView objectView;
       [SerializeField] protected  ObjectInstance objectInstance;

       public ObjectInstance ObjectInstance => objectInstance;
        public abstract  string GetPoolType();
        public GameObject GetGameObject()
        {
            return gameObject;
        }

        protected virtual void Start()
        {
            objectView.onObjectPressed += OnButtonClick;
            objectView.onRightClick += RightClick;
            objectView.onEnter += OnEnter;
            objectView.onExit += OnExit;
        }

        protected virtual void OnExit()
        {
            ToolTipEvent.OnTooltip?.Invoke(objectInstance);
        }

        private void OnEnter()
        {
            ToolTipEvent.OnTooltipClose?.Invoke();
        }

        public virtual void RightClick() { }
        public virtual void Place(ObjectAbstract objectAbstract)
        {
            objectInstance.cellsInfo = null;
            
        }
        protected virtual void OnButtonClick()
        {
            
            ObjectEvents.ObjectClicked.Invoke(this);
            Debug.Log("OnButtonClick");
        }
        public virtual void Place(Transform parentTransform, CellsInfo cellsInfo)
        {
            this.objectInstance.cellsInfo = cellsInfo;
            objectView.SetPosition(cellsInfo.cells);
        }
       
        public virtual void Place(ObjectInstance objectInstancePlace)
        {
          
            objectInstancePlace.controllerPool = this;
            this.objectInstance = objectInstancePlace;
            objectView.SetObject(objectInstance);

            this.gameObject.SetActive(true);
            // page = pageController.PageModel.pageIndex;
            // pageController.PageModel.AddObjectToPage(objectInstancePlace, placeCells);
            // this.objectInstance = objectInstancePlace;
            // //this.objectInstance.SetObjectAbstract(objectInstance);
            // this.objectInstance.howMany = howMany; 
            // cells = placeCells;
            // 
            // objectView.SetObject(placeCells,this.objectInstance.ımage,this.objectInstance.weightInInventory,weigh,height,howMany);
            // this.gameObject.SetActive(true);
        }
        
        public void UpdateCount(int newCount)
        {
            objectInstance.howMany = newCount;
            objectView.SetHowManyText(newCount);
        }

        public virtual void Reset()
        {
            objectView.Reset();
        }
    }
}