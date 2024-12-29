using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Script.Enemy;
using Script.Inventory.Objects;
using Script.ScriptableObject.Prefab;
using UnityEngine;
using UnityEngine.Serialization;

public class CreaturesGroupsHolder : MonoBehaviour
{
    public List<CreaturesGroup> creaturesGroups;
    public List<GameObject> childrenWithTag;
    public GameObject[] creatures;
    public float groupReturnsTime;
    public WildDog[] denemegroupcreaure;
    public ItemPrefabList creaturesPrefabList;
    private List<CreaturesGroup> _sortedCreaturesGroups;
    private ObjectPooler _creaturesPooler;
    private List<CreaturesSpawnArea> _creaturesSpawnArea;
    void Start()
    {
        _creaturesSpawnArea = GetComponentsInChildren<CreaturesSpawnArea>().ToList();
        foreach (CreaturesSpawnArea area in _creaturesSpawnArea)
        {
            creaturesGroups.AddRange(area.Initialize());
        }
        _sortedCreaturesGroups = creaturesGroups.OrderBy(obj => obj.GetDistanceTo(Vector3.zero)).ToList();
        CreatureDiffCalculator();
        
    }
    // public void FindAllChildren(Transform transform)
    // {
    //     int len = transform.childCount;
    //
    //     for (int i = 0; i < len; i++)
    //     {
    //         CreaturesGroups.Add(transform.GetChild(i).gameObject);
    //
    //         if (transform.GetChild(i).childCount > 0)
    //             FindAllChildren(transform.GetChild(i).transform);
    //     }
    // }
    
    private void CreatureDiffCalculator()
    {
        float diff = (float)_sortedCreaturesGroups.Count / creaturesPrefabList.objects.Count;
        int index = 0;
        foreach (CreaturesGroup group in _sortedCreaturesGroups)
        {
            
             float dificult=index / diff;
             for (int i = 0; i < group.totalCreatures; i++)
             {
                 group.creaturesDifficult.Add(Mathf.RoundToInt(dificult+(0.1f*i)));
             }
             index++;
        }
        float randomDiff = Random.Range(diff-1, diff+2);
        randomDiff=Mathf.Clamp(randomDiff,0,creaturesPrefabList.objects.Count);
        
    }

    public List<Transform> objectsToSort; // Sıralamak istediğiniz nesnelerin Transform referansları
    public Transform referencePoint; // Uzaklığına göre sıralama yapılacak referans nokta

    
        
    
    

}

