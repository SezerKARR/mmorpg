using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour,IScreenableUI
{
    public IInventorObjectable inventorObjectable;

    public Button okeyButton;
    public Button cancelButton;
    public void Screen(IInventorObjectable inventorObjectable)
    {
        this.inventorObjectable = inventorObjectable;
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        throw new System.NotImplementedException();
    }

    
}
