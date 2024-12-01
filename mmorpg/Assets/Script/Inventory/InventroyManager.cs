
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class InventroyManager : MonoBehaviour
{
    public static InventroyManager Instance;
    private InventoryPage[] InventoryPage;
    public  List<(ScriptableObject scriptableObject, int howMany)> itemsInInventory = new List<(ScriptableObject scriptableObject, int howMany)>();
    private void Awake()
    {
        Instance = this;
        InventoryPage = GetComponentsInChildren<InventoryPage>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    public bool add(IWiewable wiewable,int howMany)
    {
        

        foreach (InventoryPage page in InventoryPage)
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
    
    // Update is called once per frame
    void Update()
    {

    }
}
