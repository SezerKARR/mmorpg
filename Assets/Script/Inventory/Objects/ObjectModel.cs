using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Inventory.Objects
{
    public class ObjectModel :MonoBehaviour
    {
         [SerializeField] protected global::ObjectAbstract _objectAbstract;
        
      
        public virtual void SetObjectAbstract(ObjectAbstract objectAbstract)
        {
            _objectAbstract = objectAbstract;
        }
        public ObjectAbstract ObjectAbstract=>this._objectAbstract;
        public int WeightInInventory => this._objectAbstract.weightInInventory;
        public Sprite sprite => this._objectAbstract.Image;
        public int StackLimit => this._objectAbstract.stackLimit;
    }
}