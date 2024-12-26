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
    public List<CreaturesGroup> CreaturesGroups;
    public List<GameObject> childrenWithTag;
    public GameObject[] creatures;
    public float groupReturnsTime;
    public WildDog[] denemegroupcreaure;
    public ItemPrefabList creaturesPrefabList;
    private List<CreaturesGroup> _sortedCreaturesGroups;
    private ObjectPooler _creaturesPooler;
 
    void Start()
    {
        _sortedCreaturesGroups = CreaturesGroups.OrderBy(obj => obj.GetDistanceTo(Vector3.zero)).ToList();
        //_creaturesPooler=new ObjectPooler(creaturesPrefabList,this.transform);
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
        float diff = (float)_sortedCreaturesGroups.Count / creaturesPrefabList.objects.Length;
        int index = 0;
        Debug.Log( diff );
        foreach (var VARIABLE in _sortedCreaturesGroups)
        {
            
             float dificult=index / diff;
             Debug.Log(dificult);
             index++;
        }
        float randomDiff = Random.Range(diff-1, diff+2);
        randomDiff=Mathf.Clamp(randomDiff,0,creaturesPrefabList.objects.Length);
        
    }

    public List<Transform> objectsToSort; // Sıralamak istediğiniz nesnelerin Transform referansları
    public Transform referencePoint; // Uzaklığına göre sıralama yapılacak referans nokta

    
        
    
    

}

