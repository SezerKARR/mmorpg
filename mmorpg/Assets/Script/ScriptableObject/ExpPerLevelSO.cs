using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(menuName = "ScriptableObject/ExpPerLevel")]
public class ExpPerLevelSO : ScriptableObject
{
    
    public int[] levelDiff=new int[30];
    public float[] expRate=new float[30];

}
