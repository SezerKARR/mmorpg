using Script.Inventory;
using Script.Inventory.Objects;
using Script.ObjectInTheGround;
using Script.Player;
using Script.ScriptableObject;
using Script.ScriptableObject.Player;
using Script.ScriptableObject.Prefab;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using IPoolable = Script.Interface.IPoolable;
using Vector3 = UnityEngine.Vector3;

namespace Script.Game
{
    public class GameManager : MonoBehaviour
    {
        [FormerlySerializedAs("ItemDropPrefabs")] public ItemPrefabList ıtemDropPrefabs;
        public static GameManager Instance;
        private ObjectPooler ItemDropPooler;
        [Inject] private PlayerController _playerController;
        public  CharactersModel charactersModel;
        // public ExpHelper expHelper;
        private void Awake()
        {
            if(charactersModel==null) charactersModel=Resources.Load<CharactersModel>("CharactersModel");
            charactersModel.Initialize();
            GameEvent.OnGetCharacterModel += charactersModel.GetCharacterModel;
            
            ItemDropPooler = new ObjectPooler(ıtemDropPrefabs,this.transform,50);
            InventoryEvent.OnItemPickUp += ItemDropReturn;
            GameEvent.OnItemDroppedWithPlayer += CreateDropItem;
            GameEvent.OnItemDroppedWithoutPlayer += CreateDropItem;
            Instance = this;
        }

        
        // private void Cre((PlayerController player, MonsterSO deathMonster) obj)
        // {
        //    
        //     
        //     float exp=obj.deathMonster.expint*ExpRateCalculate(obj.deathMonster.levelint-obj.player.level);
        //     obj.player.ExpCalculator(exp/100f);
        // }

        private void ItemDropReturn(GameObject obj)
        {
            ItemDropPooler.ReturnObject(obj.GetComponent<IPoolable>().GetPoolType(),obj);
        }

        private void CreateDropItem(Vector3 position, ObjectAbstract objectAbstract,string playerName)
        {
            ItemDropPooler.SpawnFromPool<ItemDrop>(DropType.WithPlayerName.ToString()).OnActivate(objectAbstract,playerName,position);
        }
        private void CreateDropItem( ObjectAbstract objectAbstract,Transform transform)
        {
            ItemDropPooler.SpawnFromPool<ItemDrop>(DropType.WithoutPlayerName.ToString()).OnActivate(objectAbstract,null,transform.position);
        }
        //public  void Wiev
        

        
    }
}
