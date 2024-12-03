using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    public TextMeshProUGUI swordNameText;
    public TextMeshProUGUI attackValueText;
    public TextMeshProUGUI magicalValueText;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI[] bonusesText;
    public TextMeshProUGUI wearableLayer;
    public TextMeshProUGUI wearAbleText;
    public void Screen(IViewable scriptableObject)
    {
        
        if (scriptableObject is SwordSO sword)
        {

            Debug.Log(scriptableObject);
            SetText(swordNameText, sword.name);
            SetText(attackValueText, ("Attack Value " + sword.minAndMaxAttackValue[sword.currentPlus].ToString())) ;
            if (sword.minAndMaxMagicalAttackValue[sword.currentPlus].ToString() != ""){
                SetText(magicalValueText, ("Magic Attack Value " + sword.minAndMaxMagicalAttackValue[sword.currentPlus].ToString()));
            }
            
            SetText(attackSpeedText, ("Attack Speed " + sword.attackSpeed[sword.currentPlus].ToString())) ;
            SetText(levelText, ("From level" + sword.level.ToString())) ;
            
            foreach (var bonus in sword.bonuses)
            {
                Debug.Log(bonus);
                int i = 0;
                if (bonus != null)
                {
                    SetText(bonusesText[i], bonus) ;
                }
                
            }
            string b = "";
            foreach (Character character in sword.canUseCharacters)
            {
                b += character.ToString() + " ";
            }
            Debug.Log(b);
            SetText(wearAbleText, b);
            wearableLayer.gameObject.SetActive(wearAbleText.gameObject.activeSelf);
        }

    }
    public void SetText(TextMeshProUGUI textMeshProUGUI,string writeText)
    {
        if (writeText != "")
        {
            textMeshProUGUI.gameObject.SetActive(true);
            textMeshProUGUI.text = writeText;
        }
        }
        public void hide()
    {
        foreach (var bonus in bonusesText)
        {
            bonus.text = "";
            bonus.gameObject.SetActive(false);
        }
    }
}
