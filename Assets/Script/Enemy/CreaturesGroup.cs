using System.Collections;
using System.Collections.Generic;
using Script.Inventory.Objects;
using Script.ScriptableObject.Prefab;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Enemy
{
    public class CreaturesGroup : MonoBehaviour
    {
        public int totalCreatures;
        public int currentCreaturesNumber;
        public List<int> creaturesDifficult;
        [SerializeField]
        private float groupReturnTime;
        
        [SerializeField] private ItemPrefabList currentMapCreatures;
        private ObjectPooler _objectPooler;
        // Start is called before the first frame update
        void Start()
        {
            CreateGroupCreatures();
            //print(holder.groupReturnsTime);
            totalCreatures = creaturesDifficult.Count;
        }
        public float GetDistanceTo(Vector3 point)
        {
            return Vector3.Distance(transform.position, point);
        }

        public void OnEnemyDeath()
        {
            currentCreaturesNumber--;
            if (currentCreaturesNumber == 0)
            {
                CreateEnemy();
            }
        }
        public void CreateGroupCreatures()
        {
        
            foreach (int creatureNumber in creaturesDifficult)
            {
            
                GameObject currentCreatures = Instantiate(currentMapCreatures.objects[creatureNumber].prefab, RandomPositionByObjectCircle(), Quaternion.identity);
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
