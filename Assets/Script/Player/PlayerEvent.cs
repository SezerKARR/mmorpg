using System;
using System.Numerics;
using Script.Player.Character;

namespace Script.Player
{
    public class PlayerEvent:CharacterEvent
    {
        public static Action<BigInteger> OnExpChanged;
        
    }
}