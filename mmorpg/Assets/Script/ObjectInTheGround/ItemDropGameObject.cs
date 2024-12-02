using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDropGameObject : ItemDrop
{
    public TMP_Text Playername;
    
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
        this.howMany = 1;
        itemName.text =IWievableScriptableObject.GetName()+" x"+this.howMany ;
        StartCoroutine(WaitAndDeleteName());
        base.Start();
    }
    
    IEnumerator WaitAndDeleteName()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);
        this.gameObject.SetActive(false);
        GameObject newItemDrop = Instantiate(itemDropWithOutName, this.transform.position, Quaternion.identity);
        ItemDropWithOutName itemDropComponent = newItemDrop.GetComponent<ItemDropWithOutName>();
        itemDropComponent.itemName.text = this.itemName.text;
        itemDropComponent.howMany = this.howMany;
        itemDropComponent.IWievableScriptableObject = this.IWievableScriptableObject;
        Destroy(this.gameObject);
    }
}
