using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour
{
    public ScriptableObject upgradeItemsSO;
    public Sprite sprite;
    public InventorObject[] inventorObjects;
   // private int x=5;
    private int y;
    private void Awake()
    {
        
    }
    private void OnMouseDown()
    {
        print("geldi");
    }
    /*private void Start()
    {
        for (int i = 0; i < inventorySystems.Length; i++)
        {
            for (int j = 0; j < inventorySystems[i].buttonGameObject.Length; j++)
            {
                if (inventorySystems[i].GetScriptableObjects[j] == null)
                {
                    inventorySystems[i].GetScriptableObjects[j] = Instantiate()
                    return;

                }
            }
            x = 0;
        }
    }*/
    private void Update()
    {
       
            /*if (Input.GetMouseButtonDown(0))
                Debug.Log("Pressed left-click.");

            if (Input.GetMouseButtonDown(1))
                Debug.Log("Pressed right-click.");

            if (Input.GetMouseButtonDown(2)) 
                  GetObject(upgradeItemsSO); 
           */

    }

   
    
    public void GetObject(ScriptableObject getObject)
    {
      foreach(var item in inventorObjects)
      {
            try
            {
                if (item.scriptableObject == null && inventorObjects[y + 5].scriptableObject == null)
                {
                    item.howMany++;
                    item.scriptableObject = getObject;
                    inventorObjects[y + 5].scriptableObject = getObject;
                    item.ChangeSprite(2, sprite);
                    break;
                }
            }
            catch
            {
                print("envanter dolu");
            }
            y++;
      }
        y = 0;
    }
    
}
