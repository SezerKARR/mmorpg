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

        // RectTransform'u al�yoruz.
        RectTransform rectTransform = yourUIElement.GetComponent<RectTransform>();

        // Panelin boyutlar�n� al�yoruz
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        // H�cre boyutlar�n� hesapl�yoruz
        float cellWidth = width / columns;
        float cellHeight = height / rows;
        gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);
    }
}
