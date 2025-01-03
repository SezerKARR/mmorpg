using System;
using Script.Damage;
using Script.Exp;
using Script.Interface;
using Script.ScriptableObject.Equipment;
using Script.ScriptableObject.Player;
using Script.ScriptableObject.Prefab;
using UnityEngine;

namespace Script.Player.Character
{
    public enum GroupType
    {
        Level,
        Even
    }

    

    public class CharController : MonoBehaviour,IDamager
    {
        public Action<int, long> onEnemyKilled { get; set; }
        
        public float moveSpeed = 7f;
        protected CharacterExp _expController;
        public CharacterModel characterModel;
        public int level => characterModel.level;
        public CharacterType playerCharecterType => characterModel.characterType;
        private float _swordPhsichalDamage;
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

        public CharacterNormalAttackData GetCharacterNormalAttackData()
        {
            return characterModel.GetCharacterDamageData();
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

        public void GiveDamage(float damage, IDamageAble damageAble, DamageType damageType)
        {
            throw new NotImplementedException();
        }


        

        protected virtual void OnEnable()
        {
            CharacterEvent.OnLevelUp += OnlevelUp;
        }

        protected virtual void OnlevelUp()
        {
            Debug.Log("typeof()");
        }


        public string GetName()
        {
            return this.gameObject.name;
        }
    }
}