using System;
using System.Collections;
using System.Collections.Generic;
using Script.Damage;
using Script.Player.Character;
using Script.ScriptableObject;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ScriptableObject/Monster")]
public class MonsterSO : ScriptableObject
{
    
    public Sprite Image;
    [FormerlySerializedAs("Resistance")] public string[] Resistance;
    public Element elements;
    public string race;
    public Race raceEnum;
    public string level;
    public int levelint;
    public string stage;
    public float blockNormalAttackChange;
    public int stageint;
    public string monsterName;
    public string location;
    public string[] monsterLocations;
    public string exp;
    public long expint;
    public int health;
    public float defense;
    public WaponTypeDefence waponTypeDefence;
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
    public CharacterNormalDefenderData GetNormalDefenderData()
    {
        return new CharacterNormalDefenderData()
        {
            blockNormalAttackChange = blockNormalAttackChange,
            defense = defense,
            waponTypeDefence = waponTypeDefence,
            elements = elements,
            race = raceEnum

        };
    }
}