using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollOfWar : ObjectAbstract, IUpgradeItem, IMakeJobable
{

    public int upResultTrue;
    public int upResultFalse;
    public float changeForUp;
    public int currentPlus;
    public float GetChangeUp()
    {
        if (currentPlus <= 3) return 100f;
        return changeForUp;
    }



    public int GetPlus(bool upResult) => upResult ? upResultTrue : upResultFalse;

    public  void MakeJob(InventorButton inventorButton)
    {
        UIManager.OnUpgradePanelNeed?.Invoke(inventorButton.inventorObjectAble);
    }
}
