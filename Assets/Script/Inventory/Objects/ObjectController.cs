using System.Collections.Generic;
using Script.Interface;
using Script.ScriptableObject;
using Script.UI.Tooltip;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Inventory.Objects
{
    
    public abstract class ObjectController :MonoBehaviour,IPool
    {
        public List<int2> cells;
        public int page;
        public int  size;
        [SerializeField] protected ObjectView objectView;
        [FormerlySerializedAs("objectModel")] [SerializeField] protected  ObjectAbstract objectAbstract;
       
        public ObjectAbstract ObjectAbstract => objectAbstract;
        public abstract  string GetPoolType();
        public GameObject GetGameObject()
        {
            return gameObject;
        }

        protected virtual void Start()
        {
            objectView.OnObjectPressed += OnButtonClick;
            objectView.OnRightClick += RightClick;
            objectView.OnEnter += OnEnter;
            objectView.OnExit += OnExit;
        }

        protected virtual void OnExit()
        {
            ToolTipEvent.OnTooltip?.Invoke(objectAbstract);
        }

        private void OnEnter()
        {
            ToolTipEvent.OnTooltipClose?.Invoke();
        }

        public virtual void RightClick() { }
        public virtual void Place(Transform parent,Vector2 size)
        {
            cells = null;
            transform.SetParent(parent);
            objectView.SetPosition( size);
            //objectView.SetPosition(new Vector2(positon.x, positon.y));
        }
        protected virtual void OnButtonClick()
        {
            
            ObjectEvents.ObjectClicked.Invoke(this);
            Debug.Log("OnButtonClick");
        }
        public virtual void Place(PageController pageController, List<int2> cellInt2,float height,float weight)
        {
            page = pageController.PageModel.pageIndex;
            transform.SetParent(pageController.transform);
            cells = cellInt2;
            objectView.SetObject(cellInt2,objectAbstract.ımage,objectAbstract.weightInInventory,weight,height,objectAbstract.howMany);
        }
        public virtual void Place(ObjectAbstract objectAbstract, PageController pageController, List<int2> cellInt2,int howMany,float height,float weigh)
        { 
            
            page = pageController.PageModel.pageIndex;
            pageController.PageModel.AddObjectToPage(objectAbstract, cellInt2);
            this.objectAbstract = objectAbstract;
            //this.objectAbstract.SetObjectAbstract(objectAbstract);
            this.ObjectAbstract.howMany = howMany; 
            cells = cellInt2;
            transform.SetParent(pageController.transform);
            objectView.SetObject(cellInt2,this.objectAbstract.ımage,this.objectAbstract.weightInInventory,weigh,height,howMany);
            this.gameObject.SetActive(true);
        }
        
        public void UpdateCount(int newCount)
        {
            objectAbstract.howMany = newCount;
            objectView.SetHowManyText(newCount);
        }

        
    }
}