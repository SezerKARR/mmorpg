using System.Collections.Generic;
using UnityEngine;

namespace Script.Anim
{
    public class AnimAndDirection
    {
        public static readonly Dictionary<Vector2, string> DirectionToStringMap = new Dictionary<Vector2, string>
        {
            { Vector2.right, "Right" },
            { Vector2.left, "Left" },
            { Vector2.up, "Up" },
            { Vector2.down, "Down" }
        };
        public  enum AnimEnum
        {
            None,
            Idle,
            Walk,
            Attack
        }
    }
}