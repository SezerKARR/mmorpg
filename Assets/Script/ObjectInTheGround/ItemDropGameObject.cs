using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDropGameObject : ItemDrop
{
   
    
    public GameObject itemDropWithOutName;
    

    public override void DestroyObject()
    {
        base.DestroyObject();
    }

    public override GameObject GetGameObject()
    {
        return base.GetGameObject();
        
    }
    

    public override void Update()
    {
        base.Update();
    }

    public override void Start()
    {
       
        StartCoroutine(WaitAndDeleteName());
        base.Start();
    }
    
    IEnumerator WaitAndDeleteName()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);
        this.gameObject.SetActive(false);
        GameObject newItemDrop = Instantiate(itemDropWithOutName, this.transform.position, Quaternion.identity);
        if (objectAbstract.canEveryBodyTake)
        {
            ItemDropWithOutName itemDropComponent = newItemDrop.GetComponent<ItemDropWithOutName>();
            itemDropComponent.itemName.text = this.itemName.text;
            itemDropComponent.howMany = this.howMany;
            itemDropComponent.objectAbstract = this.objectAbstract;
        }
        
        Destroy(this.gameObject);
    }
}
