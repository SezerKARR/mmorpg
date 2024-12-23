using Script.Interface;
using Script.ObjectInTheGround;
using Script.ScriptableObject.Equipment;
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
        [FormerlySerializedAs("ItemDropWithOutName")] public GameObject ıtemDropWithOutName;
        public Character playerCharecterType = Character.Warrior;
        //public Sprite[] playerIdleSprite;


        public EquipmentStat EquipmentStat = new EquipmentStat();
        private float _swordPhsichalDamage;
        public LineRenderer lineRenderer;
    
    
        public int level;
        public int exp;
        public bool haveGroup;
        public GroupType groupType;
        private void Awake()
        {
            _mainCamera = Camera.main;
        
        
        }
        private void Start()
        {
            _swordPhsichalDamage = 50f;//when getting sword delete this shit
        
        

        }
        public void DropItem(ObjectAbstract objectAbstract)
        {
       
            GameObject itemDrop = Instantiate(ıtemDropWithOutName, transform.position, Quaternion.identity);
            itemDrop.GetComponent<ItemDropWithOutName>().objectAbstract = objectAbstract;
        
        
        }
        private void Update()
        {
       
       
       
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