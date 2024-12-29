using System;
using Script.Exp;
using Script.Player.Character;
using Script.ScriptableObject.Equipment;
using Script.ScriptableObject.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public enum GroupType
    {
        Level,
        Even
    }

    public enum DamageType
    {
        Normal,
        Crit,
        Magical
    }

    public class CharacterController : MonoBehaviour
    {
        public PolygonCollider2D[] attackColliderNormalSword;
        public float moveSpeed = 7f;
        protected CharacterExp _expController;
        [FormerlySerializedAs("playerModel")] public CharacterModel characterModel;
        public int level => characterModel.level;
        public CharacterType playerCharecterType => characterModel.characterType;

        protected virtual void Awake()
        {
            _expController = new CharacterExp(characterModel.level, characterModel.exp);
        }

        protected virtual void OnEnable()
        {
            CharacterEvent.OnLevelUp += OnlevelUp;
        }

        protected virtual void OnlevelUp()
        {
            throw new NotImplementedException();
        }
    }
}