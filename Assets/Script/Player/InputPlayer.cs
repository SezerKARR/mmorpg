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
    private PickUpDetector InteractionDetector;

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
        // Do�rudan event tetikleme
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
        /*try
        {
            //todo: buras� de�i�ecek playerInput.Player.move.performed+=ctx=>(ctx.readvalue<vector2>
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
            

        }*/
    }
 
    private void LeftClickClicked()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // E�er fare UI'nin �zerinde de�ilse, tilemap'e t�klamaya devam edebiliriz
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Raycast ile tilemap �zerinde kontrol yap�yoruz
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            // E�er tilemap objesiyle �arp��ma varsa, i�lem yap�l�r
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    if (InventoryManager.Instance.selectedButton != null)
                    {
                        if (InventoryManager.Instance.selectedButton.inventorObjectAble is IDropable dropable)
                        {
                            if (dropable.GetPlayerCanDrop())
                            {
                                string confirmText = $"{dropable.GetDropName()} yere atmak istedi�ine emin misin";
                                UIManager.Instance.OpenConfirm(confirmText, InventoryManager.Instance);
                            }
                            else { Debug.Log("bu obje yere at�lamaz"); }
                        }

                    }
                    Debug.Log(hit.collider.gameObject);
                }
                else if (hit.collider.gameObject.CompareTag("Equipment"))
                {

                }
                else if(hit.collider.gameObject.GetComponent<IOutlineAble>() != null)
                {
                    ChangeSelectedObjectOutline(hit.collider);
                    Debug.Log(hit.collider.gameObject);
                }
            }
            
        }

       
        //Collider2D hitCollider = hit.collider;
        //// E�er bir nesneye t�kland�ysa
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

            selectedObject.GetComponent<IOutlineAble>().Clicked(normalMaterial);
            selectedObject.GetComponent<IOutlineAble>().ResetClicked();

        }
        selectedObject = collider.gameObject;

        normalMaterial = collider.GetComponent<IOutlineAble>().GetMaterial();
        if (collider.tag == "Enemy")
        {

            selectedObject.GetComponent<IOutlineAble>().Clicked(outlineRed);


        }
        else if (collider.tag == "Npc")
        {

            selectedObject.GetComponent<IOutlineAble>().Clicked(outlineGreen);

        }
    }
}
