﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;
using System.Linq;
using System.Xml.Serialization;
using Unity.Collections.LowLevel.Unsafe;
public class CsvToSo
{
    private static string UpgradeItemsCSVPath = "/CSVS/UpgradeItems.csv";
    private static string MonstersCSVPath = "/CSVS/Monsters.csv";
    private static string ExpCsvPath = "/CSVS/Exp.csv";
    private static string ExpPerLevelCsvPath = "/CSVS/ExpPerLevel.csv";
    private static string BonusesCsvPath = "/CSVS/Bonuses.csv";
    private static string SwordCsvPath = "/CSVS/Swords.csv";
    private static string TwoHanded = "/CSVS/Two Handed.csv";
    /*//[MenuItem("Utilities/Generate Upgrade Items")]
    //private static void CsvToSoUpgradeItems()
    //{
    //    string[] allLines = File.ReadAllLines(Application.dataPath + UpgradeItemsCSVPath);
    //    foreach (string line in allLines)
    //    {
    //        string[] splitData = line.Split(";");

    //        UpgradeItemsSO upgradeItemsSO = ScriptableObject.CreateInstance<UpgradeItemsSO>();

    //        upgradeItemsSO.upgradeName = splitData[0];
    //        upgradeItemsSO.dropsFrom = splitData[1];
    //        upgradeItemsSO.info = splitData[2];

    //        AssetDatabase.CreateAsset(upgradeItemsSO, $"Assets/ScriptableObjects/UpgradeItem/{upgradeItemsSO.upgradeName}.asset");
    //    }
    //    AssetDatabase.SaveAssets();
    }*/
    /*//[MenuItem("Utilities/Generate Monsters")]
    //private static void CsvToSoMonsters()
    //{
    //    string[] allLines = File.ReadAllLines(Application.dataPath + MonstersCSVPath);
    //    foreach (string line in allLines.Skip(1))
    //    {
    //        string[] splitData = line.Split(";");

    //        MonsterSO monsterSO = ScriptableObject.CreateInstance<MonsterSO>();
    //        monsterSO.location = splitData[5].Replace("�", "");
    //        monsterSO.monsterLocations = monsterSO.location.Split(",");

    //        if (monsterSO.monsterLocations.Length >= 5)
    //        {
    //            monsterSO.Resistance = splitData[0].Split(",");
    //            monsterSO.race = splitData[1];
    //            monsterSO.level = splitData[2];
    //            monsterSO.stage = splitData[3];
    //            monsterSO.monsterName = splitData[4];
    
    //            monsterSO.exp = splitData[6].Replace(".", "");

    //            string filePath = $"Assets/ScriptableObjects/Monsters/{monsterSO.monsterLocations[4]}";
    //            if (!Directory.Exists(filePath))
    //            {
    //                Directory.CreateDirectory(filePath);
    //            }

    //            string name = monsterSO.location + " " + monsterSO.monsterName;
    //            if (!File.Exists($"{filePath}/{name}.asset"))
    //            {
    //                AssetDatabase.CreateAsset(monsterSO, $"{filePath}/{monsterSO.monsterName}.asset");
    //            }
    //        }
    



    
    //        foreach (string line in allLines)
    //        {
    //            string[] splitData = line.Split(";");

    //            MonsterSO monsterSO = ScriptableObject.CreateInstance<MonsterSO>();

    //            monsterSO.Resistance = splitData[0].Split(",");
    //            monsterSO.race=splitData[1];
    //            monsterSO.level = splitData[2];
    //            monsterSO.stage = splitData[3];
    //            monsterSO.monsterName = splitData[4];
    //            monsterSO.location = splitData[5].Split(",");
    //            monsterSO.exp=splitData[6];

    //            foreach (string location in monsterSO.location)
    //            {
    //                i
    //                string locationx = location.Replace(" ", "");
    //                locationx = locationx.Replace("�", "");
    //                string filePath = $"Assets/ScriptableObjects/Monsters";
    //                Debug.Log(locationx);
    //                string name = locationx + " " + monsterSO.monsterName;
    //                Debug.Log(name);
    //                AssetDatabase.CreateAsset(monsterSO, $"{filePath}/{locationx + " " + monsterSO.monsterName}.asset");
    

    //            }
    //            AssetDatabase.CreateAsset(monsterSO, $"Assets/ScriptableObjects/Monsters/{monsterSO.monsterName}.asset");
    //    }
    //    AssetDatabase.SaveAssets();

    //}
    */
    //[MenuItem("Utilities/Generate Exp")]
    //private static void CsvToSoExp()
    //{
    //    string[] allLines = File.ReadAllLines(Application.dataPath + ExpCsvPath);
    //    foreach (string line in allLines.Skip(100))
    //    {
    //        string[] splitData = line.Split(";");
    //        Debug.Log(line);
    //        ExpSO expSO = ScriptableObject.CreateInstance<ExpSO>();

