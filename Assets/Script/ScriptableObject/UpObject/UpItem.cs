

using System;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/UpItem")]
public class UpItem : ObjectAbstract,IUpgradeItem 
{
    public int upResultTrue;
    public int upResultFalse;
    public float changeForUp;
    public float GetChangeUp()
    {
        
        return changeForUp;
    }

    

    public int GetPlus(bool upResult)=>upResult ? upResultTrue : upResultFalse;

    
}
