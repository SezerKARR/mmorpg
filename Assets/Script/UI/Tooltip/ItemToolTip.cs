using System;
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
    public class ItemToolTip : ToolTip
    {
        public TextMeshProUGUI levelText;
        public TextMeshProUGUI[] itemStats;
        public TextMeshProUGUI[] bonusesText;
        public TextMeshProUGUI wearableLayer;
        public TextMeshProUGUI wearAbleText;
        public static Action<ItemInstance> OnScreen;
        protected override void Awake()
        { 
            OnScreen += Screen;
            base.Awake();
        }


        public  void Screen(ItemInstance itemInstance)
        {
            SetText(itemName,itemInstance.ObjectName());
            SetText(levelText,"From Level: "+itemInstance.level.ToString());
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
           

        }

    }
}
