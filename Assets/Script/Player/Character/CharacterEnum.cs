using System;

namespace Script.Player.Character
{
    public enum Race
    {
        None = 0,
        HalfHuman = 1,
        Animal=2,
        Orc=3,
        Mystic=4,
        Desert=5,
        Insect=6,
        Undead=7,
        Devil=8,
        
    }
    [Flags]
    public enum Element
    {
        None = 0,
        Wind=1,
        Fire=2,
        Earth=4,
        Lightning=8,
        Darkness=16,
        
    }
    public enum DirectionEnum
    {
        None,
        Left,
        Right,
        Down,
        Up,
    }
}