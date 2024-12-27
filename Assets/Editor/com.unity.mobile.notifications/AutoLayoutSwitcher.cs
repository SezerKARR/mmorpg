using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class AutoLayoutSwitcher
{
    [Obsolete("Obsolete")]
    static AutoLayoutSwitcher()
    {
        // Play mode'a ge�ildi�inde �al��acak bir callback ekliyoruz
        EditorApplication.playmodeStateChanged += () =>
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
            {
                Debug.Log("Auto-saving all open scenes...");
                EditorSceneManager.SaveOpenScenes();
                AssetDatabase.SaveAssets();
            }
        };
    }

    static void SaveScene(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
        }
    }
    // 
    // static void SwitchLayoutOnPlayMode(PlayModeStateChange state)
    // {
    //     if (state == PlayModeStateChange.EnteredPlayMode)
    //     {
    //         // Play Mode'a ge�ildi�inde kullan�lacak Layout'u burada se�iyoruz
    //         EditorApplication.delayCall += () => {
    //             EditorApplication.ExecuteMenuItem("Window/Layouts/GameMode");
    //         };
    //     }
    //     else if (state == PlayModeStateChange.ExitingPlayMode)
    //     {
    //         EditorApplication.delayCall += () => {
    //             EditorApplication.ExecuteMenuItem("Window/Layouts/Layout");
    //         };
    //         // Play Mode'dan ��k�ld���nda, orijinal Layout'u tekrar se�ebilirsiniz
    //         
    //     }
    // }
}