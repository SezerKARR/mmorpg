using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;
using System.Linq;
using System.Xml.Serialization;
public class CsvToSo
{
    private static string UpgradeItemsCSVPath = "/CSVS/UpgradeItems.csv";
    private static string MonstersCSVPath = "/CSVS/Monsters.csv";
    private static string ExpCsvPath = "/CSVS/Exp.csv";
    private static string ExpPerLevelCsvPath = "/CSVS/ExpPerLevel.csv";
    private static string BonusesCsvPath = "/CSVS/Bonuses.csv";
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
    [MenuItem("Utilities/ExpPerLevelSO")]
    private static void ExpPerLevelSO()
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

    [MenuItem("Utilities/UpdateMonsterCanDropForUPItems")]
    public static void UpdateMonsterCanDropForUPItems()
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
    [MenuItem("Utilities/DeleteMonsterCanDrop")]
    public static void DeleteMonsterCanDrop()
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
    [MenuItem("Utilities/Generate Bonuses")]
    public static void CsvToBonuses()
    {
        string bonusesPath = "Assets/ScriptableObjects/Bonuses";
        BonusForAttackSO bonusForAttackSO = ScriptableObject.CreateInstance<BonusForAttackSO>();
        BonusForDefenceSO bonusForDefenceSO = ScriptableObject.CreateInstance<BonusForDefenceSO>();
        BonusOtherSO bonusOtherSO = ScriptableObject.CreateInstance<BonusOtherSO>();
        string[] allLines=File.ReadAllLines(Application.dataPath + BonusesCsvPath);
        //AssetDatabase.CreateAsset(bonusForAttackSO, $"{bonusesPath}/BonusForAttackSO.asset");
        foreach (string line in allLines)
        {
            string[] splitData=line.Split(";");
            if (splitData[0].Length>0)
            {
                GiveBonuses(bonusForAttackSO, splitData,0);

            }
            if (splitData[4].Length > 0)
            {
                GiveBonuses(bonusForDefenceSO, splitData, 4);

            }
            if (splitData[8].Length > 0)
            {
                GiveBonuses(bonusOtherSO, splitData, 8);

            }

        }
        AssetDatabase.CreateAsset(bonusForAttackSO, $"{bonusesPath}/BonusForAttackSO.asset");
        AssetDatabase.CreateAsset(bonusForDefenceSO, $"{bonusesPath}/BonusForDefenceSO.asset");
        AssetDatabase.CreateAsset(bonusOtherSO, $"{bonusesPath}/BonusOtherSO.asset");
        AssetDatabase.SaveAssets();
    }
    public static BonusSO GiveBonuses( BonusSO bonusSO, string[] splitData,int i)
    {
        Bonus bonus = new Bonus();
        bonus.bonusName = splitData[i+2];
        Debug.Log(splitData[i + 3]+ splitData[i]);
        Debug.Log(splitData[i].Length);
        bonus.maxBonusRate = float.Parse(splitData[i+3]);
        bonus.bonusRates = BonusRatesCalculate(float.Parse(splitData[i+3]));
        bonusSO.AddObject(bonus);
        return null; 
    }

    public static List<float> BonusRatesCalculate(float maxBonusRates)
    {
        if (maxBonusRates == 12) return new List<float> { 2, 4, 6, 8, 10, 12 };
        else if (maxBonusRates == 15) return new List<float> { 5, 8, 10, 12, 15 };
        else if (maxBonusRates == 10) return new List<float> { 2, 5, 8, 10 };
        else if (maxBonusRates == 2000) return new List<float> { 500, 1000, 1500, 2000 };
        else if (maxBonusRates == 8) return new List<float> { 2, 3, 5, 8 };
        else if (maxBonusRates == 20) return new List<float> { 5, 10, 15, 20 };
        else if (maxBonusRates == 50) return new List<float> { 15, 35, 50 };
        else if (maxBonusRates == 5) return new List<float> { 1, 3, 5 };
        else if (maxBonusRates == 1) return new List<float> { 1 };
        else if (maxBonusRates == 30) return new List<float> { 8, 16, 30 };
        else if (maxBonusRates == 80) return new List<float> { 25, 50, 80 };
        else return new List<float> { maxBonusRates/5,maxBonusRates/2,maxBonusRates};

    }
    
   

}
