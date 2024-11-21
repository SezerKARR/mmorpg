using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ItemDrop : MonoBehaviour, IPickedUpAble
{
    public TMP_Text itemName;
    public ScriptableObject scriptableObject;
    public virtual GameObject GetGameObject()
    {
        return this.gameObject;
    }
    public ScriptableObject GetScriptableObject()
    {
        return this.scriptableObject;
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
