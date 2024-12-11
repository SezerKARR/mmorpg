using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


    public class InventoryView : MonoBehaviour
    {
        private Button _button;

        public UnityAction ButtonClicked;

        private void Awake()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        public void SetPosition(Vector2 position) => transform.position = position;

        private void OnButtonClick() => ButtonClicked?.Invoke();
    }
