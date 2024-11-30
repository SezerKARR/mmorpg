using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NpcBone : MonoBehaviour,IOutlineAble
{
    public string npcName;
    public Material outlineGreen;
    private Material normalMaterial;

    public virtual void Outline(Material material)
    {
        this.GetComponent<SpriteRenderer>().material = material;
    }
    public virtual Material GetMaterial()
    {
        return this.GetComponent<SpriteRenderer>().material;
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        normalMaterial=GetComponent<SpriteRenderer>().material;    
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    public virtual void InteractPanel()
    {

    }
    
    /*public virtual void Outline(Color color)
    {
        if (color == Color.green)
        {
            this.GetComponent<SpriteRenderer>().material = outlineGreen;
        }
        else if (color == Color.gray)
        {

            this.GetComponent<SpriteRenderer>().material = normalMaterial;
        }
    }*/
}
