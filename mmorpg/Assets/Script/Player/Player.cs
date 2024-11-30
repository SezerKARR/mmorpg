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
    public void GenerateOutline(PolygonCollider2D polygonCollider2D)
    {

        {
            // Polygon collider'dan k��e noktalar�n� al
            Vector2[] points = polygonCollider2D.points;

            // LineRenderer i�in nokta say�s�n� ayarla
            lineRenderer.positionCount = points.Length + 1; // �lk ve son nokta ayn� olmal�

            // Her bir noktay� d�nya koordinatlar�na d�n��t�r ve ayarla
            for (int i = 0; i < points.Length; i++)
            {
                Vector3 worldPos = transform.TransformPoint(points[i]);
                worldPos.z = -0.1f; // Z pozisyonunu 0 yap
                lineRenderer.SetPosition(i, worldPos);
            }

            // �izgiyi kapatmak i�in ilk noktay� sonuna ekleyin
            lineRenderer.SetPosition(points.Length, lineRenderer.GetPosition(0));
        }
    }

    public void GetDropObject(GameObject gameObject)
    {
        // todo: destroy gameobject �nventory al
        //print(gameObject.name);
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