    //        expSO.level = int.Parse(splitData[0]);
    //        expSO.exp = long.Parse(splitData[1].Replace(".", ""));

    //        string filePath = $"Assets/ScriptableObjects/Exp";


    //        string name = expSO.level.ToString();

    //        AssetDatabase.CreateAsset(expSO, $"{filePath}/{name}.asset");

    //    }
    //    AssetDatabase.SaveAssets();

    //}
    //[MenuItem("Utilities/Generate ExpPerLevel")]
    //private static void CsvFromSoExpPerLevel()
    //{
    //    int i = 0;
    //    string[] allLines = File.ReadAllLines(Application.dataPath + ExpPerLevelCsvPath);
    //    foreach (string line in allLines.Skip(1))
    //    {
    //        string[] splitData = line.Split(";");
    //        Debug.Log(line);
    //        ExpPerLevelSO ExpPerLevelSO = ScriptableObject.CreateInstance<ExpPerLevelSO>();

    //        ExpPerLevelSO.levelDiff = splitData[0].Replace("<", "").Replace(">", "").Replace("=", "");
    //        ExpPerLevelSO.expRate = splitData[1].Replace("%", "");

    //        string filePath = $"Assets/ScriptableObjects/ExpPerLevel";


    //        string name = i.ToString();

    //        AssetDatabase.CreateAsset(ExpPerLevelSO, $"{filePath}/{name}.asset");
    //        i++;
    //    }
    //    AssetDatabase.SaveAssets();
    //}
    //[MenuItem("Utilities/ExpPerLevelSO")]
    //private static void ExpPerLevelSO()
    //{
    //    int i = 0;
    //    string[] allLines = File.ReadAllLines(Application.dataPath + ExpPerLevelCsvPath);
    //    foreach (string line in allLines.Skip(1))
    //    {
    //        string[] splitData = line.Split(";");
    //        Debug.Log(line);
    //        ExpPerLevelSO ExpPerLevelSO = ScriptableObject.CreateInstance<ExpPerLevelSO>();

    //        ExpPerLevelSO.levelDiff = splitData[0].Replace("<", "").Replace(">", "").Replace("=", "");
    //        ExpPerLevelSO.expRate = splitData[1].Replace("%", "");

    //        string filePath = $"Assets/ScriptableObjects/ExpPerLevel";


    //        string name = i.ToString();

    //        AssetDatabase.CreateAsset(ExpPerLevelSO, $"{filePath}/{name}.asset");
    //        i++;
    //    }
    //    AssetDatabase.SaveAssets();
    //}

    //[MenuItem("Utilities/UpdateMonsterCanDropForUPItems")]
    //public static void UpdateMonsterCanDropForUPItems()
    //{
    //    string monsterpath = "Assets/ScriptableObjects/Monsters";
    //    string[] monsterGuids = AssetDatabase.FindAssets("t:MonsterSO", new[] { monsterpath });
    //    Debug.Log($"Found {monsterGuids.Length} monster SOs");
    //    string upgradeItemsPath = "Assets/ScriptableObjects/UpgradeItem";
    //    string[] upgradeItemsGuids = AssetDatabase.FindAssets("t:UpgradeItemsSO", new[] { upgradeItemsPath });
    //    Debug.Log($"Found {upgradeItemsGuids.Length} upgrade item SOs");
    //    List<UpgradeItemsSO> upgradeItemSO = new List<UpgradeItemsSO>();
    //    List<MonsterSO> monsterSO = new List<MonsterSO>();

    //    foreach (string upgradeItemsguid in upgradeItemsGuids)
    //    {
    //        string upgradePath = AssetDatabase.GUIDToAssetPath(upgradeItemsguid);
    //        upgradeItemSO.Add(AssetDatabase.LoadAssetAtPath<UpgradeItemsSO>(upgradePath));

