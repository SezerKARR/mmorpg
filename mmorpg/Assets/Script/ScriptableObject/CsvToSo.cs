using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;
using static UnityEditor.FilePathAttribute;
public class CsvToSo
{
    private static string UpgradeItemsCSVPath = "/CSVS/UpgradeItems.csv";
    private static string MonstersCSVPath = "/CSVS/Monsters.csv";

    
    [MenuItem("Utilities/Generate Upgrade Items")]
    private static void CsvToSoUpgradeItems()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + UpgradeItemsCSVPath);
        foreach (string line in allLines)
        {
            string[] splitData = line.Split(";");

            UpgradeItemsSO upgradeItemsSO = ScriptableObject.CreateInstance<UpgradeItemsSO>();

            upgradeItemsSO.upgradeName = splitData[0];
            upgradeItemsSO.dropsFrom = splitData[1];
            upgradeItemsSO.info = splitData[2];

            AssetDatabase.CreateAsset(upgradeItemsSO, $"Assets/ScriptableObjects/UpgradeItem/{upgradeItemsSO.upgradeName}.asset");
        }
        AssetDatabase.SaveAssets();
    }
    [MenuItem("Utilities/Generate Monsters")]
    private static void CsvToSoMonsters()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + MonstersCSVPath);
        foreach (string line in allLines)
        {
            string[] splitData = line.Split(";");

            MonsterSO monsterSO = ScriptableObject.CreateInstance<MonsterSO>();

            monsterSO.Resistance = splitData[0].Split(",");
            monsterSO.race = splitData[1];
            monsterSO.level = splitData[2];
            monsterSO.stage = splitData[3];
            monsterSO.monsterName = splitData[4];
            monsterSO.location = splitData[5].Replace("�", "");
            monsterSO.exp = splitData[6];

            string filePath = $"Assets/ScriptableObjects/Monsters";
            

            string name = monsterSO.location + " " + monsterSO.monsterName;
            
            AssetDatabase.CreateAsset(monsterSO, $"{filePath}/{name}.asset");
        
        /*foreach (string line in allLines)
        {
            string[] splitData = line.Split(";");

            MonsterSO monsterSO = ScriptableObject.CreateInstance<MonsterSO>();

            monsterSO.Resistance = splitData[0].Split(",");
            monsterSO.race=splitData[1];
            monsterSO.level = splitData[2];
            monsterSO.stage = splitData[3];
            monsterSO.monsterName = splitData[4];
            monsterSO.location = splitData[5].Split(",");
            monsterSO.exp=splitData[6];
            
            foreach (string location in monsterSO.location)
            {
                i
                string locationx = location.Replace(" ", "");
                locationx = locationx.Replace("�", "");
                string filePath = $"Assets/ScriptableObjects/Monsters";
                Debug.Log(locationx);
                string name = locationx + " " + monsterSO.monsterName;
                Debug.Log(name);
                AssetDatabase.CreateAsset(monsterSO, $"{filePath}/{locationx + " " + monsterSO.monsterName}.asset");
                

            }
            AssetDatabase.CreateAsset(monsterSO, $"Assets/ScriptableObjects/Monsters/{monsterSO.monsterName}.asset");*/
        }
        AssetDatabase.SaveAssets();

    }
}
