
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bonus
{
    public string bonusName;
    public float maxBonusRate;
    public List<float> bonusRates; 
}
public abstract class BonusSO : ScriptableObject
{
    public Bonus[] bonuses;
    
}
