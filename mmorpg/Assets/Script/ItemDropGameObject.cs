using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDropGameObject : MonoBehaviour
{
    public TMP_Text Playername;
    public TMP_Text itemName;
    public GameObject itemDropWithOutName;
    

    private void Start()
    {
        StartCoroutine(WaitAndDeleteName());
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
