using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public enum groupType
{
    level,
    even
}
public enum DamageType
{
    normal,
    crit,
    magical
}
public class Player : MonoBehaviour
{
    public static Player instance;
    private Camera _mainCamera;
    public PolygonCollider2D[] attackColliderNormalSword;
    public SwordSO sword;
    private PlayerInput playerInput;
    public float moveSpeed = 7f;
    public GameObject ItemDropWithOutName;
    public Character playerCharecterType = Character.Warrior;
    //public Sprite[] playerIdleSprite;



    private float swordPhsichalDamage;
    public LineRenderer lineRenderer;
    
    
    public int level;
    public int exp;
    public bool haveGroup;
    public groupType groupType;
    private void Awake()
    {
        instance = this;
            playerInput = new PlayerInput();
            playerInput.Player.Enable();
            _mainCamera = Camera.main;
        
        
    }
    private void Start()
    {
        swordPhsichalDamage = 50f;//when getting sword delete this shit
        
        

    }
    public void DropItem()
    {
        GameObject itemDrop = Instantiate(ItemDropWithOutName,transform.position,Quaternion.identity);
        itemDrop.GetComponent<ItemDropWithOutName>().IWievableScriptableObject=InventoryManager.Instance.selectedButton.inventorObjectAble;
    }
    private void Update()
    {
       
       
       
    }


    private int creatureExp;
    public void GiveNormalDamage(IDamageAble damageAble)
    { 
        bool crit = false;
        //todo: crit oraný hesaplama
        if (crit)
        {
            damageAble.TakeDamage(swordPhsichalDamage*2, this);
            DamageTextManager.instance.CreateDamageText((swordPhsichalDamage * 2).ToString(), damageAble.GetPosition(),DamageType.crit);
        }
        else
        {
            damageAble.TakeDamage(swordPhsichalDamage , this);
            DamageTextManager.instance.CreateDamageText((swordPhsichalDamage ).ToString(), damageAble.GetPosition(), DamageType.normal);
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
