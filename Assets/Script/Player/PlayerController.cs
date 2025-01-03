using System.Numerics;
using Script.Damage;
using Script.Equipment;
using Script.Exp;
using Script.Interface;
using Script.Inventory.Objects;
using Script.ObjectInTheGround;
using Script.Player.Character;
using Script.ScriptableObject.Equipment;
using Script.ScriptableObject.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Player
{
    
    public class PlayerController : CharController
    {
    
       
        private Camera _mainCamera;
        
        
        
        //public Sprite[] playerIdleSprite;
        
        
        
       // public EquipmentStat EquipmentStat = new EquipmentStat();
        
        public LineRenderer lineRenderer;
        
        
       
       
        protected override void Awake()
        {
            base.Awake();
            _expController = new PlayerExp(ref characterModel.level,ref characterModel.exp);
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
        private int creatureExp;
       
//         public  void ExpCalculator(long exp)
//         {
//             _expController.ChangeExp((characterModel.level,exp));
//             // print( GameManager.instance.ExpRateCalculate(creatureLevel - level));
//             /*if (!haveGroup)
//         {
//
//         }
//         else
//         {
//
//         }*/
//         }
    }
}