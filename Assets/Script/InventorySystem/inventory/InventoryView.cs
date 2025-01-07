// using Unity.Mathematics;
// using UnityEngine;
// using UnityEngine.EventSystems;
//
// namespace Script.InventorySystem
// {
//     public class InventoryView :MonoBehaviour ,IPointerClickHandler
//     {
//         private PointerEventData _eventData;
//         public void OnPointerClick(PointerEventData eventData)
//         {
//             this._eventData = eventData;
//             InventoryEvent.OnClickInventory?.Invoke();
//         }
//
//         public Vector2 GetClickPosition()
//         {
//             // Ekran koordinatındaki tıklama pozisyonunu al
//             Vector2 clickPosition = _eventData.position;
//
//             // UI elementinin RectTransform'ını al
//             RectTransform rectTransform = GetComponent<RectTransform>();
//
//             // RectTransform'daki sol üst köşeye göre pozisyonu hesapla
//             Vector2 localClickPosition;
//             RectTransformUtility.ScreenPointToLocalPointInRectangle(
//                 rectTransform, clickPosition, _eventData.pressEventCamera, out localClickPosition);
//
//             // Sol üst köşeyi (0, 0) yapmak için yerel pozisyonu dönüştür
//             Vector2 topLeftAdjustedPosition = new Vector2(
//                 localClickPosition.x + rectTransform.rect.width / 2,
//                 localClickPosition.y - rectTransform.rect.height / 2
//             );
//             float x = topLeftAdjustedPosition.x / _rowWidth;
//             float y = Mathf.Abs(topLeftAdjustedPosition.y) / _rowheight;
//             int2 gridposition = new int2(Mathf.FloorToInt(x), Mathf.FloorToInt(y));
//             
//             InventoryStorage.ChangePos(this._currentObjectController, gridposition,
//                 _activePageController.PageModel.pageIndex);
//         }
//     }
// }