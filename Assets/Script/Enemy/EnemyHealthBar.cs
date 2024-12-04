using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
   public void ChangeBarScale(float scaleX)
    {
        gameObject.GetComponent<Transform>().transform.localScale = new Vector3(scaleX, 
            gameObject.GetComponent<Transform>().transform.localScale.y, gameObject.GetComponent<Transform>().transform.localScale.z);
    }
}
