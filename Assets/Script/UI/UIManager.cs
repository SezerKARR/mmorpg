using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool IsPointerOverUIElement()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        return raycastResults.Count > 0;
    }
    public GameObject GetUIElementUnderPointer()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        if (raycastResults.Count > 0)
        {
            
            return raycastResults[0].gameObject;
        }
        return null;
    }
    public bool IsPointerOutsideUI(RectTransform uiPanel)
    {
        Vector2 mousePosition = Input.mousePosition;
        Rect worldRect = RectTransformUtility.PixelAdjustRect(uiPanel, uiPanel.GetComponentInParent<Canvas>());

        // D�nya uzay�nda kontrol
        Vector3[] corners = new Vector3[4];
        uiPanel.GetWorldCorners(corners);

        Rect worldSpaceRect = new Rect(corners[0].x, corners[0].y,
                                       corners[2].x - corners[0].x,
                                       corners[2].y - corners[0].y);

        return !worldSpaceRect.Contains(mousePosition);
    }
}