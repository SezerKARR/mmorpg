using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Zenject;

namespace Script.Player
{
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
        [FormerlySerializedAs("_inventoryManager")] [Inject][SerializeField] private InventoryManager inventoryManager;
        public static event Action OnPickUpPressed;
        public static event Action OnNormalAttackPressed;
        public static event Action<Vector2> OnMovePressed;
        public static event Action OnClickLeftPressed;
        public static event Action OnIdlePerformed;

        public static event Action OnGroundClicked; 
        // Start is called before the first frame update
        void Awake()
        {
            _playerNewInput = new PlayerInput();
        }
        void OnEnable()
        {
            _playerNewInput.Player.Enable();
            _playerNewInput.Player.Move.canceled += _ => OnIdlePerformed?.Invoke();
            _playerNewInput.Player.Shoot.canceled += _ => OnIdlePerformed?.Invoke();
            _playerNewInput.Player.PickUpFromGround.performed += _ => OnPickUpPressed?.Invoke();
            _playerNewInput.Player.ClickLeft.performed += _ => OnClickLeftPressed?.Invoke();
            _playerNewInput.Player.Shoot.performed += _ => OnNormalAttackPressed?.Invoke();
            _playerNewInput.Player.Move.performed += context => OnMovePressed?.Invoke(context.ReadValue<Vector2>());
            OnClickLeftPressed += LeftClickClicked;

        }

        void OnDisable()
        {
        
            _playerNewInput.Player.PickUpFromGround.performed -= _ => OnPickUpPressed?.Invoke();
            _playerNewInput.Player.Shoot.performed -= _ => OnNormalAttackPressed?.Invoke();
            _playerNewInput.Player.Move.performed -= context => OnMovePressed?.Invoke(context.ReadValue<Vector2>());
            _playerNewInput.Player.PickUpFromGround.performed -= _ => OnPickUpPressed?.Invoke();
            _playerNewInput.Player.Disable();
        }
   
        private void LeftClickClicked()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Camera.main != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
          
                    if(hit.collider != null)
                    {
                        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                        {
                            OnGroundClicked?.Invoke();
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
        }
        private void ChangeSelectedObjectOutline(Collider2D collider2D)

        {
            if (selectedObject != null)
            {

                selectedObject.GetComponent<IOutlineAble>().Clicked(_normalMaterial);
                selectedObject.GetComponent<IOutlineAble>().ResetClicked();

            }
            selectedObject = collider2D.gameObject;

            _normalMaterial = collider2D.GetComponent<IOutlineAble>().GetMaterial();
            if (collider2D.CompareTag("Enemy"))
            {

                selectedObject.GetComponent<IOutlineAble>().Clicked(outlineRed);


            }
            else if (collider2D.CompareTag("Npc"))
            {

                selectedObject.GetComponent<IOutlineAble>().Clicked(outlineGreen);

            }
        }
    }
}
