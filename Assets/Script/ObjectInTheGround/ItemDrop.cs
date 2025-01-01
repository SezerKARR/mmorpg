using Script.Interface;
using Script.ScriptableObject;
using TMPro;
using UnityEngine;

namespace Script.ObjectInTheGround
{
    public enum DropType
    {
        None,
        WithPlayerName,
        WithoutPlayerName,
    }
    public abstract class ItemDrop : MonoBehaviour, IPickedUpAble,IPoolable
    {
        public TMP_Text itemName;
        public ObjectAbstract objectAbstract;
        public int howMany=1;
        Vector3 RandomPositionByObjectCircle()
        {
            Vector2 position = new Vector2(Random.Range(transform.position.x - 1f, transform.position.x + 1f), Random.Range(transform.position.y - 1f, transform.position.y + 1f));
            return new Vector3(position.x, position.y, 0);
        }
        public abstract DropType GetDropType();
        protected virtual void SetDropName()
        {
            if (this.howMany > 1)
            {
                itemName.text = objectAbstract.dropName + " x" + this.howMany;
            }
            else
            {
                itemName.text = objectAbstract.dropName ;
            }
        }
        public virtual void OnActivate(ObjectAbstract item ,string playerName, Vector3 position)
        {
            objectAbstract = item ;
            SetDropName();
            this.transform.position = position;
            this.transform.position = RandomPositionByObjectCircle();
            this.gameObject.SetActive(true);
            if (item.stackLimit > 1)
            {
                howMany = 75;
            }
     
        }
        public virtual void OnDeactivate()
        {
        
        }
    
        public virtual GameObject GetGameObject()
        {
            return this.gameObject;
        }
        public ObjectAbstract GetObject()
        {
            return this.objectAbstract;
        }
        public int GetHowMany()
        {
            return this.howMany;
        }

        public abstract string GetPoolType();
        
    }
}
