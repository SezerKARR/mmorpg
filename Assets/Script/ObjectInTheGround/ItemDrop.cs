using System.Collections;
using System.Collections.Generic;
using Script.Inventory.Objects;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class ItemDrop : MonoBehaviour, IPickedUpAble
{
    public TMP_Text itemName;
    public ObjectAbstract objectAbstract;
    public int howMany=1;
    public virtual GameObject GetGameObject()
    {
        return this.gameObject;
    }
    public ObjectAbstract GetObject()
    {
        return this.objectAbstract;
    }
    public int GetHowMany()
    {
        return this.howMany;
    }
    
    public virtual void DestroyObject()
    {

    }
    // Start is called before the first frame update
    public virtual void Start()
    {
        if (this.howMany > 1)
        {
            itemName.text = objectAbstract.DropName + " x" + this.howMany;
            return;
        }
        else
        {
            itemName.text = objectAbstract.DropName ;
            return;
        }
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

}