    //    }
    //    foreach (string monsterGuid in monsterGuids)
    //    {
    //        string monsterpaths = AssetDatabase.GUIDToAssetPath(monsterGuid);
    //        MonsterSO addedablemonsterso = AssetDatabase.LoadAssetAtPath<MonsterSO>(monsterpaths);
    //        monsterSO.Add(addedablemonsterso);


    //    }
    //    foreach (UpgradeItemsSO upgradeItem in upgradeItemSO)
    //    {
    //        string[] dropfroms = upgradeItem.dropsFrom.Replace(", ", ",").Split(',');

    //        foreach (string dropfrom in dropfroms)
    //        {
    //            foreach (MonsterSO monsterSO1 in monsterSO)
    //            {
    //                if (dropfrom == monsterSO1.monsterName)
    //                {

    //                    // canDrop null ise başlat
    //                    if (monsterSO1.canDrop == null)
    //                    {
    //                        monsterSO1.canDrop = new List<ScriptableObject>();
    //                    }

    //                    monsterSO1.canDrop.Add(upgradeItem);
    //                }
    //                else if (SimilarityAlgorthm(dropfrom, monsterSO1.monsterName))
    //                {
    //                    if (monsterSO1.canDrop == null)
    //                    {
    //                        monsterSO1.canDrop = new List<ScriptableObject>();
    //                    }
    //                    monsterSO1.canDrop.Add(upgradeItem);
    //                    Debug.Log(upgradeItem.name + dropfrom + monsterSO1.monsterName);
    //                }
    //            }
    //        }
    //    }
    //    AssetDatabase.SaveAssets();
    //    AssetDatabase.Refresh();

    //}
    //[MenuItem("Utilities/DeleteMonsterCanDrop")]
    //public static void DeleteMonsterCanDrop()
    //{
    //    string monsterpath = "Assets/ScriptableObjects/Monsters";
    //    string[] monsterGuids = AssetDatabase.FindAssets("t:MonsterSO", new[] { monsterpath });
    //    List<MonsterSO> monsterSO = new List<MonsterSO>();
    //    foreach (string monsterGuid in monsterGuids)
    //    {
    //        string monsterpaths = AssetDatabase.GUIDToAssetPath(monsterGuid);
    //        MonsterSO addedablemonsterso = AssetDatabase.LoadAssetAtPath<MonsterSO>(monsterpaths);
    //        addedablemonsterso.canDrop = new List<ScriptableObject>();
    //        monsterSO.Add(addedablemonsterso);


    //    }
    //    AssetDatabase.SaveAssets();
    //    AssetDatabase.Refresh();

    //}
    //public static bool SimilarityAlgorthm(string sentence1,string sentence2)
    //{
    //    sentence1=sentence1.ToLower();
    //    sentence2=sentence2.ToLower();
    //    sentence1 = sentence1.ToLower();
    //    int similar=0;
    //    int i = 0;
    //    string[] s1 = sentence1.Split(" ");
    //    string[] s2 = sentence2.Split(" ");
    //    bool similara = false;
    //    if(s1.Length == s2.Length)
    //    {
    //        foreach(string s in s1) {
    //            if (sentence2.Contains(s))
    //            {
    //                similar++;
    //            }
    //            i++;
    //        }
    //        if (similar == s2.Length)
    //        {
    //            similara=true;
    //        }
    //    }
    //    return similara;

    //}
    //private static string NormalizeString(string sentence)
    //{
    //    sentence = sentence.ToLower();
    //    sentence=sentence.Trim().Replace(".", "").Replace(",", "");
    //    // Noktalama işaretlerini temizle, sadece kelimelerle çalış
    //    return sentence;
    //}
    //[MenuItem("Utilities/Generate Bonuses")]
    //public static void CsvToBonuses()
    //{
    //    string bonusesPath = "Assets/ScriptableObjects/Bonuses";
    //    BonusForAttackSO bonusForAttackSO = ScriptableObject.CreateInstance<BonusForAttackSO>();
    //    BonusForDefenceSO bonusForDefenceSO = ScriptableObject.CreateInstance<BonusForDefenceSO>();
    //    BonusOtherSO bonusOtherSO = ScriptableObject.CreateInstance<BonusOtherSO>();
    //    string[] allLines=File.ReadAllLines(Application.dataPath + BonusesCsvPath);
    //    //AssetDatabase.CreateAsset(bonusForAttackSO, $"{bonusesPath}/BonusForAttackSO.asset");
    //    foreach (string line in allLines)
    //    {
    //        string[] splitData=line.Split(";");
    //        if (splitData[0].Length>0)
    //        {
    //            GiveBonuses(bonusForAttackSO, splitData,0);

