using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ItemDrop : MonoBehaviour, IPickedUpAble
{
    public TMP_Text itemName;
    public IWiewable IWievableScriptableObject;
    public virtual GameObject GetGameObject()
    {
        return this.gameObject;
    }
    public IWiewable GetIWievAble()
    {
        return this.IWievableScriptableObject;
    }
    public virtual void DestroyObject()
    {

    }
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    
}
