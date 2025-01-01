

using Script.Inventory.Objects;
using Script.ScriptableObject;
using UnityEngine;

public interface IPickedUpAble
{
    GameObject GetGameObject();
    ObjectAbstract GetObject();
    int GetHowMany();
}

