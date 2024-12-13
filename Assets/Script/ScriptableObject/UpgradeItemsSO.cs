using System.Collections;
using System.Collections.Generic;
using Script.Inventory;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/UpgradeItem")]
public class UpgradeItemsSO : ObjectAbstract
{
    public override TypeController GetTypeController()
    {
        return TypeController.upgradeItem;
    }
}
