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
        itemName.text = scriptableObject.name;
        StartCoroutine(WaitAndDeleteName());
        base.Start();
    }
    
    IEnumerator WaitAndDeleteName()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);
        this.gameObject.SetActive(false);
        Instantiate(itemDropWithOutName, this.transform.position, Quaternion.identity);
        itemDropWithOutName.GetComponent<ItemDropWithOutName>().itemName.text= this.itemName.text;
        Destroy(this.gameObject);
    }
}
