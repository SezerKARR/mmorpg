using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Script.Inventory.İnventoryMVC
{
    public abstract class ObjectController :MonoBehaviour
    {
        public int2 cellIndex;
        public int  size;
        [Inject]public InventoryView inventoryView;
        public ObjectController objectController;
    }
}