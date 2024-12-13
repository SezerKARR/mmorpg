using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Zenject;

public class InputPlayer : MonoBehaviour
{
    private Vector2 _inputWalkVector;
    private float _inputShootFloat;
    private bool _inputPickUpFromGroundFloat;
    private float _inputClickFloat;
    private PlayerInput _playerNewInput;
    public Material outlineGreen;
    public Material outlineRed;
    private Material _normalMaterial;
    public GameObject selectedObject; 
    [Inject][SerializeField] private InventoryManager _inventoryManager;
    public static event Action OnPickUpPressed;
    public static event Action OnNormalAttackPressed;
    public static event Action<Vector2> OnMovePressed;
    public static event Action OnClickLeftPressed;
    public static event Action OnIdlePerformed;
    // Start is called before the first frame update
    void Awake()
    {
        _playerNewInput = new PlayerInput();
        _playerNewInput.Player.Enable();
        OnClickLeftPressed += LeftClickClicked;
        _playerNewInput.Player.Enable();
        _playerNewInput.Player.Move.canceled += context => OnIdlePerformed?.Invoke();
        _playerNewInput.Player.Shoot.canceled += context => OnIdlePerformed?.Invoke();
        // Do�rudan event tetikleme
        _playerNewInput.Player.PickUpFromGround.performed += context => OnPickUpPressed?.Invoke();
        _playerNewInput.Player.ClickLeft.performed += context => OnClickLeftPressed?.Invoke();
        _playerNewInput.Player.Shoot.performed += context => OnNormalAttackPressed?.Invoke();
        _playerNewInput.Player.Move.performed += context => OnMovePressed?.Invoke(context.ReadValue<Vector2>());
    }
    void OnEnable()
    {
       
        

    }

    void OnDisable()
    {
        _playerNewInput.Player.Disable();
        _playerNewInput.Player.PickUpFromGround.performed -= context => OnPickUpPressed?.Invoke();
        _playerNewInput.Player.Shoot.performed -= context => OnNormalAttackPressed?.Invoke();
        _playerNewInput.Player.Move.performed -= context => OnMovePressed?.Invoke(context.ReadValue<Vector2>());
        //playerNewInput.Player.Move.canceled += context => OnMovePressed?.Invoke(Vector2.zero);
        _playerNewInput.Player.PickUpFromGround.performed -= context => OnPickUpPressed?.Invoke();
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
                    if (_inventoryManager.objectController != null)
                    {
                        _inventoryManager.DropObject();
                       

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

    }
    private void ChangeSelectedObjectOutline(Collider2D collider)

    {
        if (selectedObject != null)
        {

            selectedObject.GetComponent<IOutlineAble>().Clicked(_normalMaterial);
            selectedObject.GetComponent<IOutlineAble>().ResetClicked();

        }
        selectedObject = collider.gameObject;

        _normalMaterial = collider.GetComponent<IOutlineAble>().GetMaterial();
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
