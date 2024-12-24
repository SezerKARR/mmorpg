using System;
using System.Collections.Generic;
using System.Linq;
using Script.Anim;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace Editor.com.unity.mobile.notifications
{
    public class AnimatorCreate
    {
            [MenuItem("Tools/Create Animator a")]
        public static void CreateAnimatorController()
        {
            List<MonsterSO> monsters = LoadMonster();
            foreach (var monster in monsters.Take(2))
            {
                string controllerName = $"{monster.name} AutoGeneratedAnimator";
                string savePath = $"Assets/AnimatorControllers/{controllerName}.controller";
            
                // Klasörün varlığını kontrol et, yoksa oluştur
                EnsureDirectoryExists(savePath);
            
                // Animator Controller oluştur
                AnimatorController animatorController = AnimatorController.CreateAnimatorControllerAtPath(savePath);
                //
                foreach (var anim in Enum.GetValues(typeof(AnimAndDirection.AnimEnum)).Cast<AnimAndDirection.AnimEnum>().Skip(1))
                {
                    foreach (var direction in AnimAndDirection.DirectionToStringMap)
                    {
                        String animName = anim.ToString()+direction.Value;
                        AnimationClip idleClip = CreateEmptyAnimationClip(animName,monster.name);
                        AnimatorState idleState = AddStateToAnimator(animatorController, animName, idleClip);
                    }
                
                }
            
                // Save işlemi
                animatorController.AddParameter("IsWalking", AnimatorControllerParameterType.Bool);
            }
            AssetDatabase.SaveAssets();
        }
        
            private static List<MonsterSO> LoadMonster()
            {
                string upgradeItemsPath = "Assets/ScriptableObjects/Monsters";
                string[] upgradeItemsGuids = AssetDatabase.FindAssets("t:MonsterSO", new[] { upgradeItemsPath });
                Debug.Log($"Found {upgradeItemsGuids.Length} upgrade item SOs");
                List<MonsterSO> upgradeItemSO = new List<MonsterSO>();
        
        
                foreach (string upgradeItemsguid in upgradeItemsGuids)
                {
                    string upgradePath = AssetDatabase.GUIDToAssetPath(upgradeItemsguid);
                    upgradeItemSO.Add(AssetDatabase.LoadAssetAtPath<MonsterSO>(upgradePath));
        
                }
        
                return upgradeItemSO;
            }
        
            private static void EnsureDirectoryExists(string savePath)
        {
            string directory = System.IO.Path.GetDirectoryName(savePath);
            if (!AssetDatabase.IsValidFolder(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
                AssetDatabase.Refresh();
            }
        }
        
        private static AnimatorState AddStateToAnimator(AnimatorController controller, string stateName, AnimationClip clip)
        {
            // İlk layerdaki state machine'i al
            var stateMachine = controller.layers[0].stateMachine;
        
            // Yeni state ekle
            AnimatorState newState = stateMachine.AddState(stateName);
        
            // AnimationClip'i state'e ata
            newState.motion = clip;
        
            return newState;
        }
        
        private static AnimationClip CreateEmptyAnimationClip(string clipName,string animPos)
        {
            // Animasyon klip için yol
            string clipPath = $"Assets/AnimationClips/{animPos}/{clipName}.anim";
        
            // Klasörün varlığını kontrol et, yoksa oluştur
            EnsureDirectoryExists(clipPath);
        
            // Yeni bir boş AnimationClip oluştur
            AnimationClip clip = new AnimationClip();
            clip.wrapMode = WrapMode.Loop;
            AnimationUtility.SetAnimationClipSettings(clip, new AnimationClipSettings {loopTime = true});
            AssetDatabase.CreateAsset(clip, clipPath);
            
            return clip;
        }
        }
    }
