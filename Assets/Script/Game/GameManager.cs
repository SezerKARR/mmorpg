using Script.DroppedItem;
using Script.Interface;
using Script.Inventory.Objects;
using Script.InventorySystem.inventory;
using Script.ObjectInstances;
using Script.Player;
using Script.ScriptableObject.Player;
using Script.ScriptableObject.Prefab;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using Vector3 = UnityEngine.Vector3;

namespace Script.Game
{
    public class GameManager : MonoBehaviour
    {
        [FormerlySerializedAs("ıtemDropPrefabs")] [FormerlySerializedAs("ItemDropPrefabs")] public ItemPrefabList itemDropPrefabs;
        public static GameManager Instance;
        private ObjectPooler _ıtemDropPooler;
        [Inject] private PlayerController _playerController;
        public  CharactersModel charactersModel;
        // public ExpHelper expHelper;
        private void Awake()
        {
            if(charactersModel==null) charactersModel=Resources.Load<CharactersModel>("CharactersModel");
            charactersModel.Initialize();
            GameEvent.OnGetCharacterModel += charactersModel.GetCharacterModel;
            InventoryEvent.OnDropObject +=(droppedObject) => CreateDropItem(droppedObject, _playerController.transform.position);
            _ıtemDropPooler = new ObjectPooler(itemDropPrefabs,this.transform,50);
            GameEvent.OnPickup += ItemDropReturn;
            GameEvent.OnItemDroppedWithPlayer += CreateDropItem;
            GameEvent.OnItemDroppedWithoutPlayer += CreateDropItem;
            Instance = this;
        }

        private void ItemDropReturn(IPool poolAble)
        {
            _ıtemDropPooler.ReturnObject(poolAble.GetPoolType(),poolAble.GetGameObject());
        }
        private void CreateDropItem(Vector3 position, ObjectInstance objectInstance,string playerName)
        {
            _ıtemDropPooler.SpawnFromPool<ItemDrop>(DropType.WithPlayerName.ToString()).OnActivate(objectInstance,playerName,position);
        }
        private void CreateDropItem( ObjectInstance objectInstance,Vector3 position)
        {
            _ıtemDropPooler.SpawnFromPool<ItemDrop>(DropType.WithoutPlayerName.ToString()).OnActivate(objectInstance,null,position);
        }
        //public  void Wiev
        
    }
    
}
