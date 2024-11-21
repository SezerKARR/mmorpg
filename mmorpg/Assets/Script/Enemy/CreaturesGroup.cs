using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaturesGroup : MonoBehaviour
{
    private int totalCreatures;
    public int currentCreaturesNumber;
    [SerializeField]
    private GameObject parentObject;
    [SerializeField]
    private CreaturesGroupsHolder holder;
    [SerializeField]
    private List<GameObject> creature;
    [SerializeField]
    private List<int> creaturesNumber;
    [SerializeField]
    private float groupReturnTime;
    // Start is called before the first frame update
    void Start()
    {

        parentObject = this.transform.parent.gameObject;
        holder = parentObject.gameObject.GetComponent<CreaturesGroupsHolder>();

        //print(holder.groupReturnsTime);
        CreateGroupCreatures();
        totalCreatures = creaturesNumber.Count;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateGroupCreatures()
    {

        foreach (int creatureNumber in creaturesNumber)
        {
            
            GameObject currentCreatures = Instantiate(creature[creatureNumber], RandomPositionByObjectCircle(), Quaternion.identity);
            currentCreatures.transform.SetParent(this.transform);
            currentCreatures.GetComponent<EnemySkeleton>().creaturesGroup = this.gameObject.GetComponent<CreaturesGroup>();
            currentCreaturesNumber++;
        }
    }
    Vector3 RandomPositionByObjectCircle()
    {
        Vector2 position = new Vector2(Random.Range(transform.position.x - 2f, transform.position.x + 2f), Random.Range(transform.position.y - 2f, transform.position.y + 2f));
        return new Vector3(position.x, position.y, 0);
    }
    bool coroutineStart = false;
    public void CreateEnemy()
    {

        StartCoroutine(WaitBeforeCreateGroup());

    }
    public IEnumerator WaitBeforeCreateGroup()
    {
        if (!coroutineStart)
        {
            coroutineStart = true;
            //print("yeniden grup oluþturma aþamasýnda");

            if (gameObject.tag != "boss")
            {

                yield return new WaitForSeconds(5);
                //print("zaman geçti");
                CreateGroupCreatures();
            }
            else
            {
                yield return groupReturnTime;
            }
            coroutineStart = false;
        }


    }
}
