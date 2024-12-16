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
    public TMP_Text Playername;
    Vector3 RandomPositionByObjectCircle()
    {
        Vector2 position = new Vector2(Random.Range(transform.position.x - 1f, transform.position.x + 1f), Random.Range(transform.position.y - 1f, transform.position.y + 1f));
        return new Vector3(position.x, position.y, 0);
    }
   

    public virtual void SetOther(ObjectAbstract item ,string playerName)
    {
        this.transform.position = RandomPositionByObjectCircle();
        objectAbstract = item ;
        if (item.stackLimit > 1)
        {
            howMany = 75;
        }
        Playername.text = playerName;
    }
    
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
