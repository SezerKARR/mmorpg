using Script.Equipment;
using Script.Exp;
using Script.Inventory.Objects;
using Script.InventorySystem.Objects;
using Script.ObjectInstances;
using Script.Player.Character;
using Script.ScriptableObject.Player;
using UnityEngine;

namespace Script.Player
{
    
    public class PlayerController : CharController
    {

        public ExpView[] expViews;
        private Camera _mainCamera;
        public LineRenderer lineRenderer;
        
        protected override void Awake()
        {
            base.Awake();
            _expController = new PlayerExp(this);
            _mainCamera = Camera.main;
            // EquipmentEvent.OnEquip += OnEquipItem;
            // EquipmentEvent.OnUnequip += OnUnEquipItem;

        }
        //public Sprite[] playerIdleSprite;
        
        
        
       // public EquipmentStat EquipmentStat = new EquipmentStat();

       protected override void OnEnable()
       {
           base.OnEnable();
       }


       // private void OnEquipItem(ItemInstance item)
        // {
        //     characterModel.UpdateStats(item.GetStats(),true);
        // }
        //
        // private void OnUnEquipItem(ItemController item)
        // {
        //     characterModel.UpdateStats(item.GetStats(),false);
        // }

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