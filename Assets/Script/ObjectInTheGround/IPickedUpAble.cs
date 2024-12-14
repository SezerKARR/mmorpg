

using Script.Inventory.Objects;
using UnityEngine;

public interface IPickedUpAble
{
    GameObject GetGameObject();
    ObjectAbstract GetObject();
    int GetHowMany();
}

