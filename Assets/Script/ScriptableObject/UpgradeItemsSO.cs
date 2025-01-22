using System.Collections;
using System.Collections.Generic;
using Script.Inventory;
using Script.ScriptableObject;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/Require")]
public class UpgradeItemsSO : ObjectAbstract
{
    public override ObjectType Type => ObjectType.Stack; 
    /*public override ObjectType GetTypeController()
    {
        return ObjectType.Up;
    }*/
}
