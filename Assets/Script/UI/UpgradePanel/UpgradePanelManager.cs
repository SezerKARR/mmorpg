using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelManager : MonoBehaviour, IConfirmable
{
    public static UpgradePanelManager instance;
    private void Awake()
    {
        instance = this;
    }
    public IInventorObjectable inventorObjectable;
    public ToolTip tooltip;
    public UpgradeItemImage UpgradeItemImage;
    public Button okeyButton;
    public Button cancelButton;
    public void Screen(IInventorObjectable inventorObjectable)
    {
        tooltip.gameObject.SetActive(true);
        tooltip.Screen(inventorObjectable);
        UpgradeItemImage.gameObject.SetActive(true);
        UpgradeItemImage.Screen(inventorObjectable);
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
