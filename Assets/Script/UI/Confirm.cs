using ModestTree.Util;
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
        private UIEvent.ConfirmAction yes;
        private UIEvent.ConfirmAction no;
        private void Awake()
        {
            UIEvent.OnOpenConfirm += OpenConfirm;
            confirmNoButton.onClick.AddListener(()=> ConfirmCall(false));
            confirmYesToDropButton.onClick.AddListener(() => ConfirmCall(true));
            this.gameObject.SetActive(false);
       
        }

        private void OpenConfirm(string confirmString, UIEvent.ConfirmAction yesConfirm, UIEvent.ConfirmAction noConfirm)
        {
            this.confirmText.text = confirmString;
            yes = yesConfirm;
            no = noConfirm;
            this.gameObject.SetActive(true);
        }
        private void ConfirmCall(bool confirmValue)
        {
            if(confirmValue==true) yes?.Invoke();
            else no?.Invoke();
           this.gameObject.SetActive(false);

        }
    }
}
