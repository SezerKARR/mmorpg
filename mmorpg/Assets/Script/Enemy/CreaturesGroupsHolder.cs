using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaturesGroupsHolder : MonoBehaviour
{
    private string searchTag = "CreaturesGroup";
    public List<GameObject> allChildren;
    public List<GameObject> childrenWithTag;
    public GameObject[] creatures;
    public float groupReturnsTime;
    public WildDog[] denemegroupcreaure;
    void Start()
    {
        if (searchTag != null)
        {
            FindAllChildren(transform);
            GetChildObjectsWithTag(searchTag);
        }
    }
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            print("deneme yapýlýyor");
            foreach (EnemyCreatures creature in denemegroupcreaure)
            {
                creature.Death();
            }
       
            StartCoroutine(childrenWithTag[0].gameObject.GetComponent<CreaturesGroup>().WaitBeforeCreateGroup());
        }*/
        
    }
    public void FindAllChildren(Transform transform)
    {
        int len = transform.childCount;

        for (int i = 0; i < len; i++)
        {
            allChildren.Add(transform.GetChild(i).gameObject);

            if (transform.GetChild(i).childCount > 0)
                FindAllChildren(transform.GetChild(i).transform);
        }
    }

    public void GetChildObjectsWithTag(string _tag)
    {
        foreach (GameObject child in allChildren)
        {
            if (child.tag == _tag)
                childrenWithTag.Add(child);
        }
    }
}

