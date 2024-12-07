using System.Collections.Generic;
using UnityEngine;

public interface IItemable
{
    public Dictionary<StatType, float> GetStats();
    
    public void SetNewStats();
    public void SetOldStats();
    public void GetBonus();
    public void SetNewBonus();
    public void SetOldBonus();
}
