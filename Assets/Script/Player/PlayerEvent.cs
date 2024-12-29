using System;
using System.Numerics;

namespace Script.Player
{
    public class PlayerEvent
    {
        public static Action<BigInteger > OnExpChanged;
        public static Action OnLevelUp;
    }
}