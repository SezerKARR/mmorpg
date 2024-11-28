using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class AutoLayoutSwitcher
{
    /*static AutoLayoutSwitcher()
    {
        // Play mode'a geçildiðinde çalýþacak bir callback ekliyoruz
        EditorApplication.playModeStateChanged += SwitchLayoutOnPlayMode;
    }

    static void SwitchLayoutOnPlayMode(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            // Play Mode'a geçildiðinde kullanýlacak Layout'u burada seçiyoruz
            EditorApplication.delayCall += () => {
                EditorApplication.ExecuteMenuItem("Window/Layouts/GameMode");
            };
        }
        else if (state == PlayModeStateChange.ExitingPlayMode)
        {
            EditorApplication.delayCall += () => {
                EditorApplication.ExecuteMenuItem("Window/Layouts/Layout");
            };
            // Play Mode'dan çýkýldýðýnda, orijinal Layout'u tekrar seçebilirsiniz
            
        }
    }*/
}