using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildDog : EnemySkeleton
{
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
    
    // Update is called once per frame
    public override void Update()
    {
       base.Update();
    }
    public override void Outline(Material material)
    {
        base.Outline(material); 
    }
    public override void TakeDamage(float damage, Player p)
    {
        //print(currentHealth);
        base.TakeDamage(damage,p);
        //EnemyHealthBar.ChangeBarScale(currentHealth/maxHealth);
    }
    public override void Death(Player p)
    {
        base.Death(p);
    }
}
