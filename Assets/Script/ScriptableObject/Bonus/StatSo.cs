using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class StatClass
{
    public string statName;
    public float statValue ;
}
[CreateAssetMenu(menuName = "ScriptableObject/CharStat")]
public class StatSo : ScriptableObject
{
    public StatClass[] stats = new StatClass[0];
    public void AddObject(StatClass Stat)
    {
        Array.Resize(ref stats, stats.Length + 1);
        stats[stats.Length - 1] = Stat;
    }
    public string[] GetStats()
    {
        return stats.Select(s => s.statName).ToArray();
    }
}