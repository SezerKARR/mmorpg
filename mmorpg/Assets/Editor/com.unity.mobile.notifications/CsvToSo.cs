using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;
using System.Linq;
public class CsvToSo
{
    private static string UpgradeItemsCSVPath = "/CSVS/UpgradeItems.csv";
    private static string MonstersCSVPath = "/CSVS/Monsters.csv";
    private static string ExpCsvPath = "/CSVS/Exp.csv";
    private static string ExpPerLevelCsvPath = "/CSVS/ExpPerLevel.csv";
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
    [MenuItem("Utilities/Generate Exp")]
    private static void CsvToSoExp()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + ExpCsvPath);
        foreach (string line in allLines.Skip(100))
        {
            string[] splitData = line.Split(";");
            Debug.Log(line);
            ExpSO expSO = ScriptableObject.CreateInstance<ExpSO>();

            expSO.level=int.Parse( splitData[0]);
            expSO.exp=long.Parse( splitData[1].Replace(".",""));

            string filePath = $"Assets/ScriptableObjects/Exp";


            string name = expSO.level.ToString();

            AssetDatabase.CreateAsset(expSO, $"{filePath}/{name}.asset");

        }
        AssetDatabase.SaveAssets();

    }
    [MenuItem("Utilities/Generate ExpPerLevel")]
    private static void CsvFromSoExpPerLevel()
    {
        int i=0;
        string[] allLines = File.ReadAllLines(Application.dataPath + ExpPerLevelCsvPath);
        foreach (string line in allLines.Skip(1))
        {
            string[] splitData = line.Split(";");
            Debug.Log(line);
            ExpPerLevelSO ExpPerLevelSO = ScriptableObject.CreateInstance<ExpPerLevelSO>();

            ExpPerLevelSO.levelDiff = splitData[0].Replace("<","").Replace(">","").Replace("=","");
            ExpPerLevelSO.expRate = splitData[1].Replace("%", "");

            string filePath = $"Assets/ScriptableObjects/ExpPerLevel";


            string name =i.ToString();

            AssetDatabase.CreateAsset(ExpPerLevelSO, $"{filePath}/{name}.asset");
            i++;
        }
        AssetDatabase.SaveAssets();
    }
}
