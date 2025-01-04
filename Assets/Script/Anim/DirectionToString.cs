using System.Collections.Generic;
using Script.Player.Character;
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
    public static class DirectionHelper
    {
        public static string GetDirection(Vector2 direction)
        {
            Vector2 normalizedDirection = direction.normalized;

            if (normalizedDirection == Vector2.right) return "Right";
            if (normalizedDirection == Vector2.left) return "Left";
            if (normalizedDirection == Vector2.up) return "Up";
            if (normalizedDirection == Vector2.down) return "Down";

            return null;
        }
        public static Vector2 GetVector(string directionString)
        {
            switch (directionString)
            {
                case "Right": return Vector2.right;
                case "Left": return Vector2.left;
                case "Up": return Vector2.up;
                case "Down": return Vector2.down;
                default: return Vector2.zero; // Bilinmeyen bir yön için varsayılan değer.
            }
        }
    }
    public static class ExpHelper
    {
        
        public static Vector2 GetVector(string directionString)
        {
            switch (directionString)
            {
                case "Right": return Vector2.right;
                case "Left": return Vector2.left;
                case "Up": return Vector2.up;
                case "Down": return Vector2.down;
                default: return Vector2.zero; // Bilinmeyen bir yön için varsayılan değer.
            }
        }
    }
    

    
    
    public class DirectionToString
    {
        public static Dictionary<Vector2, string> DirectionToStringMap = new Dictionary<Vector2, string>
        {
            { Vector2.right, DirectionEnum.Right.ToString() },
            { Vector2.left, DirectionEnum.Left.ToString() },
            { Vector2.up, DirectionEnum.Up.ToString() },
            { Vector2.down, DirectionEnum.Down.ToString() }
        };
        
    }
}