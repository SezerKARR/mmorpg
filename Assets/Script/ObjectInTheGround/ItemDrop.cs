using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ItemDrop : MonoBehaviour, IPickedUpAble
{
    public TMP_Text itemName;
    public IDropable dropable;
    public int howMany=1;
    public virtual GameObject GetGameObject()
    {
        return this.gameObject;
    }
    public IInventorObjectable GetInventorObjectAble()
    {
        return this.dropable;
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
            itemName.text = dropable.GetDropName() + " x" + this.howMany;
            return;
        }
        else
        {
            itemName.text = dropable.GetDropName() ;
            return;
        }
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

}
