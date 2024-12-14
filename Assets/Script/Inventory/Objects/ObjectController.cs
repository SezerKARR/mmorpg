using Script.Inventory.Objects;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;


namespace Script.Inventory
{
    
    public abstract class ObjectController :MonoBehaviour
    {
        public int2 cellIndex;
        public int  size;
        [SerializeField] protected ObjectView objectView;
        [SerializeField] protected  ObjectModel objectModel;
        public int howMany;
        public ObjectModel Model => objectModel;
        
        protected virtual void Start()
        {
            objectView.OnItemPressed += OnButtonClick;
            objectView.OnRightClick += RightClick;
        }

        public virtual void RightClick() { }
        public virtual void Place(Transform parent)
        {
            cellIndex = new int2(-1, -1);
            transform.SetParent(parent);
            objectView.SetPosition();
            //objectView.SetPosition(new Vector2(positon.x, positon.y));
        }
        protected virtual void OnButtonClick()
        {
            
            ObjectEvents.ObjectClicked.Invoke(this);
            Debug.Log("OnButtonClick");
        }
        public virtual void Place(Transform parent, int2 cellInt2,int howMany)
        {
            this.howMany = howMany;
            cellIndex = cellInt2;
            transform.SetParent(parent);
            objectView.SetPosition(cellInt2);
        }
        public virtual void Place(ObjectAbstract objectAbstract, Transform parent, int2 cellInt2,int howMany,float height,float weight)
        {
            objectModel.SetObjectAbstract(objectAbstract);
            this.howMany = howMany; 
            cellIndex = cellInt2;
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