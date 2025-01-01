using System.Collections;
using Script.ScriptableObject;
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
            
            this.playername.text = $"<color=yellow> {playerName} </color>";;
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
           
            if (objectAbstract.canEveryBodyTake)
            {
                GameEvent.OnItemDroppedWithoutPlayer(this.objectAbstract,this.transform);
               
            }
        
            Destroy(this.gameObject);
        }
    }
}
