using System.Collections;
using Script.DroppedItem;
using Script.ObjectInstances;
using Script.ScriptableObject;
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

        public override void OnActivate(ObjectInstance item, string playerName, Vector3 position)
        {
            
            base.OnActivate(item, playerName, position);
            StartCoroutine(WaitAndDestroy());
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
