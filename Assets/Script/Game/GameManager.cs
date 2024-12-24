using System.Linq;
using Script.Enemy;
using Script.Inventory;
using Script.Inventory.Objects;
using Script.ObjectInTheGround;
using Script.Player;
using Script.ScriptableObject.Prefab;
using UnityEngine;
using Zenject;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        public ItemPrefabList ItemDropPrefabs;
        public  ExpPerLevelSO expPer;
        public static GameManager Instance;
        private ObjectPooler ItemDropPooler;
        [Inject] private PlayerController _playerController;
        private void Awake()
        {
            ItemDropPooler = new ObjectPooler(ItemDropPrefabs,this.transform,50);
            GameEvent.OnItemDroppedWithPlayer += CreateDropItem;
            GameEvent.OnItemDroppedWithoutPlayer += CreateDropItem;
            Instance = this;
        }

        private void CreateDropItem(Vector3 position, ObjectAbstract objectAbstract,string playerName)
        {
            ItemDropPooler.SpawnFromPool<ItemDrop>(DropType.WithPlayerName.ToString()).OnActivate(objectAbstract,playerName,position);
        }
        private void CreateDropItem( ObjectAbstract objectAbstract)
        {
            ItemDropPooler.SpawnFromPool<ItemDrop>(DropType.WithoutPlayerName.ToString()).OnActivate(objectAbstract,null,_playerController.transform.position);
        }
        //public  void Wiev
        public  float ExpRateCalculate(int levelDiff)
        {
            if (levelDiff >= expPer.levelDiff[0])
            {
                return expPer.expRate[0];
            }
            else if (levelDiff <= expPer.levelDiff[expPer.levelDiff.Length - 1])
            {
                return expPer.expRate[expPer.expRate.Length - 1];
            }
            else
            {
                int i = 0;
                foreach (var exp in expPer.levelDiff.Skip(1).Take(expPer.levelDiff.Length - 2))
                {
                    if (levelDiff == exp)
                    {
                        return expPer.expRate[i];
                    }
                    i++;

                }
            }
            return expPer.expRate[expPer.expRate.Length - 1];
        }

        
    }
}
