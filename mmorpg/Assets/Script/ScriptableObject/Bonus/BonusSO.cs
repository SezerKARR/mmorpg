
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bonus
{
    public string bonusName;
    public float maxBonusRate;
    public List<float> bonusRates=new List<float>(); 
}
public abstract class BonusSO : ScriptableObject
{
    public Bonus[] bonuses=new Bonus[0];
    public void AddObject(Bonus bonus)
    {
        Array.Resize(ref bonuses,bonuses.Length+1);
        bonuses[bonuses.Length - 1] = bonus;
    }
    
}
