using System.Linq;
using UnityEngine;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        public  ExpPerLevelSO expPer;
        public static GameManager Instance;
        private void Awake()
        {
            Instance = this;
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
