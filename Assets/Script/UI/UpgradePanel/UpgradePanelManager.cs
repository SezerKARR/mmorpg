using System.Collections;
using System.Collections.Generic;
using Script.ScriptableObject;
using Script.UI;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelManager : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake called, subscribing to event");
//UIManager.OnUpgradePanelNeed += UIManager_OnUpgradePanelNeed;
        UpgradeItemImage.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
    
    public ObjectAbstract inventorObjectable;
    public ToolTip tooltip;
    public UpgradeItemImage UpgradeItemImage;
    public Button okeyButton;
    public Button cancelButton;
    public void UIManager_OnUpgradePanelNeed(ObjectAbstract inventorObjectable)
    {
        this.gameObject.SetActive(true);
        tooltip.gameObject.SetActive(true);
        tooltip.Screen(inventorObjectable);
        
        this.inventorObjectable = inventorObjectable;
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
