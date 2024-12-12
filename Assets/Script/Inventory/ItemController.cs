using Game.Components.EnvanterSistemiTest;
using System.Collections;
using System.Collections.Generic;
using Script.Inventory;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class ItemController : ObjectController
{
    
    
    
    

    public ItemType ItemType => ItemType.Sword;

    

    
    

    public void Place(Transform parent, Vector2 positon)
    {
        cellIndex = new int2(-1, -1);
        transform.SetParent(parent);
        //objectView.SetPosition(new Vector2(positon.x, positon.y));
    }


    
}

