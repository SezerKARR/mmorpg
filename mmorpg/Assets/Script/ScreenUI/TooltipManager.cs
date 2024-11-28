using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class TooltipManager : MonoBehaviour
{
    public static TooltipManager instance;
    public ToolTip tooltip;
    
    public ScriptableObject swords;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Debug.Log(tooltip.GameObject().activeSelf);
              
    }
    private void Update() {
        if (UIManager.Instance.GetUIElementUnderPointer() != null&&tooltip.GameObject().activeSelf==false)
        {
            if (UIManager.Instance.GetUIElementUnderPointer().GetComponent<IWiewable>() != null)
            {
                
                Screen(swords);
            }
        }
    }

    /*public void screen(ScriptableObject scriptableObject)
    {
        tooltip.enabled = true;
        if (scriptableObject is UpgradeItemsSO sword)
        { 
            tooltip.swordNameText.text = sword.name;
            tooltip.attackValueText.text = sword.info;
            tooltip.swordNameText.enabled = true;
            tooltip.attackValueText.enabled = true;
        }
        
    }*/
    public void Screen(ScriptableObject scriptableObject)
    {
        tooltip.GameObject().SetActive(true);
        if(scriptableObject is SwordSO sword)
        {

            Debug.Log(scriptableObject);
            tooltip.swordNameText.text = sword.name;
            tooltip.attackValueText.text = ("Attack Value " + sword.minAndMaxAttackValue[sword.currentPlus].ToString());
            tooltip.magicalValueText.text = ("Magic Attack Value " + sword.minAndMaxMagicalAttackValue[sword.currentPlus].ToString());
            tooltip.attackSpeedText.text = ("Attack Speed " + sword.attackSpeed[sword.currentPlus].ToString());
            tooltip.levelText.text=("From level"+ sword.level.ToString());
            /*foreach (var bonus in sword.bonuses)
            {
                int i = 0;
                if (bonus != null)
                {
                    tooltip.bonusesText[i].text = bonus;
                }
                else if (bonus != null) {
                    return;
                }
            }*/
            string b = "";
            foreach(Character character in sword.canUseCharacters)
            {
                b += character.ToString()+" ";
            }
            Debug.Log(b);
            tooltip.wearAbleText.text = b;
        }
        
    }
    private void Hide()
    {
        tooltip.GameObject().SetActive(false);
    }

    
}
