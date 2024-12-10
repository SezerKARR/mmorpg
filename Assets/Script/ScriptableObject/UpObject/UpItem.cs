

using System;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/UpItem")]
public class UpItem : ObjectAbstract,IUpgradeItem ,IMakeJobable
{
    public int upResultTrue;
    public int upResultFalse;
    public float changeForUp;
    public float GetChangeUp()
    {
        
        return changeForUp;
    }

    

    public int GetPlus(bool upResult)=>upResult ? upResultTrue : upResultFalse;

    public void MakeJob(InventorButton inventorButton)
    {
        UIManager.Instance.OpenUpgrade(inventorButton.inventorObjectAble);
    }
}
