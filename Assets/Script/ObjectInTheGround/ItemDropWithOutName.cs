using System.Collections;
using UnityEngine;

namespace Script.ObjectInTheGround
{
    public class ItemDropWithOutName : ItemDrop
    {
        private const DropType dropType = DropType.WithoutPlayerName;

        public override DropType GetDropType()
        {
            return dropType;
        }

        public override void OnActivate(ObjectAbstract item, string playerName, Vector3 position)
        {
            StartCoroutine(WaitAndDestroy());
            base.OnActivate(item, playerName, position);
        }
        public override string GetPoolType()
        {
            return dropType.ToString();
        }


        IEnumerator WaitAndDestroy()
        {
            // suspend execution for 5 seconds
            yield return new WaitForSeconds(5);
        
            Destroy(this.gameObject);
        }
    }
}
