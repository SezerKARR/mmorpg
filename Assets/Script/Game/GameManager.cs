using System.Linq;
using System.Numerics;
using Script.Enemy;
using Script.Inventory;
using Script.Inventory.Objects;
using Script.ObjectInTheGround;
using Script.Player;
using Script.ScriptableObject.Prefab;
using UnityEngine;
using Zenject;
using IPoolable = Script.Interface.IPoolable;
using Vector3 = UnityEngine.Vector3;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        public ItemPrefabList ItemDropPrefabs;
        
        public static GameManager Instance;
        private ObjectPooler ItemDropPooler;
        [Inject] private PlayerController _playerController;
        private void Awake()
        {
            ItemDropPooler = new ObjectPooler(ItemDropPrefabs,this.transform,50);
            InventoryEvent.OnItemPickUp += ItemDropReturn;
            GameEvent.OnItemDroppedWithPlayer += CreateDropItem;
            GameEvent.OnItemDroppedWithoutPlayer += CreateDropItem;
            EnemyEvent.OnDeath += EnemyDeath;
            Instance = this;
        }

        private void EnemyDeath((PlayerController player, MonsterSO deathMonster) obj)
        {
           
            
            float exp=obj.deathMonster.expint*ExpRateCalculate(obj.deathMonster.levelint-obj.player.level);
            obj.player.ExpCalculator(exp/100f);
        }

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
