using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public  class UpgradeItemScreener : MonoBehaviour, IScreenAble
{
    public  SwordSO UpgradeItems;
    public TMP_Text nameTMP;
    public TMP_Text descriptionTMP;

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Screen(ScriptableObject scriptableObject)
    {
        nameTMP.text = scriptableObject.name;
       descriptionTMP.text = scriptableObject.GetComponent<UpgradeItemsSO>().info.ToString();
        this.gameObject.SetActive(true);
    }
}
