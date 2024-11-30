using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    Vector2 inputWalkVector;
    float inputShootFloat;
    bool inputPickUpFromGroundFloat;
    float inputClickFloat;
    private PlayerInput playerNewInput;
    public Material outlineGreen;
    public Material outlineRed;
    private Material normalMaterial;
    public GameObject selectedObject;
    [SerializeField]
    private InteractionDetector InteractionDetector;

    public static event Action OnPickUpPressed;
    public static event Action OnNormalAttackPressed;
    public static event Action<Vector2> OnMovePressed;
    public static event Action OnClickLeftPressed;
    public static event Action OnIdlePerformed;
    // Start is called before the first frame update
    void Awake()
    {
        playerNewInput = new PlayerInput();
        playerNewInput.Player.Enable();
        
    }
    void OnEnable()
    {
        playerNewInput.Player.Enable();
        playerNewInput.Player.Move.canceled += context => OnIdlePerformed?.Invoke();
        playerNewInput.Player.Shoot.canceled += context => OnIdlePerformed?.Invoke();
        // Doðrudan event tetikleme
        playerNewInput.Player.PickUpFromGround.performed += context => OnPickUpPressed?.Invoke();
        playerNewInput.Player.Shoot.performed += context => OnNormalAttackPressed?.Invoke();
        playerNewInput.Player.Move.performed += context => OnMovePressed?.Invoke(context.ReadValue<Vector2>());
        

    }

    void OnDisable()
    {
        playerNewInput.Player.Disable();
        playerNewInput.Player.PickUpFromGround.performed -= context => OnPickUpPressed?.Invoke();
        playerNewInput.Player.Shoot.performed -= context => OnNormalAttackPressed?.Invoke();
        playerNewInput.Player.Move.performed -= context => OnMovePressed?.Invoke(context.ReadValue<Vector2>());
        //playerNewInput.Player.Move.canceled += context => OnMovePressed?.Invoke(Vector2.zero);
        playerNewInput.Player.PickUpFromGround.performed -= context => OnPickUpPressed?.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        try
        {
            //todo: burasý deðiþecek playerInput.Player.move.performed+=ctx=>(ctx.readvalue<vector2>
            inputClickFloat = playerNewInput.Player.ClickLeft.ReadValue<float>();
            inputWalkVector = playerNewInput.Player.Move.ReadValue<Vector2>();
            inputShootFloat = playerNewInput.Player.Shoot.ReadValue<float>();
            inputPickUpFromGroundFloat = playerNewInput.Player.PickUpFromGround.WasPressedThisFrame();
            //shoot=playerInput.Player.Shoot.ReadValue<Butt
            //shoot = playerInput.Player.Shoot.ReadValue<Button>();

        }
        catch
        {
            playerNewInput = new PlayerInput();
            playerNewInput.Player.Enable();
        }
        
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
    }
    
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
}
