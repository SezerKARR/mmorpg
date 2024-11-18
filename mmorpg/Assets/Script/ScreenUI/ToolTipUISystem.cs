using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ToolTipUISystem : MonoBehaviour
{
    public static ToolTipUISystem Instance;
    public GameObject[] scriptableObjectScreeners;
    private void Awake()
    {
        Instance = this;
    }
    public static void Show(ScriptableObject scriptableObject)
    {
        Instance.scriptableObjectScreeners[0].GetComponent<IScreenAble>().Screen(scriptableObject);
    }
    public static void Show(ScriptableObject scriptableObject, int numberScreeners)
    {
        print(Instance.scriptableObjectScreeners.Length);
        Instance.scriptableObjectScreeners[numberScreeners].GetComponent<IScreenAble>().Screen(scriptableObject);
    }
    public static void Hide(int numberScreeners)
    {
        Instance.scriptableObjectScreeners[numberScreeners].GetComponent<IScreenAble>().Hide();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
