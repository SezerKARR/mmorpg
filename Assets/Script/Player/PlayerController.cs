using Script.Equipment;
using Script.Interface;
using Script.Inventory.Objects;
using Script.ObjectInTheGround;
using Script.ScriptableObject.Equipment;
using Script.ScriptableObject.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Player
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
    public class PlayerController : MonoBehaviour
    {
    
        public string playerName="satisfaction";
        private Camera _mainCamera;
        public PolygonCollider2D[] attackColliderNormalSword;
        public SwordSo sword;
        public float moveSpeed = 7f;
        [FormerlySerializedAs("ıtemDropWithOutName")] [FormerlySerializedAs("ItemDropWithOutName")] public GameObject itemDropWithOutName;
        //public Sprite[] playerIdleSprite;
        public PlayerModel playerModel;

        
       // public EquipmentStat EquipmentStat = new EquipmentStat();
        private float _swordPhsichalDamage;
        public LineRenderer lineRenderer;
    
        
       
       public int level=>playerModel.level;
       public Character playerCharecterType=>playerModel.character;
        private void Awake()
        {
            _mainCamera = Camera.main;
            EquipmentEvent.OnEquip += OnEquipItem;
            EquipmentEvent.OnUnequip += OnUnEquipItem;

        }

        private void OnEquipItem(ItemController item)
        {
            playerModel.UpdateStats(item.GetStats(),true);
        }

        private void OnUnEquipItem(ItemController item)
        {
            playerModel.UpdateStats(item.GetStats(),false);
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
        public  void ExpCalculator(int exp,int creatureLevel)
        {
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