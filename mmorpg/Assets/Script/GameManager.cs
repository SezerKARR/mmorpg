using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public  class GameManager : MonoBehaviour
{
    public ExpPerLevelSO[] expPer;
    [SerializeField]
    static public ExpPerLevelSO[] expPerLevelSOs;
    private void Awake()
    {
        expPerLevelSOs = expPer;
    }
    //public  void Wiev
    public static float ExpRateCalculate(int levelDiff)
    {
        if (levelDiff >= int.Parse(expPerLevelSOs[0].levelDiff))
        {
            return float.Parse(expPerLevelSOs[0].expRate);
        }
        else if (levelDiff <= int.Parse(expPerLevelSOs[expPerLevelSOs.Length - 1].levelDiff))
        {
            return float.Parse(expPerLevelSOs[expPerLevelSOs.Length - 1].expRate);
        }
        else
        {
            foreach (var exp in expPerLevelSOs.Skip(1).Take(expPerLevelSOs.Length - 2))
            {
                if (levelDiff == int.Parse(exp.levelDiff))
                {
                    return float.Parse(exp.expRate);
                }
                
                
            }
        }
        return float.Parse(expPerLevelSOs[expPerLevelSOs.Length - 1].expRate);
    }
}
