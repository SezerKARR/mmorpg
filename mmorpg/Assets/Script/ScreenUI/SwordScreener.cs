using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class SwordScreener : MonoBehaviour, IScreenAble
{
    
    public TMP_Text attackValueText;
    public TMP_Text magicalValueText;
    public TMP_Text attackSpeedText;
    public TMP_Text level;
    public void Screen(ScriptableObject scriptableObject)
    {
       SwordSO swordSO = (SwordSO)scriptableObject;
        attackValueText.text = ("Attack Value " + swordSO.minAndMaxAttackValue.ToString());
        magicalValueText.text=("Magic Attack Value " +swordSO.minAndMaxMagicalAttackValue.ToString());
        attackSpeedText.text = ("Attack Speed " +swordSO.attackSpeed.ToString());
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    
}