    //        }
    //        if (splitData[4].Length > 0)
    //        {
    //            GiveBonuses(bonusForDefenceSO, splitData, 4);

    //        }
    //        if (splitData[8].Length > 0)
    //        {
    //            GiveBonuses(bonusOtherSO, splitData, 8);

    //        }

    //    }
    //    AssetDatabase.CreateAsset(bonusForAttackSO, $"{bonusesPath}/BonusForAttackSO.asset");
    //    AssetDatabase.CreateAsset(bonusForDefenceSO, $"{bonusesPath}/BonusForDefenceSO.asset");
    //    AssetDatabase.CreateAsset(bonusOtherSO, $"{bonusesPath}/BonusOtherSO.asset");
    //    AssetDatabase.SaveAssets();
    //}
    //public static BonusSO GiveBonuses( BonusSO bonusSO, string[] splitData,int i)
    //{
    //    Bonus bonus = new Bonus();
    //    bonus.bonusName = splitData[i+2];
    //    Debug.Log(splitData[i + 3]+ splitData[i]);
    //    Debug.Log(splitData[i].Length);
    //    bonus.maxBonusRate = float.Parse(splitData[i+3]);
    //    bonus.bonusRates = BonusRatesCalculate(float.Parse(splitData[i+3]));
    //    bonusSO.AddObject(bonus);
    //    return null; 
    //}

    //public static List<float> BonusRatesCalculate(float maxBonusRates)
    //{
    //    if (maxBonusRates == 12) return new List<float> { 2, 4, 6, 8, 10, 12 };
    //    else if (maxBonusRates == 15) return new List<float> { 5, 8, 10, 12, 15 };
    //    else if (maxBonusRates == 10) return new List<float> { 2, 5, 8, 10 };
    //    else if (maxBonusRates == 2000) return new List<float> { 500, 1000, 1500, 2000 };
    //    else if (maxBonusRates == 8) return new List<float> { 2, 3, 5, 8 };
    //    else if (maxBonusRates == 20) return new List<float> { 5, 10, 15, 20 };
    //    else if (maxBonusRates == 50) return new List<float> { 15, 35, 50 };
    //    else if (maxBonusRates == 5) return new List<float> { 1, 3, 5 };
    //    else if (maxBonusRates == 1) return new List<float> { 1 };
    //    else if (maxBonusRates == 30) return new List<float> { 8, 16, 30 };
    //    else if (maxBonusRates == 80) return new List<float> { 25, 50, 80 };
    //    else return new List<float> { maxBonusRates/5,maxBonusRates/2,maxBonusRates};

