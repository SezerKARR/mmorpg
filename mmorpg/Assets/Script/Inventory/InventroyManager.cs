
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventroyManager : MonoBehaviour
{
    public static InventroyManager Instance;
    private InventoryPage[] InventoryPage;
    private void Awake()
    {
        Instance = this;
        InventoryPage = GetComponentsInChildren<InventoryPage>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    public bool add(IWiewable wiewable)
    {
        
        foreach (InventoryPage page in InventoryPage)
        {
            Debug.Log("pivk upbastý3");
            if ( page.CanGetObject(wiewable))return true;
        }
        return false;

    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
