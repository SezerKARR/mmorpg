using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemDropWithOutName : MonoBehaviour
{
    public TMP_Text itemName;
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
