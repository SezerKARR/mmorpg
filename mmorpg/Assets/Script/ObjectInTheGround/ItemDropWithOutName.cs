using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemDropWithOutName : ItemDrop
{

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

        StartCoroutine(WaitAndDestroy());
        base.Start();

    }

    IEnumerator WaitAndDestroy()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);
        
        Destroy(this.gameObject);
    }
}
