using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Script.Equipment;
using Script.ScriptableObject;
using Script.ScriptableObject.Equipment;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Editor.com.unity.mobile.notifications
{
    public class CsvToSo
    {
        private static readonly string UpgradeItemsCSVPath = "/CSVS/UpgradeItems.csv";

        private static string _monstersCsvPath = "/CSVS/Monsters.csv";

        private static string ExpCsvPath = "/CSVS/Exp.csv";
        //private static string ExpPerLevelCsvPath = "/CSVS/ExpPerLevel.csv";
        /*private static string BonusesCsvPath = "/CSVS/Bonuses.csv";
        private static string SwordCsvPath = "/CSVS/Swords.csv";
        private static string TwoHanded = "/CSVS/Two Handed.csv";
    private static string Blade = "/CSVS/Blade.csv";
    private static string fanCsvPath = "/CSVS/Fan.csv";
    private static string BellCsvPath = "/CSVS/Bell.csv";
    private static string ClawCsvPath = "/CSVS/Claw.csv";
    private static string DaggerCsvPath = "/CSVS/Dagger.csv";
    private static string BowCsvPath = "/CSVS/Bow.csv";*/
        private static string WariorHelmetCsvPath = "/CSVS/WarriorHelmet.csv";




        // [MenuItem("Utilities/Generate Upgrade Items")]
        // private static void CsvToSoUpgradeItems()
        // {
        //     string[] allLines = File.ReadAllLines(Application.dataPath + UpgradeItemsCSVPath);
        //     foreach (string line in allLines)
        //     {
        //         string[] splitData = line.Split(";");
        //
        //         UpgradeItemsSO upgradeItemsSO = ScriptableObject.CreateInstance<UpgradeItemsSO>();
        //
        //         upgradeItemsSO.ıtemName = splitData[0];
        //         upgradeItemsSO.dropsFrom = splitData[1];
        //         upgradeItemsSO.info = splitData[2];
        //
        //         AssetDatabase.CreateAsset(upgradeItemsSO,
        //             $"Assets/ScriptableObjects/UpgradeItem/{upgradeItemsSO.ıtemName}.asset");
        //     }
        //
        //     AssetDatabase.SaveAssets();
        // }
    

        [MenuItem("Utilities/Generate Upgrade Itesadass")]
        private static void UpdateMonsterCanDropForUPItems()
        {

            string upgradeItemsPath = "Assets/ScriptableObjects/UpgradeItem";
            string[] upgradeItemsGuids = AssetDatabase.FindAssets("t:UpgradeItemsSO", new[] { upgradeItemsPath });
            Debug.Log($"Found {upgradeItemsGuids.Length} upgrade item SOs");
            List<UpgradeItemsSO> upgradeItemSO = new List<UpgradeItemsSO>();
            string monsterpath = "Assets/ScriptableObjects/Monsters";
            string[] monsterGuids = AssetDatabase.FindAssets("t:MonsterSO", new[] { monsterpath });
            List<MonsterSO> monsterSO = new List<MonsterSO>();
            foreach (string monsterGuid in monsterGuids)
            {
                string monsterpaths = AssetDatabase.GUIDToAssetPath(monsterGuid);
                monsterSO.Add( AssetDatabase.LoadAssetAtPath<MonsterSO>(monsterpaths));


            }

            foreach (string upgradeItemsguid in upgradeItemsGuids)
            {
                string upgradePath = AssetDatabase.GUIDToAssetPath(upgradeItemsguid);
                upgradeItemSO.Add(AssetDatabase.LoadAssetAtPath<UpgradeItemsSO>(upgradePath));

            }
            
            Debug.Log(monsterSO.Count+"+"+upgradeItemSO.Count);
            foreach (MonsterSO monsterSO1 in monsterSO)
            {
                monsterSO1.canDrops = new List<ObjectAbstract>();
               
                foreach (UpgradeItemsSO upgradeItem in upgradeItemSO)
               
                {
                    
                    string[] dropfroms = upgradeItem.dropsFrom.Replace(", ", ",").Split(',');
                    foreach (string dropfrom in dropfroms)
                    {
                        if (dropfrom == monsterSO1.monsterName)
                        {

                            MonsterUpdate(monsterSO1, upgradeItem);
                            
                        }
                      
                    }
                }
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

        }
         [MenuItem("Utilities/Generate item")]
        private static void UpdateMonsterCanDropForItems()
        {

            string upgradeItemsPath = "Assets/ScriptableObjects/Items";
            string[] upgradeItemsGuids = AssetDatabase.FindAssets("t:ScriptableItemsAbstact", new[] { upgradeItemsPath });
            Debug.Log($"Found {upgradeItemsGuids.Length} upgrade item SOs");
            List<ScriptableItemsAbstact> upgradeItemSO = new List<ScriptableItemsAbstact>();
            string monsterpath = "Assets/ScriptableObjects/Monsters";
            string[] monsterGuids = AssetDatabase.FindAssets("t:MonsterSO", new[] { monsterpath });
            List<MonsterSO> monsterSO = new List<MonsterSO>();
            foreach (string monsterGuid in monsterGuids)
            {
                string monsterpaths = AssetDatabase.GUIDToAssetPath(monsterGuid);
                monsterSO.Add( AssetDatabase.LoadAssetAtPath<MonsterSO>(monsterpaths));


            }

            foreach (string upgradeItemsguid in upgradeItemsGuids)
            {
                string upgradePath = AssetDatabase.GUIDToAssetPath(upgradeItemsguid);
                upgradeItemSO.Add(AssetDatabase.LoadAssetAtPath<ScriptableItemsAbstact>(upgradePath));

            }
            Debug.Log(monsterSO.Count+"+"+upgradeItemSO.Count);
            foreach (MonsterSO monsterSO1 in monsterSO)
            {
                Dictionary<string, ScriptableItemsAbstact>
                    items = new Dictionary<string, ScriptableItemsAbstact>();
                foreach (ScriptableItemsAbstact upgradeItem in upgradeItemSO)
                
                {
                    
                    if (upgradeItem.level < int.Parse(monsterSO1.level))
                    {
                        if (items.Keys.Contains(upgradeItem.equipmentType.ToString()))
                        {
                            if (items[upgradeItem.equipmentType.ToString()].level < upgradeItem.level)
                            {
                                items[upgradeItem.equipmentType.ToString()] = upgradeItem;
                            }
                            if(Random.Range(0,sizeof(EquipmentType))==1)
                            {
                                items[upgradeItem.equipmentType.ToString()] = upgradeItem;
                            }
                            continue;
                        }
                        items.Add(upgradeItem.equipmentType.ToString(), upgradeItem);
                        
                        
                    }
                    
                }

                foreach (var item in items)
                {
                    MonsterUpdate(monsterSO1, item.Value);
                }
                
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

        }

        private static void MonsterUpdate(MonsterSO monsterSO,ObjectAbstract upgradeItem)
        {
            

            monsterSO.canDrops.Add(upgradeItem);
        }
        /*[MenuItem("Utilities/Generate Monsters")]
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
                monsterSO.level = splitData[2].Split("/")[0];
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
                    AssetDatabase.CreateAsset(monsterSO, $"{filePath}/{monsterSO.level+" "+monsterSO.monsterName}.asset");
                }
            }
            /*
            //foreach (string line in allLines)
            //{
            //    string[] splitData = line.Split(";");

            //    MonsterSO monsterSO = ScriptableObject.CreateInstance<MonsterSO>();

            //    monsterSO.Resistance = splitData[0].Split(",");
            //    monsterSO.race = splitData[1];
            //    monsterSO.level = splitData[2];
            //    monsterSO.stage = splitData[3];
            //    monsterSO.monsterName = splitData[4];
            //    monsterSO.location = splitData[5].Split(",");
            //    monsterSO.exp = splitData[6];

            //    foreach (string location in monsterSO.location)
            //    {
            //        i
            //        string locationx = location.Replace(" ", "");
            //        locationx = locationx.Replace("�", "");
            //        string filePath = $"Assets/ScriptableObjects/Monsters";
            //        Debug.Log(locationx);
            //        string name = locationx + " " + monsterSO.monsterName;
            //        Debug.Log(name);
            //        AssetDatabase.CreateAsset(monsterSO, $"{filePath}/{locationx + " " + monsterSO.monsterName}.asset");


            //    }
            //    AssetDatabase.CreateAsset(monsterSO, $"Assets/ScriptableObjects/Monsters/{monsterSO.monsterName}.asset");
            //}
            
            AssetDatabase.SaveAssets();

        }
    }*/
        // [MenuItem("Utilities/Generate Exp")]
        // private static void CsvToSoExp()
        // {
        //     string[] allLines = File.ReadAllLines(Application.dataPath + ExpCsvPath);
        //     ExpSo expSO = ScriptableObject.CreateInstance<ExpSo>();
        //     expSO.exps = new ExpToLevel[allLines.Length];
        //     int index = 0;
        //     foreach (string line in allLines.Skip(1))
        //     {
        //         string[] splitData = line.Split(";");
        //         Debug.Log(line);
        //         
        //
        //         // expSO.level = int.Parse(splitData[0]);
        //         // expSO.exp = long.Parse(splitData[1].Replace(".", ""));
        //         ExpToLevel expToLevel = new ExpToLevel()
        //             { level = int.Parse(splitData[0]), exp = splitData[1].Replace(".", "") };
        //         expSO.exps[index] = expToLevel;
        //      index++;   
        //     }
        //     string filePath = $"Assets/ScriptableObjects/Exp";
        //     AssetDatabase.CreateAsset(expSO, $"{filePath}/ExpForLevel.asset");
        //     AssetDatabase.SaveAssets();
        //
        // }
        /*[MenuItem("Utilities/Generate ExpPerLevel")]
private static void CsvFromSoExpPerLevel()
{
    int i = 0;
    string[] allLines = File.ReadAllLines(Application.dataPath + ExpPerLevelCsvPath);
    ExpPerLevelSO ExpPerLevelSO = ScriptableObject.CreateInstance<ExpPerLevelSO>();
    string filePath = $"Assets/ScriptableObjects/ExpPerLevel";
    int[] levelDiff = new int[30];
    float[] expRate = new float[30]; 
    foreach (string line in allLines.Skip(1))
    {
        string[] splitData = line.Split(";");
        Debug.Log(line);


        levelDiff[i] =int.Parse( splitData[0].Replace("<", "").Replace(">", "").Replace("=", ""));
        expRate[i] = float.Parse(splitData[1].Replace("%", ""));




        string name = i.ToString();


        i++;
    }
    ExpPerLevelSO.levelDiff = levelDiff;
    ExpPerLevelSO.expRate = expRate;

    AssetDatabase.CreateAsset(ExpPerLevelSO, $"{filePath}/ExpPerLevel.asset");
    AssetDatabase.SaveAssets();
    }*/
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
        //private static string NormalizeString(string sentence)
        //{
        //    sentence = sentence.ToLower();
        //    sentence=sentence.Trim().Replace(".", "").Replace(",", "");
        //    // Noktalama işaretlerini temizle, sadece kelimelerle çalış
        //    return sentence;
        //}

        /* [MenuItem("Utilities/Generate Bonuses")]
     public static void CsvToBonuses()
     {
         string bonusesPath = "Assets/ScriptableObjects/Bonuses";
         BonusForAttackSO bonusForAttackSO = ScriptableObject.CreateInstance<BonusForAttackSO>();
         BonusForDefenceSO bonusForDefenceSO = ScriptableObject.CreateInstance<BonusForDefenceSO>();
         BonusOtherSO bonusOtherSO = ScriptableObject.CreateInstance<BonusOtherSO>();
         string[] allLines = File.ReadAllLines(Application.dataPath + BonusesCsvPath);
         //AssetDatabase.CreateAsset(bonusForAttackSO, $"{bonusesPath}/BonusForAttackSO.asset");
         foreach (string line in allLines)
         {
             string[] splitData = line.Split(";");
             if (splitData[0].Length > 0)
             {
                 GiveBonuses(bonusForAttackSO, splitData, 0);

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
     public static BonusSO GiveBonuses(BonusSO bonusSO, string[] splitData, int i)
     {
         Bonus bonus = new Bonus();
         bonus.bonusName = splitData[i + 2];
         Debug.Log(splitData[i + 3] + splitData[i]);
         Debug.Log(splitData[i].Length);
         bonus.maxBonusRate = float.Parse(splitData[i + 3]);
         bonus.bonusRates = BonusRatesCalculate(float.Parse(splitData[i + 3]));
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
         else return new List<float> { maxBonusRates / 5, maxBonusRates / 2, maxBonusRates };

     }*/
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
        } }
    */
        /*[MenuItem("tools/CreateWeapon/ALL WEAPON/ALL")]
    public static void CreateAllWeapon()
    {
        CsvToBell();
        CsvToBlade();
        CsvToBow();
        CsvToClaw();
        CsvToDagger();
        CsvToFan();
        CsvToSword();
        CsvToTwoHanded();
    }
    
    [MenuItem("tools/CreateWeapon/Sword")]
    public static void CsvToSword()
    {
        CreateSword("Sword", SwordCsvPath);
    }
    [MenuItem("tools/CreateWeapon/TwoHanded")]
    public static void CsvToTwoHanded()
    {
        CreateSword("Two Handed", TwoHanded);
    }
    [MenuItem("tools/CreateWeapon/Blade")]
    public static void CsvToBlade()
    {

        CreateSword("Blade", Blade);
    }

    [MenuItem("tools/CreateWeapon/Fan")]
    public static void CsvToFan()
    {

        CreateSword("Fan", fanCsvPath);
    }
    [MenuItem("tools/CreateWeapon/Bell")]
    public static void CsvToBell()
    {

        CreateSword("Bell", BellCsvPath);
    }
    [MenuItem("tools/CreateWeapon/Claw")]
    public static void CsvToClaw()
    {

        CreateSword("Claw", ClawCsvPath);
    }
    [MenuItem("tools/CreateWeapon/Dagger")]
    public static void CsvToDagger()
    {

        CreateSword("Dagger", DaggerCsvPath);
    }
    [MenuItem("tools/CreateWeapon/Bow")]
    public static void CsvToBow()
    {

        CreateSword("Bow", BowCsvPath);
    }
    public static void CreateSword(string swordType,string swordPath)
    {
        string BonusesPath = "Assets/ScriptableObjects/Bonuses";
        string[] bonusGuids = AssetDatabase.FindAssets("t:BonusSO", new[] { BonusesPath });
        List<BonusSO> bonusSO = new List<BonusSO>();
        List<string> bonusesName = new List<string>();
        foreach (string bonusGuid in bonusGuids)
        {
            string bonusPaths = AssetDatabase.GUIDToAssetPath(bonusGuid);
            BonusSO addedableBonusSO = AssetDatabase.LoadAssetAtPath<BonusSO>(bonusPaths);
            bonusSO.Add(addedableBonusSO);
            foreach (var bonus in addedableBonusSO.bonuses)
            {
                bonusesName.Add(bonus.bonusName);
            }
            

        }
        bool upgradeUPItem = false;
        bool haveSwordBonus = false;
        string[] allLines = File.ReadAllLines(Application.dataPath + swordPath);
        SwordSO swordSO = null;
        List<float> upgradeMoney = new List<float>();
        List<int> upgradeItemRequire = new List<int>();
        List<int> upgradeLevel = new List<int>();
        string path = $"Assets/ScriptableObjects/Items/{swordType}";
        string statPath = "Assets/ScriptableObjects/Stat/StatSo.asset"; // Doğru yolu belirtin.
        StatSo bonusCantFind = AssetDatabase.LoadAssetAtPath<StatSo>(statPath);
        
         
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        foreach (string line in allLines)
        {
            string[] splitData = line.Split(';');
            if (splitData[0].Contains("Level") && splitData[0].Contains(swordType))
            {
               
                if (swordSO != null)
                {
                    
                    AssetDatabase.CreateAsset(swordSO, $"{path}/{swordSO.level+" "+ swordSO.ItemName}.asset");
                    
                    upgradeMoney.Clear();
                    upgradeItemRequire.Clear();
                    upgradeLevel.Clear();
                }
                
                swordSO = ScriptableObject.CreateInstance<SwordSO>();
                swordSO.level = int.Parse((splitData[0].Replace("Level ", "").Replace(" "+swordType, "").Split("-"))[0]);
                
                SetSwordType(swordType,swordSO);
            }
            else if (splitData[1].Equals("Level :"))
            {
                upgradeLevel.Clear();
                

                for (int j = 1; j < splitData.Length - 2; j++)
                {
                    if (splitData[j + 2].Length == 0)
                    {
                        break;
                    }
                    swordSO.levelWithPlus=int.Parse(splitData[j + 2].Replace(".", ""));
                    upgradeLevel.Add(int.Parse(splitData[j + 2].Replace(".", "")));
                    

                }
            }
            else if (splitData[1].Contains("BoardNewM.png"))
            {
                swordSO.ItemName = splitData[0].Replace(".png", "");
                
            }
            else if (splitData[1].Contains("Attack Value") && !splitData[1].Contains("Magical"))
            {
                
                for (int j = 0; j < splitData.Length - 2; j++)
                {
                    if (splitData[j + 2].Length == 0)
                    {
                        break;
                    }
                    string[] floats = splitData[j + 2].Split((new char[] { '-', '�' }));
                    
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
                    string[] floats = splitData[j + 2].Split("-");
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

                    swordSO.attackSpeed.Add(attackSpeed);
                }
                haveSwordBonus = true;
            }
            else if( haveSwordBonus&& !splitData[1].Contains("Upgrade Yang"))
            {
                List<float> bonusValues = new List<float>();
                for (int j = 0; j < splitData.Length - 2; j++)
                {
                    if (splitData[j + 2].Length == 0)
                    {
                        break;
                    }
                    float bonusValue = float.Parse(splitData[j + 2].Replace("%", ""));
                    //new string(splitData[j + 2].Where(char.IsDigit).ToArray());
                    bonusValues.Add(bonusValue);    
                    
                }
                swordSO.ItemBonuses.Add((splitData[1], bonusValues));

                if (!bonusCantFind.GetStats().Contains(splitData[1].Replace("�", "")))
                {
                    StatClass stat = new StatClass();
                    stat.statName = splitData[1].Replace("�", "");
                    stat.statValue = 0f;
                    bonusCantFind.AddObject(stat);
                }
            }
            else if (splitData[1].Contains("Upgrade Yang"))
            {
                haveSwordBonus = false;
                upgradeMoney.Clear();

                
                for (int j = 1; j < splitData.Length - 2; j++)
                {
                    if (splitData[j + 2].Length == 0)
                    {
                        break;
                    }
                    AddObject(ref swordSO.Requirements, (splitData[j + 2].Contains("%")) ? float.Parse(splitData[j + 2].Replace(".", "").Replace("%", "")) / 100 : float.Parse(splitData[j + 2].Replace(".", "")));
                    upgradeMoney.Add((splitData[j + 2].Contains("%"))?float.Parse(splitData[j + 2].Replace(".", "").Replace("%",""))/100 : float.Parse(splitData[j + 2].Replace(".", "")));
                    

                }
            }

            else if (splitData[1].Contains("Upgrade Item"))
            {
                upgradeItemRequire.Clear();

                for (int j = 1; j < splitData.Length - 2; j++)
                {
                    if (splitData[j + 2].Length != 0)
                    {
                        upgradeItemRequire.Add(int.Parse(splitData[j + 2].Replace("-", "0").Replace("x", "")));
                    }
                    
                    

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

                    if (splitData[j + 2].Length != 0)
                    {
                        foreach (UpgradeItemsSO upgradeItemSO in upgradeItemSOs)
                        {
                            if (splitData[j + 2].Replace(".png", "") == upgradeItemSO.name)
                            {
                                conditionMet = true;
                                //swordSO.AddObject(new RequirementClass(upgradeItemSO, upgradeItemRequire[j - 1], upgradeMoney[j - 1], (upgradeLevel == null) ? upgradeLevel[j-1]:swordSO.level));
                                UpgradeItem upgradeItem = new UpgradeItem();
                                upgradeItem.upgradeItemName = upgradeItemSO;
                                upgradeItem.howMany = upgradeItemRequire[j - 1];
                                AddObject(ref swordSO.Requirements,upgradeItem, j - 1);
                                break;
                            }
                            if (conditionMet)
                            {
                                Debug.Log("buldu ama devam etti");
                            }
                        }
                        if (!conditionMet)
                        {
                            UpgradeItemsSO upgradesItemSO = ScriptableObject.CreateInstance<UpgradeItemsSO>();
                            upgradesItemSO.upgradeName = splitData[j + 2].Replace(".png", "");
                            AssetDatabase.CreateAsset(upgradesItemSO, $"Assets/ScriptableObjects/UpgradeItem/{upgradesItemSO.upgradeName}.asset");
                            
                        }
                    }
                    
                    // upgradeItemRequire.Add(int.Parse(splitData[j + 2].Replace("-", "0").Replace("x", "")));
                     //swordSO.Requirement.Add()
                    // Debug.Log(upgradeItemRequire[j - 1]);
                   




                }
                upgradeUPItem = false;
            }

            else if (splitData[0].Contains("yang") || splitData[0].Contains("Not available at NPC"))
            {
                swordSO.price = int.Parse(splitData[0].Replace("Not available at NPC", "0").Replace(" Yang", ""));
            }
            if (splitData[0].Contains("Sockets"))
            {
                swordSO.sockets = int.Parse(splitData[0].Replace("Sockets:", ""));
            }
        }
        AssetDatabase.SaveAssets();
    }*/
        [MenuItem("Utilities/GenerateHelmet/Warrior")]
        public static void CreateWarriorHelmet()
        {
            CreateHelmet("Warrior",WariorHelmetCsvPath);
        }
    
        public static void CreateHelmet(string helmetType, string helmetPath)
        {
            string BonusesPath = "Assets/ScriptableObjects/Bonuses";
            string[] bonusGuids = AssetDatabase.FindAssets("t:BonusSO", new[] { BonusesPath });
            List<BonusSO> bonusSO = new List<BonusSO>();
            List<string> bonusesName = new List<string>();
            foreach (string bonusGuid in bonusGuids)
            {
                string bonusPaths = AssetDatabase.GUIDToAssetPath(bonusGuid);
                BonusSO addedableBonusSO = AssetDatabase.LoadAssetAtPath<BonusSO>(bonusPaths);
                bonusSO.Add(addedableBonusSO);
                foreach (var bonus in addedableBonusSO.bonuses)
                {
                    bonusesName.Add(bonus.bonusName);
                }


            }
            bool upgradeUPItem = false;
            bool haveSwordBonus = false;
            string[] allLines = File.ReadAllLines(Application.dataPath + helmetPath);
            HelmetSo helmetSo = null;
            List<float> upgradeMoney = new List<float>();
            List<int> upgradeItemRequire = new List<int>();
            List<int> upgradeLevel = new List<int>();
            string path = $"Assets/ScriptableObjects/Items/{helmetType}";
            string statPath = "Assets/ScriptableObjects/Stat/StatSo.asset"; // Doğru yolu belirtin.
            StatSo bonusCantFind = AssetDatabase.LoadAssetAtPath<StatSo>(statPath);


            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (string line in allLines)
            {
                string[] splitData = line.Split(';');
                if (splitData[0].Contains("Level") && splitData[0].Contains("Helmet"))
                {

                    if (helmetSo != null)
                    {
                        helmetSo.weightInInventory = 1;
                        AssetDatabase.CreateAsset(helmetSo, $"{path}/{helmetSo.level + " " + helmetSo.ıtemName}.asset");

                        upgradeMoney.Clear();
                        upgradeItemRequire.Clear();
                        upgradeLevel.Clear();
                    }

                    helmetSo = ScriptableObject.CreateInstance<HelmetSo>();
                    helmetSo.level = int.Parse((splitData[0].Replace("Level ", "").Replace(" Helmet" , "").Split("-"))[0]);
                    SetCanUseCharacter(helmetType,helmetSo);
                }
                else if (splitData[1].Equals("Level :"))
                {
                    upgradeLevel.Clear();


                    for (int j = 1; j < splitData.Length - 2; j++)
                    {
                        if (splitData[j + 2].Length == 0)
                        {
                            break;
                        }
                        helmetSo.levelWithPlus = int.Parse(splitData[j + 2].Replace(".", ""));
                        upgradeLevel.Add(int.Parse(splitData[j + 2].Replace(".", "")));


                    }
                }
                else if (splitData[1].Contains("BoardNewM.png"))
                {
                    helmetSo.ıtemName = splitData[0].Replace(".png", "");

                }
                else if (splitData[1].Contains("Defence") )
                {

                    for (int j = 0; j < splitData.Length - 2; j++)
                    {
                        if (splitData[j + 2].Length == 0)
                        {
                            break;
                        }

                        helmetSo.defence.Add(int.Parse(splitData[j + 2]));
                    
                    }
                    haveSwordBonus = true;
                }
            
                else if (haveSwordBonus && !splitData[1].Contains("Upgrade Yang"))
                {
                    List<float> bonusValues = new List<float>();
                    for (int j = 0; j < splitData.Length - 2; j++)
                    {
                        if (splitData[j + 2].Length == 0)
                        {
                            break;
                        }
                        float bonusValue = float.Parse(splitData[j + 2].Replace("%", ""));
                        //new string(splitData[j + 2].Where(char.IsDigit).ToArray());
                        bonusValues.Add(bonusValue);

                    }
                    helmetSo.ItemBonuses.Add((splitData[1], bonusValues));

                    if (!bonusCantFind.GetStats().Contains(splitData[1].Replace("�", "")))
                    {
                        StatClass stat = new StatClass();
                        stat.statName = splitData[1].Replace("�", "");
                        stat.statValue = 0f;
                        bonusCantFind.AddObject(stat);
                    }
                }
                else if (splitData[1].Contains("Upgrade Yang"))
                {
                    haveSwordBonus = false;
                    upgradeMoney.Clear();


                    for (int j = 1; j < splitData.Length - 2; j++)
                    {
                        if (splitData[j + 2].Length == 0)
                        {
                            break;
                        }
                        AddObject(ref helmetSo.Requirements, (splitData[j + 2].Contains("%")) ? float.Parse(splitData[j + 2].Replace(".", "").Replace("%", "")) / 100 : float.Parse(splitData[j + 2].Replace(".", "")));
                        upgradeMoney.Add((splitData[j + 2].Contains("%")) ? float.Parse(splitData[j + 2].Replace(".", "").Replace("%", "")) / 100 : float.Parse(splitData[j + 2].Replace(".", "")));


                    }
                }

                else if (splitData[1].Contains("Upgrade Item"))
                {
                    upgradeItemRequire.Clear();

                    for (int j = 1; j < splitData.Length - 2; j++)
                    {
                        if (splitData[j + 2].Length != 0)
                        {
                            upgradeItemRequire.Add(int.Parse(splitData[j + 2].Replace("-", "0").Replace("x", "")));
                        }



                    }
                    upgradeUPItem = true;

                }
                else if (upgradeUPItem)
                {
                    string upgradeItemsPath = "Assets/ScriptableObjects/UpgradeItem";
                    string[] upgradeItemsGuids = AssetDatabase.FindAssets("t:UpgradeItemsSO", new[] { upgradeItemsPath });
                    List<ObjectAbstract> upgradeItemSOs = new List<ObjectAbstract>();
                    foreach (string upgradeItemsguid in upgradeItemsGuids)
                    {
                        string upgradePath = AssetDatabase.GUIDToAssetPath(upgradeItemsguid);
                        upgradeItemSOs.Add(AssetDatabase.LoadAssetAtPath<ObjectAbstract>(upgradePath));

                    }
                    for (int j = 1; j < splitData.Length - 2; j++)
                    {
                        bool conditionMet = false;

                        if (splitData[j + 2].Length != 0)
                        {
                            foreach (ObjectAbstract upgradeItemSO in upgradeItemSOs)
                            {
                                if (splitData[j + 2].Replace(".png", "") == upgradeItemSO.name)
                                {
                                    conditionMet = true;
                                    //swordSO.AddObject(new RequirementClass(upgradeItemSO, upgradeItemRequire[j - 1], upgradeMoney[j - 1], (upgradeLevel == null) ? upgradeLevel[j-1]:swordSO.level));
                                    UpgradeItem upgradeItem = new UpgradeItem();
                                    upgradeItem.upgradeItemName = upgradeItemSO;
                                    upgradeItem.howMany = upgradeItemRequire[j - 1];
                                    AddObject(ref helmetSo.Requirements, upgradeItem, j - 1);
                                    break;
                                }
                                if (conditionMet)
                                {
                                    Debug.Log("buldu ama devam etti");
                                }
                            }
                            if (!conditionMet)
                            {
                                ObjectAbstract upgradesItemSO = ScriptableObject.CreateInstance<ObjectAbstract>();
                                upgradesItemSO.ıtemName = splitData[j + 2].Replace(".png", "");
                                AssetDatabase.CreateAsset(upgradesItemSO, $"Assets/ScriptableObjects/UpgradeItem/{upgradesItemSO.ıtemName}.asset");

                            }
                        }

                        /* upgradeItemRequire.Add(int.Parse(splitData[j + 2].Replace("-", "0").Replace("x", "")));
                     //swordSO.Requirement.Add()
                     Debug.Log(upgradeItemRequire[j - 1]);*/





                    }
                    upgradeUPItem = false;
                }

                else if (splitData[0].Contains("yang") || splitData[0].Contains("Not available at NPC"))
                {
                    helmetSo.price = int.Parse(splitData[0].Replace("Not available at NPC", "0").Replace(" Yang", ""));
                }
            
            }
            AssetDatabase.SaveAssets();
        }
        public static void AddObject(ref RequirementClass[] Requirements, UpgradeItem upgradeItem, int swordPlus)
        {
            Array.Resize(ref Requirements[swordPlus].upgradeItems, Requirements[swordPlus].upgradeItems.Length + 1);
            Requirements[swordPlus].upgradeItems[Requirements[swordPlus].upgradeItems.Length - 1] = upgradeItem;

        }
        public static void AddObject(ref RequirementClass[] Requirements, float money)
        {
            Array.Resize(ref Requirements, Requirements.Length + 1);
            RequirementClass requirementClass = new RequirementClass();
            requirementClass.upgradeMoney = money;
            Requirements[Requirements.Length - 1] = requirementClass;
        }
   
        public static void SetSwordType(string swordType,SwordSo swordSO)
        {
            if (swordType.Equals("Sword"))
            {
                swordSO.weightInInventory = 2;
                swordSO.typeWeapon = TypeWeapon.Swords;
                SetCanUseCharacter(CharacterType.Sura,swordSO);
                SetCanUseCharacter(CharacterType.Warrior,swordSO);
                SetCanUseCharacter(CharacterType.Ninja,swordSO);

            }
            else if (swordType.Equals("Two Handed"))
            {
                swordSO.weightInInventory = 3;
                swordSO.typeWeapon = TypeWeapon.TwoHandedWeapons;
                SetCanUseCharacter(CharacterType.Warrior,swordSO);

            }
            else if (swordType.Equals("Blade"))
            {
                swordSO.weightInInventory = 2;
                swordSO.typeWeapon = TypeWeapon.Blades;
                SetCanUseCharacter(CharacterType.Sura, swordSO);
            }
            else if (swordType.Equals("Fan"))
            {
                swordSO.weightInInventory = 1;
                swordSO.typeWeapon = TypeWeapon.Fans;
                SetCanUseCharacter(CharacterType.Shaman, swordSO);
            }
            else if (swordType.Equals("Bell"))
            {
                swordSO.weightInInventory = 1;
                swordSO.typeWeapon = TypeWeapon.Bells;
                SetCanUseCharacter(CharacterType.Shaman, swordSO);
            }
            else if (swordType.Equals("Claw"))
            {
                swordSO.weightInInventory = 1;
                swordSO.typeWeapon = TypeWeapon.Claws;
                SetCanUseCharacter(CharacterType.Lycan, swordSO);
            }
            else if (swordType.Equals("Dagger"))
            {
                swordSO.weightInInventory = 1;
                swordSO.typeWeapon = TypeWeapon.Daggers;
                SetCanUseCharacter(CharacterType.Ninja, swordSO);
            }
            else if (swordType.Equals("Bow"))
            {
                swordSO.weightInInventory = 1;
                swordSO.typeWeapon = TypeWeapon.Bows;
                SetCanUseCharacter(CharacterType.Ninja, swordSO);
            }

        }
        public static void SetCanUseCharacter(CharacterType characterType, ScriptableItemsAbstact scriptableItemsAbstact)
        {
            scriptableItemsAbstact.canUseCharacters.Add(characterType);
        }
        public static CharacterType FindCharacter(string character="Warrior")
        {
            foreach (CharacterType charEnum in Enum.GetValues(typeof(CharacterType)))
            {
                if (charEnum.ToString().Equals(character, StringComparison.OrdinalIgnoreCase))
                {
                    return charEnum;
                }
            }
            throw new ArgumentException("Invalid characterType type", nameof(character));
        }
        public static void SetCanUseCharacter(string character,ScriptableItemsAbstact scriptableItemsAbstact)
        {
        
            scriptableItemsAbstact.canUseCharacters.Add(FindCharacter(character));
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
        // [MenuItem("Utilities/UpdateItems")]
        // public static void UpdateItems()
        // {
        //     string[] guids = AssetDatabase.FindAssets("t:ScriptableItemsAbstact", new[] { "Assets/ScriptableObjects/Items" });
        //
        //     foreach (var guid in guids)
        //     {
        //         // Her bir SO'yu yükle
        //         string path = AssetDatabase.GUIDToAssetPath(guid);
        //         ScriptableItemsAbstact itemStatsSO = AssetDatabase.LoadAssetAtPath<ScriptableItemsAbstact>(path);
        //
        //         if (itemStatsSO != null)
        //         {
        //             // SetStatsOnce fonksiyonunu çağır
        //             //itemStatsSO.SetDropName();
        //             itemStatsSO.SetStats();
        //             EditorUtility.SetDirty(itemStatsSO);  // Değişiklikleri kaydetmek için
        //         }
        //     }
        //
        //     AssetDatabase.SaveAssets();
        //     AssetDatabase.Refresh();
        //
        // }
        // [MenuItem("Utilities/UpdateObjectsname")]
        // public static void UpdateObjects()
        // {
        //     string[] guids = AssetDatabase.FindAssets("t:ObjectAbstract", new[] { "Assets/ScriptableObjects" });
        //
        //     foreach (var guid in guids)
        //     {
        //         // Her bir SO'yu yükle
        //         string path = AssetDatabase.GUIDToAssetPath(guid);
        //         ObjectAbstract itemStatsSO = AssetDatabase.LoadAssetAtPath<ObjectAbstract>(path);
        //
        //         if (itemStatsSO != null)
        //         {
        //             itemStatsSO.SetDropName();
        //             EditorUtility.SetDirty(itemStatsSO);  // Değişiklikleri kaydetmek için
        //         }
        //     }
        //
        //     AssetDatabase.SaveAssets();
        //     AssetDatabase.Refresh();
        //
        // }
        // [MenuItem("Utilities/setHealthMonster")]
        // public static void UpdateObjects()
        // {
        //     string[] guids = AssetDatabase.FindAssets("t:MonsterSO", new[] { "Assets/ScriptableObjects" });
        //
        //     foreach (var guid in guids)
        //     {
        //         // Her bir SO'yu yükle
        //         string path = AssetDatabase.GUIDToAssetPath(guid);
        //         MonsterSO itemStatsSO = AssetDatabase.LoadAssetAtPath<MonsterSO>(path);
        //
        //         if (itemStatsSO != null)
        //         {
        //             itemStatsSO.SetHealth();
        //             EditorUtility.SetDirty(itemStatsSO);  // Değişiklikleri kaydetmek için
        //         }
        //     }
        //
        //     AssetDatabase.SaveAssets();
        //     AssetDatabase.Refresh();
    
        //}
    }
}
