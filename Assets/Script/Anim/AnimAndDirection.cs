using System.Collections.Generic;
using UnityEngine;

namespace Script.Anim
{
    public  enum AnimationEnum
    {
        None,
        Idle,
        Walk,
        Attack,
        Stop
    }
    public  enum PlayerAnimationEnum
    {
        None,
        Idle,
        Walk,
        Attack,
        Stop
    }
    
    public class AnimAndDirection
    {
        public static Dictionary<Vector2, string> DirectionToStringMap = new Dictionary<Vector2, string>
        {
            { Vector2.right, "Right" },
            { Vector2.left, "Left" },
            { Vector2.up, "Up" },
            { Vector2.down, "Down" }
        };
        
    }
}