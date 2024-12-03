
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class SelectedButton
{
    public InventorButton inventorButton;
    public Vector2Int pos;
    public SelectedButton(InventorButton button, Vector2Int pos)
    {
        inventorButton = button;
        this.pos = pos;
    }
}
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField]
    private InventoryPage[] inventoryPage;
    public  List<(ScriptableObject scriptableObject, int howMany)> itemsInInventory = new List<(ScriptableObject scriptableObject, int howMany)>();
    [SerializeField]
    private PageChangeButton[] pageChangeButton;
    public SelectedButton selectedButton=null;
    private int activePage;
    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < inventoryPage.Length; i++) {
            inventoryPage[i].GiveNumber(i);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        OpenPage(0);
    }
    public bool add(IViewable wiewable,int howMany)
    {
        

        foreach (InventoryPage page in inventoryPage)
        {

            if (wiewable.StackLimit() > 1)
            {
                if(page.AddStack(wiewable, howMany))
                {
                    int index = itemsInInventory.FindIndex(x => x.Item1 == wiewable.GetScriptableObject());
                    if (index != -1)
                    {
                        itemsInInventory[index] = (itemsInInventory[index].scriptableObject, itemsInInventory[index].howMany + howMany);
                    }
                    return true;
                }
            }
            Debug.Log("pivk upbast�3");
            if (page.CanGetObject(wiewable, howMany)) {

                itemsInInventory.Add((wiewable.GetScriptableObject(), howMany));
                return true;
            }
        }
        return false;

    }
    public void ChangeIViewableInventoryPosition(int  newButtonPos)
    {
        if ( inventoryPage[activePage].CanChangePosition(newButtonPos))
        {
            inventoryPage[activePage].inventorButtons[newButtonPos].Screen();
            inventoryPage[this.selectedButton.pos.x].ResetButtons(selectedButton);
            this.selectedButton = null;
        }
        
    }

    public void ChangePage(int page)
    {
        ClosePage(activePage);
        OpenPage(page);
        
    }
    public void ClosePage(int page)
    {
        inventoryPage[page].GetComponent<CanvasGroup>().alpha = 0;       // G�r�n�r yap
        inventoryPage[page].GetComponent<CanvasGroup>().interactable = false; // Etkile�imli yap
        inventoryPage[page].GetComponent<CanvasGroup>().blocksRaycasts = false; // Raycastlar� engelleme

        pageChangeButton[page].ChangeColorForNormal();
    }
    public void OpenPage(int page)
    {
        activePage = page;
        inventoryPage[page].GetComponent<CanvasGroup>().alpha = 1;       // G�r�n�r yap
        inventoryPage[page].GetComponent<CanvasGroup>().interactable = true; // Etkile�imli yap
        inventoryPage[page].GetComponent<CanvasGroup>().blocksRaycasts = true; // Raycastlar� engelleme
        pageChangeButton[page].ChangeColorForPressed();
    }
    public void CloseInventory()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;       // G�r�n�r yap
        this.GetComponent<CanvasGroup>().interactable = false; // Etkile�imli yap
        this.GetComponent<CanvasGroup>().blocksRaycasts = true; // Raycastlar� engelleme
    }
    // Update is called once per frame
    void Update()
    {

    }
}
