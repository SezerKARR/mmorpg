using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollOfWar : ObjectAbstract, IUpgradeItem
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

    public override void MakeJob(InventorButton inventorButton)
    {
        throw new System.NotImplementedException();
    }
}
