using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Script.UI
{
    public class Confirm : MonoBehaviour
    {
        public Button confirmYesButton;
        public Button confirmNoButton;
        private UnityAction _confirmYesAction, _confirmNoAction;
        public TextMeshProUGUI confirmText;
        private void Awake()
        {
            UIEvent.OnOpenConfirm += Open;
            confirmNoButton.onClick.AddListener(()=>ButtonPressed(_confirmNoAction));
            confirmYesButton.onClick.AddListener(()=>ButtonPressed(_confirmYesAction));
            this.gameObject.SetActive(false);
       
        }

        private void Open(string confirmString, UnityAction yesConfirm, UnityAction cancelConfirm)
        {
            confirmText.text = confirmString;
            _confirmYesAction = yesConfirm;
            _confirmNoAction = cancelConfirm;
            this.gameObject.SetActive(true);
        }
        
        private void ButtonPressed(UnityAction buttonEvent)
        {
            buttonEvent?.Invoke();
            this.gameObject.SetActive(false);

        }
    }
}
