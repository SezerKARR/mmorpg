using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Confirm : MonoBehaviour
{
    public Button ConfirmYesToDropButton;
    public Button ConfirmNoButton;
    public IWaitConfirmable waitConfirmable;
    public TextMeshProUGUI confirmText;
    private void Awake()
    {
        ConfirmNoButton.onClick.AddListener(()=> ConfirmCall(false));
        ConfirmYesToDropButton.onClick.AddListener(() => ConfirmCall(true));
       
    }
    public void OpenConfirm(string confirmText,IWaitConfirmable waitConfirmable)
    {
        this.confirmText.text = confirmText;
        this.gameObject.SetActive(true);
        this.waitConfirmable = waitConfirmable;
    }
    
    private void ConfirmCall(bool confirmValue)
    {
        this.gameObject.SetActive(false);
        waitConfirmable.ConfirmValue(confirmValue);
        waitConfirmable = null;

    }
}
