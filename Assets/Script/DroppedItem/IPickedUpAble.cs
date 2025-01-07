using Script.Interface;
using Script.ObjectInstances;
using UnityEngine;

namespace Script.DroppedItem
{
    public interface IPickedUpAble:IPool
    {
        ObjectInstance GetObjectInstance();
        int GetHowMany();
        Vector2 GetPosition();
    }
}

