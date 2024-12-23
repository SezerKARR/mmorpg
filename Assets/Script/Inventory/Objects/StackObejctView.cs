using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Script.Inventory.Objects
{
    public class StackObejctView:ObjectView
    {
        public override void SetObject(List<int2> position, Sprite sprite,int weight, float width, float height,int howMany)
        {
            base._howManyText.gameObject.SetActive(true);
            base._howManyText.text=howMany.ToString();
            base.SetObject(position, sprite,weight, width, height, howMany);
        }
    }
}