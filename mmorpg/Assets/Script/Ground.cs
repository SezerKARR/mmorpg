using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ground : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("�TEM� ATMAK MI �ST�YORSUN");
        if (InventoryManager.Instance.selectedButton != null)
        {
            Debug.Log("�TEM� ATMAK MI �ST�YORSUN");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
