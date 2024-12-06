using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ItemDrop : MonoBehaviour, IPickedUpAble
{
    public TMP_Text itemName;
    public IInventorObjectAble inventorObjectAble;
    public int howMany=1;
    public virtual GameObject GetGameObject()
    {
        return this.gameObject;
    }
    public IInventorObjectAble GetInventorObjectAble()
    {
        return this.inventorObjectAble;
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
        itemName.text = inventorObjectAble.GetName() + " x" + this.howMany;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

}
