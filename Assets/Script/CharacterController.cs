using System;
using Script.Damage.DamageText;
using Script.Exp;
using Script.Interface;
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

    public class CharacterController : MonoBehaviour,IDamager
    {
        public Action<int, long> onEnemyKilled { get; set; }
        
        public float moveSpeed = 7f;
        protected CharacterExp _expController;
        public CharacterModel characterModel;
        public int level => characterModel.level;
        public CharacterType playerCharecterType => characterModel.characterType;
        private float _swordPhsichalDamage;
        public GameObject itemDropWithOutName;
        public string randomString;
        protected virtual void Awake()
        {
            characterModel=GameEvent.OnGetCharacterModel?.Invoke(this.gameObject.name);
            if (characterModel != null)
            {
               
                _expController = new CharacterExp(ref characterModel.level, ref characterModel.exp);
            }

            onEnemyKilled += _expController.ChangeExp;
            _swordPhsichalDamage = 50f;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                
                Debug.Log(characterModel);
                
            }
        }

        public void GiveNormalDamage(IDamageAble damageAble)
        {
           
            bool crit = false;
            //todo: crit oran� hesaplama
            if (crit)
            {
                GiveDamage(_swordPhsichalDamage * 2, damageAble, DamageType.Crit);
            }
            else
            {
                GiveDamage(_swordPhsichalDamage , damageAble, DamageType.Normal);
            }
           
       
        }
        

        private void GiveDamage(float damage, IDamageAble damageAble, DamageType damageType)
        {
            damageAble.TakeDamage(damage , this);
            DamageManager.instance.CreateDamageText( damage.ToString(), damageAble.GetPosition(),damageType);
        }

        protected virtual void OnEnable()
        {
            CharacterEvent.OnLevelUp += OnlevelUp;
        }

        protected virtual void OnlevelUp()
        {
            throw new NotImplementedException();
        }


        public string GetName()
        {
            return this.gameObject.name;
        }
    }
}