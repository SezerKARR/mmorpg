using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class SwordScreener : MonoBehaviour, IScreenAble
{
    public TextMeshProUGUI swordNameText;
    public TextMeshProUGUI attackValueText;
    public TextMeshProUGUI magicalValueText;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI[] bonusesText;
    public TextMeshProUGUI wearAbleText;
    public ScriptableObject sword;
    private void Start()
    {
        Screen(sword);   
    }
    public void Screen(ScriptableObject scriptableObject)
    {
        if(scriptableObject is SwordSO sword)
        {
            swordNameText.text = sword.name;
            attackValueText.text = ("Attack Value " + sword.minAndMaxAttackValue.ToString());
            magicalValueText.text = ("Magic Attack Value " + sword.minAndMaxMagicalAttackValue.ToString());
            attackSpeedText.text = ("Attack Speed " + sword.attackSpeed.ToString());
            levelText.text=("From level"+ sword.level.ToString());
            foreach (var bonus in sword.bonuses)
            {
                int i = 0;
                if (bonus != null)
                {
                    bonusesText[i].text = bonus;
                }
                else if (bonus != null) {
                    return;
                }
            }
            wearAbleText.text = sword.canUseCharacters[0].ToString();

        }
        
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    
}
