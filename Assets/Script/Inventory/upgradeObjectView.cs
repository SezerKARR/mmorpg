using Unity.Mathematics;
using UnityEngine;

namespace Script.Inventory
{
    public class upgradeObjectView: ObjectView
    {
        public override void SetObject(int2 position, IInventorObjectable objectToPlace, float width, float height,int howMany)
        {
            base._howManyText.gameObject.SetActive(true);
            base._howManyText.text=howMany.ToString();
            base.SetObject(position, objectToPlace, width, height, howMany);
        }
    }
}