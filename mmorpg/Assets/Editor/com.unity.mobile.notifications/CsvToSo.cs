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
        foreach (string line in allLines.Skip(1))
        {
            string[] splitData = line.Split(";");

            MonsterSO monsterSO = ScriptableObject.CreateInstance<MonsterSO>();
            monsterSO.location = splitData[5].Replace("�", "");
            monsterSO.monsterLocations = monsterSO.location.Split(",");

            if (monsterSO.monsterLocations.Length >= 5)
            {
                monsterSO.Resistance = splitData[0].Split(",");
                monsterSO.race = splitData[1];
                monsterSO.level = splitData[2];
                monsterSO.stage = splitData[3];
                monsterSO.monsterName = splitData[4];

                monsterSO.exp = splitData[6].Replace(".", "");

                string filePath = $"Assets/ScriptableObjects/Monsters/{monsterSO.monsterLocations[4]}";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string name = monsterSO.location + " " + monsterSO.monsterName;
                if (!File.Exists($"{filePath}/{name}.asset"))
                {
                    AssetDatabase.CreateAsset(monsterSO, $"{filePath}/{monsterSO.monsterName}.asset");
                }
            }





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

            expSO.level = int.Parse(splitData[0]);
            expSO.exp = long.Parse(splitData[1].Replace(".", ""));

            string filePath = $"Assets/ScriptableObjects/Exp";


            string name = expSO.level.ToString();

            AssetDatabase.CreateAsset(expSO, $"{filePath}/{name}.asset");

        }
        AssetDatabase.SaveAssets();

    }
    [MenuItem("Utilities/Generate ExpPerLevel")]
    private static void CsvFromSoExpPerLevel()
    {
        int i = 0;
        string[] allLines = File.ReadAllLines(Application.dataPath + ExpPerLevelCsvPath);
        foreach (string line in allLines.Skip(1))
        {
            string[] splitData = line.Split(";");
            Debug.Log(line);
            ExpPerLevelSO ExpPerLevelSO = ScriptableObject.CreateInstance<ExpPerLevelSO>();

            ExpPerLevelSO.levelDiff = splitData[0].Replace("<", "").Replace(">", "").Replace("=", "");
            ExpPerLevelSO.expRate = splitData[1].Replace("%", "");

            string filePath = $"Assets/ScriptableObjects/ExpPerLevel";


            string name = i.ToString();

            AssetDatabase.CreateAsset(ExpPerLevelSO, $"{filePath}/{name}.asset");
            i++;
        }
        AssetDatabase.SaveAssets();
    }
    [MenuItem("Utilities/UpdateMonster")]
    private static void UpdateMonster()
    {
        int i = 0;
        string[] allLines = File.ReadAllLines(Application.dataPath + ExpPerLevelCsvPath);
        foreach (string line in allLines.Skip(1))
        {
            string[] splitData = line.Split(";");
            Debug.Log(line);
            ExpPerLevelSO ExpPerLevelSO = ScriptableObject.CreateInstance<ExpPerLevelSO>();

            ExpPerLevelSO.levelDiff = splitData[0].Replace("<", "").Replace(">", "").Replace("=", "");
            ExpPerLevelSO.expRate = splitData[1].Replace("%", "");

            string filePath = $"Assets/ScriptableObjects/ExpPerLevel";


            string name = i.ToString();

            AssetDatabase.CreateAsset(ExpPerLevelSO, $"{filePath}/{name}.asset");
            i++;
        }
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Utilities/Load All Scriptable Objects")]
    public static void LoadAllScriptableObjects()
    {
        string monsterpath = "Assets/ScriptableObjects/Monsters";
        string[] monsterGuids = AssetDatabase.FindAssets("t:MonsterSO", new[] { monsterpath });
        Debug.Log($"Found {monsterGuids.Length} monster SOs");
        string upgradeItemsPath = "Assets/ScriptableObjects/UpgradeItem";
        string[] upgradeItemsGuids = AssetDatabase.FindAssets("t:UpgradeItemsSO", new[] { upgradeItemsPath });
        Debug.Log($"Found {upgradeItemsGuids.Length} upgrade item SOs");
        List<UpgradeItemsSO> upgradeİtemSO = new List<UpgradeItemsSO>();
        List<MonsterSO> monsterSO = new List<MonsterSO>();
        foreach (string upgradeItemsguid in upgradeItemsGuids)
        {
            string upgradePath = AssetDatabase.GUIDToAssetPath(upgradeItemsguid);
            upgradeİtemSO.Add(AssetDatabase.LoadAssetAtPath<UpgradeItemsSO>(upgradePath));

        }
        foreach (string monsterGuid in monsterGuids)
        {
            string monsterpaths = AssetDatabase.GUIDToAssetPath(monsterGuid);
            MonsterSO addedablemonsterso = AssetDatabase.LoadAssetAtPath<MonsterSO>(monsterpaths);
            monsterSO.Add(addedablemonsterso);
            

        }
        foreach (UpgradeItemsSO upgradeItem in upgradeİtemSO)
        {
            string[] dropfroms = upgradeItem.dropsFrom.Replace(", ", ",").Split(',');

            foreach (string dropfrom in dropfroms)
            {
                foreach (MonsterSO monsterSO1 in monsterSO)
                {
                    if (dropfrom == monsterSO1.monsterName)
                    {

                        // canDrop null ise başlat
                        if (monsterSO1.canDrop == null)
                        {
                            monsterSO1.canDrop = new List<ScriptableObject>();
                        }

                        monsterSO1.canDrop.Add(upgradeItem);
                    }
                    else if (SimilarityAlgorthm(dropfrom, monsterSO1.monsterName))
                    {
                        if (monsterSO1.canDrop == null)
                        {
                            monsterSO1.canDrop = new List<ScriptableObject>();
                        }
                        monsterSO1.canDrop.Add(upgradeItem);
                        Debug.Log(upgradeItem.name + dropfrom + monsterSO1.monsterName);
                    }
                }
            }
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

    }
    [MenuItem("Utilities/b")]
    public static void b()
    {
        string monsterpath = "Assets/ScriptableObjects/Monsters";
        string[] monsterGuids = AssetDatabase.FindAssets("t:MonsterSO", new[] { monsterpath });
        List<MonsterSO> monsterSO = new List<MonsterSO>();
        foreach (string monsterGuid in monsterGuids)
        {
            string monsterpaths = AssetDatabase.GUIDToAssetPath(monsterGuid);
            MonsterSO addedablemonsterso = AssetDatabase.LoadAssetAtPath<MonsterSO>(monsterpaths);
            addedablemonsterso.canDrop = new List<ScriptableObject>();
            monsterSO.Add(addedablemonsterso);


        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

    }
    [MenuItem("Utilities/a")]
    public static void a()
    {
        AssetDatabase.Refresh();

    }
    
    public static int LevenshteinsDistance(string s1, string s2)
    {
        int len1 = s1.Length;
        int len2 = s2.Length;
        int[,] dp = new int[len1 + 1, len2 + 1];

        for (int i = 0; i <= len1; i++)
            dp[i, 0] = i;
        for (int j = 0; j <= len2; j++)
            dp[0, j] = j;

        for (int i = 1; i <= len1; i++)
        {
            for (int j = 1; j <= len2; j++)
            {
                int cost = s1[i - 1] == s2[j - 1] ? 0 : 1;
                dp[i, j] = Math.Min(
                    Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                    dp[i - 1, j - 1] + cost
                );
            }
        }

        return dp[len1, len2];
    }
    public static bool SimilarityAlgorthm(string sentence1,string sentence2)
    {
        sentence1=sentence1.ToLower();
        sentence2=sentence2.ToLower();
        sentence1 = sentence1.ToLower();
        int similar=0;
        int i = 0;
        string[] s1 = sentence1.Split(" ");
        string[] s2 = sentence2.Split(" ");
        bool similara = false;
        if(s1.Length == s2.Length)
        {
            foreach(string s in s1) {
                if (sentence2.Contains(s))
                {
                    similar++;
                }
                i++;
            }
            if (similar == s2.Length)
            {
                similara=true;
            }
        }
        return similara;
        
    }
    private static string NormalizeString(string sentence)
    {
        sentence = sentence.ToLower();
        sentence=sentence.Trim().Replace(".", "").Replace(",", "");
        // Noktalama işaretlerini temizle, sadece kelimelerle çalış
        return sentence;
    }
    public static bool AreSentencesSimilar(string sentence1, string sentence2, double threshold = 0.6)
    {
        
        
        int maxLen = Math.Max(sentence1.Length, sentence2.Length);
        int distance = LevenshteinsDistance(sentence1, sentence2);
        double similarity = 1.0 - (double)distance / maxLen;
        
        

        return similarity >= threshold;
    }

}
