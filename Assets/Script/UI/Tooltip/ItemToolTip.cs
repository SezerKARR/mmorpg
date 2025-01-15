using System.Collections.Generic;
using Script.ObjectInstances;
using TMPro;
using UnityEngine;

namespace Script.UI.Tooltip
{
    enum ToolTipEnum
    {
        None,
        Name,
        Info,
        Stats,
        Bonus,
        Wearable
    }
    public class ItemToolTip : MonoBehaviour
    {
        public TextMeshProUGUI itemName;
        public TextMeshProUGUI levelText;
        public TextMeshProUGUI[] itemStats;
        public TextMeshProUGUI[] bonusesText;
        public TextMeshProUGUI wearableLayer;
        public TextMeshProUGUI wearAbleText;
        public void Screen(ItemInstance itemInstance)
        {
            SetText(itemName,itemInstance.ItemName());
            SetText(levelText,itemInstance.level.ToString());
            for (int i = 0; i < itemInstance.itemStats.Count; i++)
            {
                SetText(this.itemStats[i], itemInstance.itemStats[i]);
            }
            
            List<string> bonuses = itemInstance.ItemBonuses();
            for (int i = 0; i < bonuses.Count; i++)
            {
                SetText(this.bonusesText[i], bonuses[i]);
            }
            wearableLayer.gameObject.SetActive(true);
            string wearableText="" ;
            foreach (var canuse in itemInstance.canUseCharacters )
            {
                wearableText += canuse+" ";
            }
            SetText(this.wearAbleText, wearableText);
            //todooooo
            // if (inventorObjectable is SwordSo sword)
            // {
            //
            //     SetText(ItemName, sword.name);
            //     SetText(attackValueText, ("Attack Value " + sword.minAndMaxAttackValue[sword.currentPlus].ToString())) ;
            //     if (sword.minAndMaxMagicalAttackValue.Count>0){
            //         SetText(magicalValueText, ("Magic Attack Value " + sword.minAndMaxMagicalAttackValue[sword.currentPlus].ToString()));
            //     }
            //     
            //     SetText(attackSpeedText, ("Attack Speed " + sword.attackSpeed[sword.currentPlus].ToString())) ;
            //     SetText(levelText, ("From level" + sword.level.ToString())) ;
            //     
            //     foreach (var bonus in sword.bonuses)
            //     {
            //         int i = 0;
            //         if (bonus.bonusName != null)
            //         {
            //             SetText(bonusesText[i], bonus.bonusValue.ToString()) ;
            //         }
            //         
            //     }
            //     string b = "";
            //     foreach (CharacterType character in sword.canUseCharacters)
            //     {
            //         b += character.ToString() + " ";
            //     }
            //     
            //     SetText(wearAbleText, b);
            //     wearableLayer.gameObject.SetActive(wearAbleText.gameObject.activeSelf);
            // }

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
}
