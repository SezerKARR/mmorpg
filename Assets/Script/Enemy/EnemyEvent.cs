using System;
using ModestTree.Util;
using Script.Player;
using Script.ScriptableObject;
using UnityEngine;

namespace Script.Enemy
{
    public class EnemyEvent
    {
        public static Action< Vector3 , ObjectAbstract ,string > OnDropObject;
        //public static Action<(string playerName, MonsterSO deathMonster)> OnFinishTextTime;
    }
}