using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PageChangeButton : MonoBehaviour
{
    [Inject] private InventoryManager inventoryManager;
    public Color pressedColor;
    public Color normalColor;
    public int page;

    public void ChangeColorForPressed()
    {
        this.GameObject().GetComponent<Image>().color = pressedColor;
    }
    public void ChangeColorForNormal()
    {
        this.GameObject().GetComponent<Image>().color = normalColor;
    }
    // Start is called before the first frame update
    void Awake()
    {
        this.GameObject().GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        inventoryManager.ChangePage(page);
    }
    // Update is called once per frame
    
}
