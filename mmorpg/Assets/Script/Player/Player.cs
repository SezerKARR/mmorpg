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
public class Player : MonoBehaviour
{
    
    private Camera _mainCamera;
    public PolygonCollider2D[] attackColliderNormalSword;
    public SwordSO sword;
    private PlayerInput playerInput;
    public float moveSpeed = 7f;
    
    //public Sprite[] playerIdleSprite;
    
    
    
    private float swordPhsichalDamage;
    public LineRenderer lineRenderer;
    
    
    public int level;
    public int exp;
    public bool haveGroup;
    public groupType groupType;
    
    private void Awake()
    {
            playerInput = new PlayerInput();
            playerInput.Player.Enable();
            _mainCamera = Camera.main;
        
        
    }
    private void Start()
    {
        swordPhsichalDamage = 50f;//when getting sword delete this shit
        
        

    }

    private void Update()
    {
       
       
       
    }


    private int creatureExp;
    public void GiveDamage(IDamageAble damageAble)
    {
       damageAble.TakeDamage(swordPhsichalDamage,this);
       
    }
    public  void ExpCalculator(int exp,int creatureLevel)
    {
        print( GameManager.instance.ExpRateCalculate(creatureLevel - level));
        /*if (!haveGroup)
        {

        }
        else
        {

        }*/
    }
}
