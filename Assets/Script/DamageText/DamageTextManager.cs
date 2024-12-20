
using System.Collections;
using System.Collections.Generic;
using Script.Player;
using UnityEngine;

public class DamageTextManager : MonoBehaviour
{
    public static DamageTextManager instance;
    [SerializeField]
    private GameObject damageTextPrefab;
    [SerializeField]
    private GameObject critDamageTextPrefab;
    [SerializeField]
    private GameObject skillDamageTextPrefab;
    private void Awake()
    {
        instance = this;
    }
    public void CreateDamageText(string damage,Vector2 position,DamageType damageType)
    {
        GameObject damageText=null;
        switch (damageType)
        {
            case DamageType.Normal:
                damageText = Instantiate(damageTextPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                break;
            case DamageType.Crit:
                damageText = Instantiate(critDamageTextPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                break;
            case DamageType.Magical:
                damageText = Instantiate(critDamageTextPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                break;
        }
        
        damageText.GetComponent<DamageText>().Initialize(damage);
    }
}
