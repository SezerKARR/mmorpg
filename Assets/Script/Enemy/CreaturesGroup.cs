using System.Collections;
using System.Collections.Generic;
using Script.Inventory.Objects;
using Script.ScriptableObject.Prefab;
using UnityEngine;

namespace Script.Enemy
{
    public class CreaturesGroup : MonoBehaviour
    {
        [SerializeField]
        private int _totalCreatures;
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
        
        [SerializeField] private ItemPrefabList currentMapCreatures;
        private ObjectPooler _objectPooler;
        // Start is called before the first frame update
        void Start()
        {
            
            parentObject = this.transform.parent.gameObject;
            holder = parentObject.gameObject.GetComponent<CreaturesGroupsHolder>();

            //print(holder.groupReturnsTime);
            CreateGroupCreatures();
            _totalCreatures = creaturesNumber.Count;
        }
        public float GetDistanceTo(Vector3 point)
        {
            return Vector3.Distance(transform.position, point);
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

        private bool _coroutineStart ;
        public void CreateEnemy()
        {

            StartCoroutine(WaitBeforeCreateGroup());

        }
        // ReSharper disable Unity.PerformanceAnalysis
        public IEnumerator WaitBeforeCreateGroup()
        {
            if (!_coroutineStart)
            {
                _coroutineStart = true;
                //print("yeniden grup olu�turma a�amas�nda");

                if (!gameObject.CompareTag($"boss"))
                {

                    yield return new WaitForSeconds(5);
                    //print("zaman ge�ti");
                    CreateGroupCreatures();
                }
                else
                {
                    yield return groupReturnTime;
                }
                _coroutineStart = false;
            }


        }
    }
}
