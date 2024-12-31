using System;
using System.Numerics;
using Script.Interface;

namespace Script.Player.Character
{
    public interface IDamager:IGetName
    {
        Action<int,long> onEnemyKilled { get; set; }
    }
}