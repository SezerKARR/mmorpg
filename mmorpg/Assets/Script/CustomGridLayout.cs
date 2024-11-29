using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomGridLayout : MonoBehaviour
{
    public int rows, columns;
    public GameObject yourUIElement;
    void Start()
    {
        PlaceItemsInGrid();
    }

    void PlaceItemsInGrid()
    {
        GridLayoutGroup gridLayoutGroup = this.gameObject.GetComponent<GridLayoutGroup>();

        // RectTransform'u alýyoruz.
        RectTransform rectTransform = yourUIElement.GetComponent<RectTransform>();

        // Panelin boyutlarýný alýyoruz
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        // Hücre boyutlarýný hesaplýyoruz
        float cellWidth = width / columns;
        float cellHeight = height / rows;
        gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);
    }
}
