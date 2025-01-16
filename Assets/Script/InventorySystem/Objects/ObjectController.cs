using System;
using Script.Equipment;
using Script.Interface;
using Script.Inventory.Objects;
using Script.InventorySystem.inventory;
using Script.ObjectInstances;
using Script.ScriptableObject;
using Script.ScriptableObject.UpObject;
using Script.UI.Tooltip;
using Unity.VisualScripting;
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
            ToolTipEvent.OnTooltipClose?.Invoke();

        }

        protected virtual void OnEnter()
        {
            
        }

        public virtual void RightClick() { }
        
        protected virtual void OnButtonClick()
        {
            
            ObjectEvents.ObjectClicked.Invoke(this);
            Debug.Log("OnButtonClick");
        }
       
       
        public virtual void Place(ObjectInstance objectInstancePlace)
        {
          
            objectInstancePlace.controllerPool = this;
            this.objectInstance = objectInstancePlace;
            objectView.SetObject(objectInstance);

            this.gameObject.SetActive(true);
            
        }
        public void LeftClick(ObjectInstance objectInstanceTemp)
        {
            ILeftClickAble leftClick = objectInstance.objectAbstract.GetComponent<ILeftClickAble>();
            if (leftClick != null)
                leftClick.DoLeftClick(objectInstanceTemp);
        }
        
       

        public virtual void Reset()
        {
            objectView.Reset();
        }
    }
}