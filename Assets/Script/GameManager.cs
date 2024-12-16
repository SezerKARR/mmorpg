using System.Linq;
using Script.Enemy;
using UnityEngine;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        public GameObject ItemDropPrefab;
        public  ExpPerLevelSO expPer;
        public static GameManager Instance;
        private void Awake()
        {
            EnemyEvent.OnDropObject += CreateDropItem;
            Instance = this;
        }

        private void CreateDropItem(Vector3 position, ObjectAbstract objectAbstract,string playerName)
        {
            GameObject itemDrop = Instantiate(ItemDropPrefab, position, Quaternion.identity);
            itemDrop.GetComponent<ItemDrop>().SetOther(objectAbstract,playerName);
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
