using System.Collections;
using System.Collections.Generic;
using Script.ScriptableObject.Equipment;
using TMPro;
using UnityEngine;

public class ToolTip : MonoBehaviour,ITooltipAble

{
    public TextMeshProUGUI swordNameText;
    public TextMeshProUGUI attackValueText;
    public TextMeshProUGUI magicalValueText;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI[] bonusesText;
    public TextMeshProUGUI wearableLayer;
    public TextMeshProUGUI wearAbleText;
    public void Screen(IInventorObjectable inventorObjectable)
    {
        
        if (inventorObjectable is SwordSo sword)
        {

            SetText(swordNameText, sword.name);
            SetText(attackValueText, ("Attack Value " + sword.minAndMaxAttackValue[sword.currentPlus].ToString())) ;
            if (sword.minAndMaxMagicalAttackValue.Count>0){
                SetText(magicalValueText, ("Magic Attack Value " + sword.minAndMaxMagicalAttackValue[sword.currentPlus].ToString()));
            }
            
            SetText(attackSpeedText, ("Attack Speed " + sword.attackSpeed[sword.currentPlus].ToString())) ;
            SetText(levelText, ("From level" + sword.level.ToString())) ;
            
            foreach (var bonus in sword.bonuses)
            {
                int i = 0;
                if (bonus.bonusName != null)
                {
                    SetText(bonusesText[i], bonus.bonusValue.ToString()) ;
                }
                
            }
            string b = "";
            foreach (Character character in sword.canUseCharacters)
            {
                b += character.ToString() + " ";
            }
            
            SetText(wearAbleText, b);
            wearableLayer.gameObject.SetActive(wearAbleText.gameObject.activeSelf);
        }

    }
    private void SetText(TextMeshProUGUI textMeshProUGUI,string writeText)
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
