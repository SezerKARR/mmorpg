using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Script.UI
{
    public class Confirm : MonoBehaviour
    {
        [FormerlySerializedAs("ConfirmYesToDropButton")] public Button confirmYesToDropButton;
        [FormerlySerializedAs("ConfirmNoButton")] public Button confirmNoButton;
        
        public TextMeshProUGUI confirmText;
        private UIEvent.ConfirmAction _yes;
        private void Awake()
        {
            UIEvent.OnOpenConfirm += OpenConfirm;
            confirmNoButton.onClick.AddListener(CloseConfirm);
            confirmYesToDropButton.onClick.AddListener(() => _yes?.Invoke());
            confirmYesToDropButton.onClick.AddListener(CloseConfirm);
            this.gameObject.SetActive(false);
       
        }

        private void OpenConfirm(string confirmString, UIEvent.ConfirmAction yesConfirm)
        {
            this.confirmText.text = confirmString;
            _yes = yesConfirm;
            this.gameObject.SetActive(true);
        }
        private void CloseConfirm()
        {
           this.gameObject.SetActive(false);

        }
    }
}
