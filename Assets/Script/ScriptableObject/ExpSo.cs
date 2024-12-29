using System.Numerics;
using UnityEngine;

namespace Script.ScriptableObject
{
    [System.Serializable]
    public class ExpToLevel
    {
        public int level;
        public string exp;
    }
    [CreateAssetMenu(menuName = "ScriptableObject/Exp")]
    public class ExpSo : UnityEngine.ScriptableObject
    {
         
        [SerializeField]
        public ExpToLevel[] exps;
    }
}