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
    public Animator animator;
    private PlayerInput playerInput;
    public float moveSpeed = 7f;
    [HideInInspector]
    public int animValue;
    //public Sprite[] playerIdleSprite;
    [SerializeField]
    private InteractionDetector InteractionDetector;
    Vector2 inputWalkVector;
    float inputShootFloat;
    bool inputPickUpFromGroundFloat;
    float inputClickFloat;
    public IState lastState;
    private float swordPhsichalDamage;
    public LineRenderer lineRenderer;
    public GameObject selectedObject;
    public Material outlineGreen;
    public Material outlineRed;
    private Material normalMaterial;
    public int level;
    public int exp;
    public bool haveGroup;
    public groupType groupType;
    [SerializeField]
    public IState currentState;
    private void Awake()
    {
            playerInput = new PlayerInput();
            playerInput.Player.Enable();
            _mainCamera = Camera.main;
        animator = gameObject.GetComponent<Animator>();
        
    }
    private void Start()
    {
        swordPhsichalDamage = 50f;//when getting sword delete this shit
        animValue = 1;
        currentState = new IdleState();
        currentState.EnterState(this);

    }

    private void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            // Fare pozisyonundan bir ray oluþtur
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Eðer bir nesneye týklandýysa
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")
                {
                    ChangeSelectedObjectOutline(hit.collider.gameObject, outlineRed);
                    /*if (selectedObject != null)
                    {
                        //selectedObject.GetComponent<IOutlineAble>().Outline(Color.gray);
                        selectedObject.GetComponent<IOutlineAble>().Outline(normalMaterial);

                    }
                    selectedObject = hit.collider.gameObject;
                    // Týklanan nesneyi al

                    // Kýrmýzý çerçeveyi çiz

                    //selectedObject.GetComponent<IOutlineAble>().Outline(Color.red);
                    normalMaterial=selectedObject.GetComponent<SpriteRenderer>().material;
                    selectedObject.GetComponent<IOutlineAble>().Outline(outlineRed);

                    //print("Seçilen nesne: " + selectedObject.name);*/

                }
                else if (hit.collider.tag == "Npc")
                {
                    ChangeSelectedObjectOutline(hit.collider.gameObject, outlineGreen);
                    /*if (selectedObject != null)
                    {
                        //selectedObject.GetComponent<IOutlineAble>().Outline(Color.gray);
                        selectedObject.GetComponent<IOutlineAble>().Outline(normalMaterial);

                    }
                    selectedObject = hit.collider.gameObject;
                    // Týklanan nesneyi al

                    // Kýrmýzý çerçeveyi çiz

                    //selectedObject.GetComponent<IOutlineAble>().Outline(Color.red);
                    normalMaterial = selectedObject.GetComponent<SpriteRenderer>().material;
                    selectedObject.GetComponent<IOutlineAble>().Outline(outlineGreen);

                    //print("Seçilen nesne: " + selectedObject.name);
                }*/
                }
            }

        }
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }

        try
        {
            //todo: burasý deðiþecek playerInput.Player.move.performed+=ctx=>(ctx.readvalue<vector2>
            inputClickFloat = playerInput.Player.ClickLeft.ReadValue<float>();
            inputWalkVector = playerInput.Player.Move.ReadValue<Vector2>();
            inputShootFloat = playerInput.Player.Shoot.ReadValue<float>();
            inputPickUpFromGroundFloat = playerInput.Player.PickUpFromGround.WasPressedThisFrame();
            //shoot=playerInput.Player.Shoot.ReadValue<Butt
            //shoot = playerInput.Player.Shoot.ReadValue<Button>();

        }
        catch
        {
            playerInput = new PlayerInput();
            playerInput.Player.Enable();
        }
        if (inputPickUpFromGroundFloat)
        {
            ScriptableObject scriptableObject = InteractionDetector.PickUp();
            if (scriptableObject != null)
            {
                InventoryPage.Instance.add(scriptableObject);
            }


        }



    }
    public void GenerateOutline(PolygonCollider2D polygonCollider2D)
    {

        {
            // Polygon collider'dan köþe noktalarýný al
            Vector2[] points = polygonCollider2D.points;

            // LineRenderer için nokta sayýsýný ayarla
            lineRenderer.positionCount = points.Length + 1; // Ýlk ve son nokta ayný olmalý

            // Her bir noktayý dünya koordinatlarýna dönüþtür ve ayarla
            for (int i = 0; i < points.Length; i++)
            {
                Vector3 worldPos = transform.TransformPoint(points[i]);
                worldPos.z = -0.1f; // Z pozisyonunu 0 yap
                lineRenderer.SetPosition(i, worldPos);
            }

            // Çizgiyi kapatmak için ilk noktayý sonuna ekleyin
            lineRenderer.SetPosition(points.Length, lineRenderer.GetPosition(0));
        }
    }

    public void GetDropObject(GameObject gameObject)
    {
        // todo: destroy gameobject ýnventory al
        //print(gameObject.name);
    }
    public void CanChangeStateToAttack()
    {
        if (inputShootFloat == 1.0f)
        {
            ChangeState(new AttackState());
        }
    }
    public void CanChangeStateToWalk()
    {
        if (inputWalkVector != Vector2.zero)
        {
            ChangeState(new WalkState());
        }
    }
    public void CanChangeStateToIdle()
    {
        if (inputWalkVector == Vector2.zero && inputShootFloat != 1.0f)
        {
            ChangeState(new IdleState());
        }
    }

    /*public void AttackCompleted()
{
   animator.SetFloat("AttackPos", 0);
}*/
    private void ChangeSelectedObjectOutline(GameObject selectedOb, Material material)
    {
        if (selectedObject != null)
        {
            //selectedObject.GetComponent<IOutlineAble>().Outline(Color.gray);
            selectedObject.GetComponent<IOutlineAble>().Outline(normalMaterial);

        }
        selectedObject = selectedOb;
        // Týklanan nesneyi al

        // Kýrmýzý çerçeveyi çiz

        //selectedObject.GetComponent<IOutlineAble>().Outline(Color.red);
        normalMaterial = selectedObject.GetComponent<SpriteRenderer>().material;
        selectedObject.GetComponent<IOutlineAble>().Outline(material);

        //print("Seçilen nesne: " + selectedObject.name);
    }
   
    public void ChangeState(IState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }


    public void PlayerWalk(int animvalue)
    {
        animValue = animvalue;
        animator.SetFloat("StopedPos", 0);
        animator.SetFloat("IdlePos", -1);
        animator.SetFloat("WalkPos", animValue);
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;


        return inputVector;
    }
    public void Walk()
    {
        switch (inputWalkVector.x, inputWalkVector.y)
        {

            case (0, -1):

                PlayerWalk(1);
                break;
            case (1, 0):
                PlayerWalk(2);
                break;
            case (0, 1):
                PlayerWalk(3);
                break;
            case (-1, 0):
                PlayerWalk(4);
                break;
        }
        inputWalkVector =inputWalkVector.normalized;
        transform.position += new Vector3(inputWalkVector.x, inputWalkVector.y, 0f) * moveSpeed * Time.deltaTime;
    }   
    bool wait = false;
    public void Attack()
    {
        
        if (!wait)
        {

            
            StartCoroutine(Waita(GetCurrentAnimatorTime(animator)));
            //if you want the walk in attack animation time you need + call the walk() function here and
            //change the waitattack coroutine canchangestatetowalk() to if(shootFloat==0){canchangestatetowalk()}
        }
        else
        {
            return;
            
        }

    }
    public float GetCurrentAnimatorTime(Animator targetAnim, int layer = 0)
    {
        AnimatorStateInfo animState = targetAnim.GetCurrentAnimatorStateInfo(layer);
        float currentTime = animState.normalizedTime % 1;
        return currentTime;
    }
    public IEnumerator Waita(float second)
    {
        wait = true;
        animator.SetFloat("AttackPos", animValue);
        yield return new WaitForSeconds(0.345f);
        CanChangeStateToWalk();
        CanChangeStateToIdle();
        wait = false;
    }
    private int creatureExp;
    public void GiveDamage(IDamageAble damageAble)
    {
       damageAble.TakeDamage(swordPhsichalDamage,this);
       
    }
    public  void ExpCalculator(int exp,int creatureLevel)
    {
        print( GameManager.ExpRateCalculate(creatureLevel - level));
        /*if (!haveGroup)
        {

        }
        else
        {

        }*/
    }
}
