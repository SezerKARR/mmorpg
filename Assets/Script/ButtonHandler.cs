using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Button ConfirmYesToDrop;

    void Start()
    {
        ConfirmYesToDrop.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // Fonksiyon çaðrýsý
    }
}