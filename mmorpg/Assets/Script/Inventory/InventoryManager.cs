
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField]
    private InventoryPage[] inventoryPage;
    public  List<(ScriptableObject scriptableObject, int howMany)> itemsInInventory = new List<(ScriptableObject scriptableObject, int howMany)>();
    [SerializeField]
    private PageChangeButton[] pageChangeButton;
    private int activePage;
    private void Awake()
    {
        Instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        OpenPage(0);
    }
    public bool add(IWiewable wiewable,int howMany)
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
            Debug.Log("pivk upbastý3");
            if (page.CanGetObject(wiewable, howMany)) {

                itemsInInventory.Add((wiewable.GetScriptableObject(), howMany));
                return true;
            }
        }
        return false;

    }
    public void ChangePage(int page)
    {
        ClosePage(activePage);
        OpenPage(page);
    }
    public void ClosePage(int page)
    {
        inventoryPage[page].GetComponent<CanvasGroup>().alpha = 0;       // Görünür yap
        inventoryPage[page].GetComponent<CanvasGroup>().interactable = false; // Etkileþimli yap
        inventoryPage[page].GetComponent<CanvasGroup>().blocksRaycasts = true; // Raycastlarý engelleme

        pageChangeButton[page].ChangeColorForNormal();
    }
    public void OpenPage(int page)
    {
        activePage = page;
        inventoryPage[page].GetComponent<CanvasGroup>().alpha = 1;       // Görünür yap
        inventoryPage[page].GetComponent<CanvasGroup>().interactable = true; // Etkileþimli yap
        inventoryPage[page].GetComponent<CanvasGroup>().blocksRaycasts = false; // Raycastlarý engelleme
        pageChangeButton[page].ChangeColorForPressed();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
