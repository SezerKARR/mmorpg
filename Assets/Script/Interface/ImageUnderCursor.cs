using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageUnderCursor : MonoBehaviour
{
    RectTransform rectTransform;
    private void Awake()
    {
        UIManager.OnUpgradePanelNeed += Close;
        //InventoryManager.onButtonSelect += Open;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.position = Input.mousePosition;
        if(GetComponent<Image>().sprite==null )gameObject.SetActive(false);
    }
    private void Close(IInventorObjectable dummy)
    {
        this.gameObject.SetActive(false);
    }
    private void Open(ObjectAbstract obje)
    {
        GetComponent<Image>().sprite = obje.Image;
        gameObject.SetActive(true);
    }
    void Update()
    {
        

        rectTransform.position = Input.mousePosition;

    }
}