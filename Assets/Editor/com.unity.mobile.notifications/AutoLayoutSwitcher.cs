using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class AutoLayoutSwitcher
{
    /*static AutoLayoutSwitcher()
    {
        // Play mode'a ge�ildi�inde �al��acak bir callback ekliyoruz
        EditorApplication.playModeStateChanged += SwitchLayoutOnPlayMode;
    }

    static void SwitchLayoutOnPlayMode(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            // Play Mode'a ge�ildi�inde kullan�lacak Layout'u burada se�iyoruz
            EditorApplication.delayCall += () => {
                EditorApplication.ExecuteMenuItem("Window/Layouts/GameMode");
            };
        }
        else if (state == PlayModeStateChange.ExitingPlayMode)
        {
            EditorApplication.delayCall += () => {
                EditorApplication.ExecuteMenuItem("Window/Layouts/Layout");
            };
            // Play Mode'dan ��k�ld���nda, orijinal Layout'u tekrar se�ebilirsiniz
            
        }
    }*/
}