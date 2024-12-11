using Game.Components.EnvanterSistemiTest;
using System.Collections;
using System.Collections.Generic;
using Script.Inventory.İnventoryMVC;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class ItemController : ObjectController
{
    
    
    
    

    public ItemType ItemType => ItemType.Sword;

    private void Start()
    {
        inventoryView.ButtonClicked += OnButtonClick;
    }

    private void OnButtonClick()
    {
        ItemEvents.OnItemClicked?.Invoke(this);
        Debug.Log("OnButtonClick");
    }

    public void Place(Transform parent, int2 cellIndex)
    {
        base.cellIndex = cellIndex;
        transform.SetParent(parent);
        inventoryView.SetPosition(new Vector2(cellIndex.x * 100, cellIndex.y * 100));
    }
    public void Place(Transform parent, Vector2 positon)
    {
        cellIndex = new int2(-1, -1);
        transform.SetParent(parent);
        inventoryView.SetPosition(new Vector2(positon.x, positon.y));
    }


}

