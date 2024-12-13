using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;


namespace Script.Inventory
{
    public enum TypeController
    {
        none,
        upgradeItem,
        item,
        UpgradeScroll,
    }
    public abstract class ObjectController :MonoBehaviour
    {
        public int2 cellIndex;
        public int  size;
        [SerializeField] protected ObjectView objectView;
        public IInventorObjectable inventorObjectable;
        public int howMany;
        
        protected virtual void Start()
        {
            objectView.OnItemPressed += OnButtonClick;
            objectView.OnRightClick += RightClick;
        }

        public virtual void RightClick() { }

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
        public virtual void Place(Transform parent, int2 cellInt2,int howMany,IInventorObjectable objectToPlace,float height,float weight)
        {
            this.howMany = howMany;
            inventorObjectable=objectToPlace;  
            cellIndex = cellInt2;
            transform.SetParent(parent);
            objectView.SetObject(cellInt2,objectToPlace,weight,height,howMany);
        }

        public void UpdateCount(int newCount)
        {
            howMany = newCount;
            objectView.SetHowManyText(newCount);
        }
    }
}