using Script.ObjectInstances;
using Script.ScriptableObject.UpObject;
using Script.UI.Tooltip;
using Script.UI.UpgradePanel;
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
        private void Awake()
        {
            UIEvent.OnUpgradePanel += OpenUpgradePanel;
            UIEvent.CloseUpgradePanel += Hide;
            okeyButton.onClick.AddListener(()=>UIEvent.OnOpenConfirm(_upInstance.GetPlusDescription(), PlusHandler, null));
            cancelButton.onClick.AddListener(Hide);
            Debug.Log("Awake called, subscribing to event");
            //UIManager.OnUpgradePanelNeed += UIManager_OnUpgradePanelNeed;
            itemImage.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
        
        private void OpenUpgradePanel(ItemInstance obj,UpItemInstance upgradeItem)
        {
            this._upInstance=upgradeItem;
            _upgradeItemInstance=obj;
            tooltip.Screen(_upgradeItemInstance);
            itemImage.Open(_upgradeItemInstance.objectAbstract);
            
            this.gameObject.SetActive(true);
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
