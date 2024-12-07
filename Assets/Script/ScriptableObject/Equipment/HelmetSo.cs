using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/Helmet")]
public class HelmetSo : ScriptableItemsAbstact
{
    public List<int> defence=new List<int>();

    public override Dictionary<StatType, float> GetStats()
    {
        return new Dictionary<StatType, float>
        {
            { StatType.Defense, defence[currentPlus] },
        };
    }
}
