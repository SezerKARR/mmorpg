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
        [SerializeField] protected  ObjectModel objectModel;
        public int howMany;
        public ObjectModel Model => objectModel;
        
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
            
            ObjectEvents.ObjectClicked.Invoke(this,objectModel.ObjectAbstract);
            Debug.Log("OnButtonClick");
        }
        public virtual void Place(Transform parent, List<int2> cellInt2,float height,float weight)
        {
            cells = cellInt2;
            transform.SetParent(parent);
            objectView.SetObject(cellInt2,objectModel.sprite,objectModel.WeightInInventory,weight,height,howMany);
        }
        public virtual void Place(ObjectAbstract objectAbstract, Transform parent, List<int2> cellInt2,int howMany,float height,float weight)
        {
            objectModel.SetObjectAbstract(objectAbstract);
            this.howMany = howMany; 
            cells = cellInt2;
            transform.SetParent(parent);
            objectView.SetObject(cellInt2,objectModel.sprite,objectModel.WeightInInventory,weight,height,howMany);
        }

        public void UpdateCount(int newCount)
        {
            howMany = newCount;
            objectView.SetHowManyText(newCount);
        }
    }
}