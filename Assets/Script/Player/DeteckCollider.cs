using System.Collections;
using System.Collections.Generic;
using Script.Interface;
using Script.Player;
using UnityEngine;
using UnityEngine.Serialization;

public class DeteckCollider : MonoBehaviour
{
    [FormerlySerializedAs("player")] [FormerlySerializedAs("playera")] [FormerlySerializedAs("playerManager")] public PlayerController playerController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.gameObject.GetComponent<IDamageAble>() != null);
        if (collision.gameObject.GetComponent<IDamageAble>() != null)
        {
            playerController.GiveNormalDamage(collision.gameObject.GetComponent<IDamageAble>());
            
        }
        
    }
}
