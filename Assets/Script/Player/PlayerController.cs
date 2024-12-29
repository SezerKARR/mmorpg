using System.Numerics;
using Script.Equipment;
using Script.Exp;
using Script.Interface;
using Script.Inventory.Objects;
using Script.ObjectInTheGround;
using Script.ScriptableObject.Equipment;
using Script.ScriptableObject.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Player
{
    
    public class PlayerController : CharacterController
    {
    
       
        private Camera _mainCamera;
        
        public SwordSo sword;
        
        [FormerlySerializedAs("ıtemDropWithOutName")] [FormerlySerializedAs("ItemDropWithOutName")] public GameObject itemDropWithOutName;
        //public Sprite[] playerIdleSprite;
        
        
        
       // public EquipmentStat EquipmentStat = new EquipmentStat();
        private float _swordPhsichalDamage;
        public LineRenderer lineRenderer;
        
        
       
       
        protected override void Awake()
        {
            base.Awake();
            _expController = new ExpController(characterModel.level, characterModel.exp);
            _mainCamera = Camera.main;
            EquipmentEvent.OnEquip += OnEquipItem;
            EquipmentEvent.OnUnequip += OnUnEquipItem;

        }

        private void OnEquipItem(ItemController item)
        {
            characterModel.UpdateStats(item.GetStats(),true);
        }

        private void OnUnEquipItem(ItemController item)
        {
            characterModel.UpdateStats(item.GetStats(),false);
        }

        private void Start()
        {
            _swordPhsichalDamage = 50f;//when getting sword delete this shit
        
        

        }
        private int creatureExp;
        public void GiveNormalDamage(IDamageAble damageAble)
        { 
            bool crit = false;
            //todo: crit oran� hesaplama
            if (crit)
            {
                damageAble.TakeDamage(_swordPhsichalDamage*2, this);
                DamageTextManager.instance.CreateDamageText((_swordPhsichalDamage * 2).ToString(), damageAble.GetPosition(),DamageType.Crit);
            }
            else
            {
                damageAble.TakeDamage(_swordPhsichalDamage , this);
                DamageTextManager.instance.CreateDamageText((_swordPhsichalDamage ).ToString(), damageAble.GetPosition(), DamageType.Normal);
            }
       
       
        }
        public  void ExpCalculator(float exp)
        {
            _expController.ChangeExp((characterModel.level,exp));
            // print( GameManager.instance.ExpRateCalculate(creatureLevel - level));
            /*if (!haveGroup)
        {

        }
        else
        {

        }*/
        }
    }
}