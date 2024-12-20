using System.Collections;
using System.Collections.Generic;
using Script.Player;
using UnityEngine;
using UnityEngine.Serialization;

public class DeteckCollider : MonoBehaviour
{
    [FormerlySerializedAs("playerManager")] public Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.gameObject.GetComponent<IDamageAble>() != null);
        if (collision.gameObject.GetComponent<IDamageAble>() != null)
        {
            player.GiveNormalDamage(collision.gameObject.GetComponent<IDamageAble>());
            
        }
        
    }
}
