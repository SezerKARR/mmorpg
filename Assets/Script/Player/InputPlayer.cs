using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
        OnClickLeftPressed += LeftClickClicked;
        playerNewInput.Player.Enable();
        playerNewInput.Player.Move.canceled += context => OnIdlePerformed?.Invoke();
        playerNewInput.Player.Shoot.canceled += context => OnIdlePerformed?.Invoke();
        // Doðrudan event tetikleme
        playerNewInput.Player.PickUpFromGround.performed += context => OnPickUpPressed?.Invoke();
        playerNewInput.Player.ClickLeft.performed += context => OnClickLeftPressed?.Invoke();
        playerNewInput.Player.Shoot.performed += context => OnNormalAttackPressed?.Invoke();
        playerNewInput.Player.Move.performed += context => OnMovePressed?.Invoke(context.ReadValue<Vector2>());
    }
    void OnEnable()
    {
       
        

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
            

        }
    }
 
    private void LeftClickClicked()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // Eðer fare UI'nin üzerinde deðilse, tilemap'e týklamaya devam edebiliriz
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Raycast ile tilemap üzerinde kontrol yapýyoruz
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            // Eðer tilemap objesiyle çarpýþma varsa, iþlem yapýlýr
            if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                if (InventoryManager.Instance.selectedButton != null)
                {
                    if(InventoryManager.Instance.selectedButton is IDropable dropable)
                    {
                        TooltipManager.Instance.confirm.SetActive(true);
                    }
                    
                }
               
            }
            else if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("UI öðesi üzerine týklanýyor veya baþka bir nesne");
            }
        }

       
        //Collider2D hitCollider = hit.collider;
        //// Eðer bir nesneye týklandýysa
        //if (hitCollider == null) return;
        //else if (hitCollider.GetComponent<IOutlineAble>() != null)
        //{
        //    ChangeSelectedObjectOutline(hitCollider);
        //}
        // if (hitCollider.CompareTag("Ground"))
        //{
        //    
        //}
    }
    private void ChangeSelectedObjectOutline(Collider2D collider)

    {
        if (selectedObject != null)
        {

            selectedObject.GetComponent<IOutlineAble>().Outline(normalMaterial);

        }
        selectedObject = collider.gameObject;

        normalMaterial = collider.GetComponent<IOutlineAble>().GetMaterial();
        if (collider.tag == "Enemy")
        {

            selectedObject.GetComponent<IOutlineAble>().Outline(outlineRed);


        }
        else if (collider.tag == "Npc")
        {

            selectedObject.GetComponent<IOutlineAble>().Outline(outlineGreen);

        }
    }
}
