using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageUnderCursor : MonoBehaviour
{
    public static ImageUnderCursor Instance;
    RectTransform rectTransform;
    private void Awake()
    {
        UIManager.OnUpgradePanelNeed += Close;
        //InventoryManager.onButtonSelect += Open;
        Instance = this;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.position = Input.mousePosition;
        if(GetComponent<Image>().sprite==null )gameObject.SetActive(false);
    }
    private void Close(IInventorObjectable dummy)
    {
        this.gameObject.SetActive(false);
    }
   /* private void Open(InventorButton button)
    {
        GetComponent<Image>().sprite = button.inventorObjectAble.GetSprite();
        gameObject.SetActive(true);
    }*/
    void Update()
    {
        

        rectTransform.position = Input.mousePosition;

    }
}