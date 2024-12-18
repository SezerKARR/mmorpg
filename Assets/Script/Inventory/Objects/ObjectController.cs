using System.Collections.Generic;
using Script.Inventory.Objects;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;


namespace Script.Inventory
{
    
    public abstract class ObjectController :MonoBehaviour
    {
        public List<int2> cells;
        public int page;
        public int  size;
        [SerializeField] protected ObjectView objectView;
        [FormerlySerializedAs("objectModel")] [SerializeField] protected  ObjectAbstract objectAbstract;
        public int howMany;
        public ObjectAbstract ObjectAbstract => objectAbstract;
        
        protected virtual void Start()
        {
            objectView.OnObjectPressed += OnButtonClick;
            objectView.OnRightClick += RightClick;
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
            
            ObjectEvents.ObjectClicked.Invoke(this,objectAbstract);
            Debug.Log("OnButtonClick");
        }
        public virtual void Place(Transform parent, List<int2> cellInt2,float height,float weight)
        {
            cells = cellInt2;
            transform.SetParent(parent);
            objectView.SetObject(cellInt2,objectAbstract.Image,objectAbstract.weightInInventory,weight,height,howMany);
        }
        public virtual void Place(ObjectAbstract objectAbstract, PageController pageController, List<int2> cellInt2,int howMany,float height,float weigh)
        { 
            page = pageController.PageModel.PageIndex;
            pageController.PageModel.AddObjectToPage(this, cellInt2);
            this.objectAbstract = objectAbstract;
            //this.objectAbstract.SetObjectAbstract(objectAbstract);
            this.howMany = howMany; 
            cells = cellInt2;
            transform.SetParent(pageController.transform);
            objectView.SetObject(cellInt2,this.objectAbstract.Image,this.objectAbstract.weightInInventory,weigh,height,howMany);
        }
        
        public void UpdateCount(int newCount)
        {
            howMany = newCount;
            objectView.SetHowManyText(newCount);
        }
    }
}