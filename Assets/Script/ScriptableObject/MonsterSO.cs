using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ScriptableObject/Monster")]
public class MonsterSO : ScriptableObject
{
    
    public Sprite Image;
    public string[] Resistance;
    public string race;
    public string level;
    public int levelint;
    public string stage;
    public int stageint;
    public string monsterName;
    public string location;
    public string[] monsterLocations;
    public string exp;
    public int expint;
    public int health;
    [FormerlySerializedAs("canDrop")] public List<ObjectAbstract> canDrops=new List<ObjectAbstract>();
    //
    // public void SetHealth()
    // {
    //     levelint=int.Parse(level);
    //     if (stage != "Boss") stageint=int.Parse(stage);
    //     try
    //     {
    //         expint=int.Parse(exp);
    //     }
    //     catch (Exception e)
    //     {
    //         expint = int.MaxValue;
    //     }
    //     
    //     health = expint / levelint * (stageint + 1);
    // }
}