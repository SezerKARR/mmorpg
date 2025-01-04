using System.Linq;
using Script.ScriptableObject;
using UnityEngine;

namespace Script.Game
{
    public class ExpHelper
    {
        public static  ExpPerLevelSO ExpPer = Resources.Load<ExpPerLevelSO>("ExpPerLevel");
        public static ExpSo _expSo = Resources.Load<ExpSo>("ExpForLevel");
        public static float ExpRateCalculate(int levelDiff)
        {
            if (levelDiff >= ExpPer.levelDiff[0])
            {
                return ExpPer.expRate[0];
            }
            else if (levelDiff <= ExpPer.levelDiff[ExpPer.levelDiff.Length - 1])
            {
                return ExpPer.expRate[ExpPer.expRate.Length - 1];
            }
            else
            {
                int i = 0;
                foreach (var exp in ExpPer.levelDiff.Skip(1).Take(ExpPer.levelDiff.Length - 2))
                {
                    if (levelDiff == exp)
                    {
                        return ExpPer.expRate[i];
                    }
                    i++;

                }
            }
            return ExpPer.expRate[ExpPer.expRate.Length - 1];
        }

        
    }
}