using Script.ObjectInstances;
using Script.UI.Tooltip;
using Script.UI.UpgradePanel;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Script.UI
{
    public class UpgradePanelManager : MonoBehaviour
    {
        [SerializeField]private ItemImage itemImage;
        public ItemToolTip tooltip;
        public Button okeyButton;
        public Button cancelButton;

        private void Awake()
        {
            UIEvent.OnUpgradePanel += OpenUpgradePanel;
            UIEvent.CloseUpgradePanel += Hide;
            Debug.Log("Awake called, subscribing to event");
            //UIManager.OnUpgradePanelNeed += UIManager_OnUpgradePanelNeed;
            itemImage.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

        private void OpenUpgradePanel(ItemInstance obj)
        {
            tooltip.Screen(obj);
            tooltip.gameObject.SetActive(true);
            itemImage.Open(obj.scriptableItemsAbstract);
            this.gameObject.SetActive(true);
           
        
        }

        
        public void Hide()
        {
            throw new System.NotImplementedException();
        }

        public void confirm()
        {
            throw new System.NotImplementedException();
        }
    }
}
