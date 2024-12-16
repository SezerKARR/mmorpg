using System;
using ModestTree.Util;
using UnityEngine;

namespace Script.Enemy
{
    public class EnemyEvent
    {
        public static Action< Vector3 , ObjectAbstract ,string > OnDropObject;
        public static Action<(Player player, string Exp, int enemyLevel)> OnDeath;
    }
}