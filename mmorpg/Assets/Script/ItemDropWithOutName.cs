using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemDropWithOutName : MonoBehaviour,IPickedUpAble
{
    public TMP_Text itemName;

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    private void Start()
    {
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);
        
        Destroy(this.gameObject);
    }
}
