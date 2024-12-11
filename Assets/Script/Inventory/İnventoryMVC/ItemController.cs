using Game.Components.EnvanterSistemiTest;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class ItemController : MonoBehaviour
{
    [SerializeField] private int2 _cellIndex;
    [SerializeField] private int2 _size;
    [Inject][SerializeField] private InventoryView _inventoryView;
    [SerializeField] private ItemModel _itemModel;

    public ItemType ItemType => ItemType.Sword;

    private void Start()
    {
        _inventoryView.ButtonClicked += OnButtonClick;
    }

    private void OnButtonClick()
    {
        ItemEvents.OnItemClicked?.Invoke(this);
        Debug.Log("OnButtonClick");
    }

    public void Place(Transform parent, int2 cellIndex)
    {
        _cellIndex = cellIndex;
        transform.SetParent(parent);
        _inventoryView.SetPosition(new Vector2(cellIndex.x * 100, cellIndex.y * 100));
    }
    public void Place(Transform parent, Vector2 positon)
    {
        _cellIndex = new int2(-1, -1);
        transform.SetParent(parent);
        _inventoryView.SetPosition(new Vector2(positon.x, positon.y));
    }


}

