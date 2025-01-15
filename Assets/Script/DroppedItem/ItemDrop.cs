using Script.Equipment;
using Script.Interface;
using Script.InventorySystem.inventory;
using Script.ObjectInstances;
using Script.ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Script.DroppedItem
{
    public enum DropType
    {
        None,
        WithPlayerName,
        WithoutPlayerName,
    }
    public abstract class ItemDrop : ObjectInstanceHolder, IPickedUpAble
    {
        public TMP_Text itemName;
        protected ObjectInstance _objectInstance;
        protected int _howMany=1;
        Vector3 RandomPositionByObjectCircle()
        {
            Vector2 position = new Vector2(Random.Range(transform.position.x - 1f, transform.position.x + 1f), Random.Range(transform.position.y - 1f, transform.position.y + 1f));
            return new Vector3(position.x, position.y, 0);
        }
        public abstract DropType GetDropType();
        protected virtual void SetDropName()
        {
            if (this._howMany > 1)
            {
                itemName.text = _objectInstance.DropName();
            }
        }
        public virtual void OnActivate(ObjectInstance item ,string playerName, Vector3 position)
        {
            base.AddObject(item, null);
            _objectInstance = item ;
            SetDropName();
            this.transform.position = position;
            this.transform.position = RandomPositionByObjectCircle();
            this.gameObject.SetActive(true);
            if (item.objectAbstract.stackLimit > 1)
            {
                _howMany = 75;
            }
     
        }
        public virtual void OnDeactivate()
        {
        
        }
    
        public virtual GameObject GetGameObject()
        {
            return this.gameObject;
        }

        public ObjectInstance GetObjectInstance()
        {
            return this._objectInstance;
        }

        public int GetHowMany()
        {
            return this._howMany;
        }

        public Vector2 GetPosition()
        {
            return this.transform.position;
        }

        public abstract string GetPoolType();

        public override void RemoveObject(ObjectInstance objectToRemove)
        {
            GameEvent.OnPickup?.Invoke(this);
        }
    }
}
