using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class AutoLayoutSwitcher
{
    static AutoLayoutSwitcher()
    {
        // Play mode'a geçildiğinde çalışacak bir callback ekliyoruz
        EditorApplication.playModeStateChanged += SwitchLayoutOnPlayMode;
    }

    static void SwitchLayoutOnPlayMode(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            // Play Mode'a geçildiğinde kullanılacak Layout'u burada seçiyoruz
            EditorApplication.delayCall += () => {
                EditorApplication.ExecuteMenuItem("Window/Layouts/GameMode");
            };
        }
        else if (state == PlayModeStateChange.ExitingPlayMode)
        {
            EditorApplication.delayCall += () => {
                EditorApplication.ExecuteMenuItem("Window/Layouts/Layout");
            };
            // Play Mode'dan çıkıldığında, orijinal Layout'u tekrar seçebilirsiniz
            
        }
    }
}