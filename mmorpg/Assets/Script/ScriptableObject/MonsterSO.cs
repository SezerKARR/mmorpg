using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Monster")]
public class MonsterSO : ScriptableObject
{
    public Sprite Image;
    public string[] Resistance;
    public string race;
    public string level;
    public string stage;
    public string monsterName;
    public string location;
    public string[] monsterLocations;
    public string exp;
    public List<ScriptableObject> canDrop=new List<ScriptableObject>();

}