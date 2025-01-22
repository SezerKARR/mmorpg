using System;
using Script.ObjectInstances;
using Script.ScriptableObject;
using Script.ScriptableObject.Objects.Equipment;
using Script.ScriptableObject.UpObject;
using Script.UI.Tooltip;
using Script.UI.UpgradePanel;
using Script.UpgradePanel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class UpgradePanelManager : MonoBehaviour
    {
        [SerializeField]private ItemImage itemImage;
        public ItemToolTip tooltip;
        public Button okeyButton;
        public Button cancelButton;
        private UpItemInstance _upInstance;
        private ItemInstance _upgradeItemInstance;
        public RequireIcon[] requireIcons;
        private void Awake()
        {
            UIEvent.OnUpgradePanel += OpenUpgradePanel;
            UIEvent.CloseUpgradePanel += Hide;
            okeyButton.onClick.AddListener(() => 
            {
                if (UIEvent.OnOpenConfirm != null)
                {
                    UIEvent.OnOpenConfirm(_upInstance.GetPlusDescription(), PlusHandler, null);
                }
                else
                {
                    Debug.LogError("OnOpenConfirm metodu null.");
                }
            });
            cancelButton.onClick.AddListener(Hide);
            Debug.Log("Awake called, subscribing to event");
            //UIManager.OnUpgradePanelNeed += UIManager_OnUpgradePanelNeed;
            itemImage.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
        
        private void OpenUpgradePanel(ItemInstance obj,UpItemInstance upItem)
        {
            if(obj.currentPlus==obj.maxPlus+1)return;
            this._upInstance=upItem;
            _upgradeItemInstance=obj;
            tooltip.gameObject.SetActive(true);
            ItemInstance upItemInstance = _upgradeItemInstance.Clone();
            upItemInstance.currentPlus=upItemInstance.currentPlus+1;
            tooltip.Screen(upItemInstance);
            itemImage.Open(_upgradeItemInstance.objectAbstract);
            
            HandleIcons(_upgradeItemInstance.scriptableItemsAbstract.requirements[_upgradeItemInstance.currentPlus].upgradeItems);
            this.gameObject.SetActive(true);
        }

        private void HandleIcons(Require[] requires)
        {
            int i=0;
            foreach (var require in requireIcons)
            {
               
               try
               {
                   requireIcons[i].HandleIcons(requires[i]);
               }
               catch (Exception e)
               {
                   requireIcons[i].HandleIcons(null);
               }

               i++;
            }
        }
        private void PlusHandler()
        {
            //todo: şuanda direkt 100 şansla geçiyor ayarlanacak /önemsiz-önemli 
            _upgradeItemInstance.currentPlus++;
            
            Debug.Log("artı basıldı "+$"şuanki level: {_upgradeItemInstance.currentPlus}");
            _upInstance.DecreaseHowMany();
            this.gameObject.SetActive(false);
        }        
        
        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void Confirm()
        {
            throw new System.NotImplementedException();
        }
    }
}
