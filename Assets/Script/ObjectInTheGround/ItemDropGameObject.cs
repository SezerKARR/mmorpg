using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.ObjectInTheGround
{
    public class ItemDropGameObject : ItemDrop
    {
        private const DropType dropType = DropType.WithPlayerName;
        [FormerlySerializedAs("Playername")] public TMP_Text playername;
        public GameObject itemDropWithOutName;


        public override DropType GetDropType()
        {
            return dropType;
        }

        public override void OnActivate(ObjectAbstract item ,string playerName, Vector3 position)
        {
            
            this.playername.text = playerName;
            base.OnActivate(item, playerName,position);
            StartCoroutine(WaitAndDeleteName());

        }

        public override string GetPoolType()
        {
            return dropType.ToString();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        IEnumerator WaitAndDeleteName()
        {
            // suspend execution for 5 seconds
            yield return new WaitForSeconds(5);
            this.gameObject.SetActive(false);
            GameObject newItemDrop = Instantiate(itemDropWithOutName, this.transform.position, Quaternion.identity);
            if (objectAbstract.canEveryBodyTake)
            {
                ItemDropWithOutName itemDropComponent = newItemDrop.GetComponent<ItemDropWithOutName>();
                itemDropComponent.itemName.text = this.itemName.text;
                itemDropComponent.howMany = this.howMany;
                itemDropComponent.objectAbstract = this.objectAbstract;
            }
        
            Destroy(this.gameObject);
        }
    }
}
