using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PageChangeButton : MonoBehaviour
{
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
        InventoryManager.Instance.ChangePage(page);
    }
    // Update is called once per frame
    
}
