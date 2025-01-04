using Script.Equipment;
using Script.Exp;
using Script.Inventory.Objects;
using Script.Player.Character;
using Script.ScriptableObject.Player;
using UnityEngine;

namespace Script.Player
{
    
    public class PlayerController : CharController
    {
    
       public ExpView[] expViews;
        private Camera _mainCamera;
        
        
        
        //public Sprite[] playerIdleSprite;
        
        
        
       // public EquipmentStat EquipmentStat = new EquipmentStat();
        
        public LineRenderer lineRenderer;
        
        
       
       
        protected override void Awake()
        {
            base.Awake();
            _expController = new PlayerExp(this);
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

        public  void ExpRateView()
        {
            Debug.Log(characterModel.expRate);
        }
       
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