    //}
    /*[MenuItem("a/deneme")]
    public static void deneme()
    {
        int i = 0;
        string[] allLines = File.ReadAllLines(Application.dataPath + SwordCsvPath);
        SwordSO swordSO = null;
        List<float> upgradeMoney = new List<float>();
        List<int> upgradeItemRequire = new List<int>();
        foreach (string line in allLines)
        {
            Debug.Log(line.Length);
        } }*/
    [MenuItem("tools/createSword")]
    public static void CsvToSword()
    {
        CreateSword("sword", SwordCsvPath);
    }
    [MenuItem("tools/createTwoHanded")]
    public static void CsvToTwoHanded()
    {
        CreateSword("Two Handed", TwoHanded);
    }
    public static void CreateSword(string swordType,string swordPath)
    {
        bool upgradeUPItem = false;
        string[] allLines = File.ReadAllLines(Application.dataPath + swordPath);
        SwordSO swordSO = null;
        List<float> upgradeMoney = new List<float>();
        List<int> upgradeItemRequire = new List<int>();
        List<int> upgradeLevel = new List<int>();
        foreach (string line in allLines)
        {
            string[] splitData = line.Split(';');
            Debug.Log(line);
            if (splitData[0].Contains("Level") && splitData[0].Contains(swordType))
            {
                Debug.Log("geldi");
                if (swordSO != null)
                {

                    AssetDatabase.CreateAsset(swordSO, $"Assets/ScriptableObjects/Items/{swordType}/{swordSO.swordName}.asset");
                    upgradeMoney.Clear();
                    upgradeItemRequire.Clear();
                    upgradeLevel.Clear();
                }
                swordSO = ScriptableObject.CreateInstance<SwordSO>();
                swordSO.level = int.Parse((splitData[0].Replace("Level ", "").Replace(" "+swordType, "").Split("-"))[0]);
            }
            else if (splitData[1].Equals("Level :"))
            {
                upgradeLevel.Clear();
                Debug.Log(splitData[2]);

                Debug.Log(splitData.Length);
                for (int j = 1; j < splitData.Length - 2; j++)
                {
                    if (splitData[j + 2].Length == 0)
                    {
                        break;
                    }
                    upgradeLevel.Add(int.Parse(splitData[j + 2].Replace(".", "")));
                    Debug.Log(upgradeLevel[j - 1]);

                }
            }
            else if (splitData[1].Contains("Attack Value") && !splitData[1].Contains("Magical"))
            {
                swordSO.swordName = splitData[0].Replace(".png", "");
                for (int j = 0; j < splitData.Length - 2; j++)
                {
                    Debug.Log(splitData[j + 2]);
                    if (splitData[j + 2].Length == 0)
                    {
                        break;
                    }
                    string[] floats = splitData[j + 2].Split("-");
                    swordSO.minAndMaxAttackValue.Add(new Vector2(float.Parse(floats[0]), float.Parse(floats[1])));

                }
            }
            else if (splitData[1].Contains("Magical Attack Value"))
            {
                for (int j = 0; j < splitData.Length - 2; j++)
                {
                    if (splitData[j + 2].Length == 0)
                    {
                        break;
                    }
                    Debug.Log(splitData[j + 2]);
                    string[] floats = splitData[j + 2].Split("-");
                    Debug.Log(new Vector2(float.Parse(floats[0]), float.Parse(floats[1])));
                    swordSO.minAndMaxMagicalAttackValue.Add(new Vector2(float.Parse(floats[0]), float.Parse(floats[1])));
                }
            }
            else if (splitData[1].Contains("Attack Speed"))
            {
                for (int j = 0; j < splitData.Length - 2; j++)
                {
                    if (splitData[j + 2].Length == 0)
                    {
                        break;
                    }
                    float attackSpeed = float.Parse(splitData[j + 2].Replace("%", ""));

                    Debug.Log(attackSpeed);
                    swordSO.attackSpeed.Add(attackSpeed);
                }
            }
            else if (splitData[1].Contains("Upgrade Yang"))
            {
                upgradeMoney.Clear();
                Debug.Log(splitData[2]);

                
                for (int j = 1; j < splitData.Length - 2; j++)
                {
                    Debug.Log(splitData[j + 2]);
                    if (splitData[j + 2].Length == 0)
                    {
                        break;
                    }
                    upgradeMoney.Add((splitData[j + 2].Contains("%"))?float.Parse(splitData[j + 2].Replace(".", "").Replace("%",""))/100 : float.Parse(splitData[j + 2].Replace(".", "")));
                    Debug.Log(upgradeMoney[j - 1]);

                }
            }

            else if (splitData[1].Contains("Upgrade Item"))
            {
                upgradeItemRequire.Clear();

                for (int j = 1; j < splitData.Length - 2; j++)
                {
                    if (splitData[j + 2].Length == 0)
                    {
                        break;
                    }
                    upgradeItemRequire.Add(int.Parse(splitData[j + 2].Replace("-", "0").Replace("x", "")));
                    Debug.Log(upgradeItemRequire[j - 1]);

                }
                upgradeUPItem = true;

            }
            else if (upgradeUPItem)
            {
                string upgradeItemsPath = "Assets/ScriptableObjects/UpgradeItem";
                string[] upgradeItemsGuids = AssetDatabase.FindAssets("t:UpgradeItemsSO", new[] { upgradeItemsPath });
                List<UpgradeItemsSO> upgradeItemSOs = new List<UpgradeItemsSO>();
                foreach (string upgradeItemsguid in upgradeItemsGuids)
                {
                    string upgradePath = AssetDatabase.GUIDToAssetPath(upgradeItemsguid);
                    upgradeItemSOs.Add(AssetDatabase.LoadAssetAtPath<UpgradeItemsSO>(upgradePath));

                }
                for (int j = 1; j < splitData.Length - 2; j++)
                {
                    bool conditionMet = false;

                    if (splitData[j + 2].Length == 0)
                    {
                        break;
                    }
                    Debug.Log(splitData[j + 2].Replace("-", "0").Replace("x", ""));
                    foreach (UpgradeItemsSO upgradeItemSO in upgradeItemSOs)
                    {
                        if (splitData[j + 2].Replace(".png", "") == upgradeItemSO.name)
                        {
                            conditionMet = true;
                            Debug.Log("geldi");
                            swordSO.Requirement.Add((upgradeItemSO, upgradeItemRequire[j - 1], upgradeMoney[j - 1], (upgradeLevel == null) ? upgradeLevel[j-1]:swordSO.level));
                            break;
                        }
                        if (conditionMet)
                        {
                            Debug.Log("buldu ama devam etti");
                        }
                    }
                    /* upgradeItemRequire.Add(int.Parse(splitData[j + 2].Replace("-", "0").Replace("x", "")));
                     //swordSO.Requirement.Add()
                     Debug.Log(upgradeItemRequire[j - 1]);*/
                    if (!conditionMet)
                    {
                        throw new System.Exception($"Hiçbir eşleşme bulunamadı! splitData: {splitData[j + 2]}");
                    }




                }
                upgradeUPItem = false;
            }

            else if (splitData[0].Contains("yang") || splitData[0].Contains("Not available at NPC"))
            {
                swordSO.price = int.Parse(splitData[0].Replace("Not available at NPC", "0").Replace(" Yang", ""));
            }
            else if (splitData[0].Contains("Sockets"))
            {
                swordSO.sockets = int.Parse(splitData[0].Replace("Sockets:", ""));
            }
        }
        AssetDatabase.SaveAssets();
    }
    /*[MenuItem("Tools/Generate Sword")]
    public static void CsvTOSword()
    {
        int i = 0;
        string[] allLines = File.ReadAllLines(Application.dataPath + SwordCsvPath);
        SwordSO swordSO=null;
        List<float> upgradeMoney = new List<float>();
        List<int> upgradeItemRequire = new List<int>();
        foreach (string line in allLines)
        {
            if (line.Length <= 13)
            {
                AssetDatabase.CreateAsset(swordSO,  $"Assets/ScriptableObjects/Items/Sword/{swordSO.swordName}.asset");
                i = 0;
            }
            Debug.Log(line.Length);
            string[] splitData= line.Split(";");
            if (i == 0)
            {
                swordSO = ScriptableObject.CreateInstance<SwordSO>();
                swordSO.swordName = splitData[0];
                i++;
            }
            else if (i == 1)
            {
                for (int j = 0; j < splitData.Length-2; j++) {
                    Debug.Log(splitData.Length);
                    string[] floats=splitData[j+2].Split("-");
                    swordSO.minAndMaxAttackValue.Add(new Vector2(float.Parse(floats[0]), float.Parse(floats[1])))  ;
                    if (splitData[j].Length == 0)
                    {
                        return;
                    }
                }
                i++;
            }
            else if (i == 2)
            {
                for (int j = 0; j < splitData.Length - 2; j++)
                {
                    Debug.Log(splitData[j + 2]);
                    string[] floats = splitData[j + 2].Split("-");
                    Debug.Log(new Vector2(float.Parse(floats[0]), float.Parse(floats[1])));
                    swordSO.minAndMaxMagicalAttackValue.Add(new Vector2(float.Parse(floats[0]), float.Parse(floats[1])));
                }
                i++;
            }
            else if (i == 3)
            {
                for (int j = 0; j < splitData.Length - 2; j++)
                {
                    float attackSpeed = float.Parse(splitData[j + 2].Replace("%", ""));

                    Debug.Log(attackSpeed);
                    swordSO.attackSpeed.Add(attackSpeed);
                }
                i++;
            }
            
            else if (i == 4)
            {
                upgradeMoney.Clear();
                Debug.Log(splitData[2]);
                swordSO.sockets = int.Parse(splitData[2].Replace("Sockets:", ""));
                Debug.Log(splitData.Length);
                for (int j = 1; j < splitData.Length - 2; j++)
                {
                    
                    upgradeMoney.Add(float.Parse(splitData[j + 2].Replace(".", "")));
                    Debug.Log(upgradeMoney[j-1]);
                    
                }
                i++;
            }
            else if (i == 5)
            {
                Debug.Log(splitData[2]);
                
                upgradeItemValue(upgradeItemRequire, splitData);
                
                Debug.Log(splitData.Length);
                i++;
            }
            else if (i == 6)
            {
                Debug.Log(splitData[2]);    
                swordSO.level = int.Parse(splitData[2].Replace("Level ", "").Replace(" Sword", ""));
                UpgradeItem(swordSO,splitData,upgradeItemRequire, upgradeMoney);
                
                i++;
            }
            else if (i == 7)
            {
                upgradeItemValue(upgradeItemRequire, splitData);

                Debug.Log(splitData.Length);
                i++;
            }
            else if (i == 8)
            {
                Debug.Log(splitData[2]);
                swordSO.level = int.Parse(splitData[2].Replace("Level ", "").Replace(" Sword", ""));
                UpgradeItem(swordSO, splitData, upgradeItemRequire, upgradeMoney);
                i++;
            }
            else if (i == 9)
            {
                upgradeItemValue(upgradeItemRequire, splitData);

                Debug.Log(splitData.Length);
                i++;
            }
            else if (i == 10)
            {
                Debug.Log(splitData[2]);
                swordSO.level = int.Parse(splitData[2].Replace("Level ", "").Replace(" Sword", ""));
                UpgradeItem(swordSO, splitData, upgradeItemRequire, upgradeMoney);
                AssetDatabase.CreateAsset(swordSO,  $"Assets/ScriptableObjects/Items/Sword/{swordSO.swordName}.asset");
                i = 0;
            }
            
              
        }
        AssetDatabase.SaveAssets();
    }*/
    /*public static void upgradeItemValue(List<int> upgradeItemRequire, string[] splitData)
    {
        upgradeItemRequire.Clear();

        for (int j = 1; j < splitData.Length - 2; j++)
        {

            upgradeItemRequire.Add(int.Parse(splitData[j + 2].Replace("-", "0").Replace("x", "")));
            Debug.Log(upgradeItemRequire[j - 1]);

        }

    }
    public static void UpgradeItem(SwordSO swordSO, string[] splitData, List<int> upgradeItemRequire, List<float> upgradeMoney)
    {

        string upgradeItemsPath = "Assets/ScriptableObjects/UpgradeItem";
        string[] upgradeItemsGuids = AssetDatabase.FindAssets("t:UpgradeItemsSO", new[] { upgradeItemsPath });
        List<UpgradeItemsSO> upgradeItemSOs = new List<UpgradeItemsSO>();
        foreach (string upgradeItemsguid in upgradeItemsGuids)
        {
            string upgradePath = AssetDatabase.GUIDToAssetPath(upgradeItemsguid);
            upgradeItemSOs.Add(AssetDatabase.LoadAssetAtPath<UpgradeItemsSO>(upgradePath));

        }
        for (int j = 1; j < splitData.Length - 2; j++)
        {
            bool conditionMet = false;
            if (splitData[j + 2].Length > 0)
            {
                Debug.Log(splitData[j + 2].Replace("-", "0").Replace("x", ""));
                foreach (UpgradeItemsSO upgradeItemSO in upgradeItemSOs)
                {
                    if (splitData[j + 2].Replace(".png", "") == upgradeItemSO.name)
                    {
                        conditionMet = true;
                        Debug.Log("geldi");
                        swordSO.Requirement.Add((upgradeItemSO, upgradeItemRequire[j - 1], upgradeMoney[j - 1],));
                        break;
                    }
                    if (conditionMet)
                    {
                        Debug.Log("buldu ama devam etti");
                    }
                }
                /* upgradeItemRequire.Add(int.Parse(splitData[j + 2].Replace("-", "0").Replace("x", "")));
                 //swordSO.Requirement.Add()
                 Debug.Log(upgradeItemRequire[j - 1
                if (!conditionMet)
                {
                    throw new System.Exception($"Hiçbir eşleşme bulunamadı! splitData: {splitData[j + 2]}");
                }
            }



        }

    }]);*/
}
