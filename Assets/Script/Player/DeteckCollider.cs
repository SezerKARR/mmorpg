using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteckCollider : MonoBehaviour
{
    public Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.gameObject.GetComponent<IDamageAble>() != null);
        if (collision.gameObject.GetComponent<IDamageAble>() != null)
        {
            player.GiveNormalDamage(collision.gameObject.GetComponent<IDamageAble>());
            
        }
        
    }
}
