using Script.Inventory.Objects;
using Script.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Inventory
{
    public class ImageUnderCursor : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private void Awake()
        {
            PageEvent.OnClickPage += Close;
            GameEvent.OnItemDroppedWithoutPlayer += Close;
            ObjectEvents.ObjectClicked += Open;
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.position = Input.mousePosition;
            if(GetComponent<Image>().sprite==null )gameObject.SetActive(false);
        }

        private void Close(Vector2 arg1, int arg2)
        {
            this.gameObject.SetActive(false);
        }

        public void Close(ObjectAbstract dummy)
        {
            this.gameObject.SetActive(false);
        }
        public void Close()
        {
            this.gameObject.SetActive(false);
        }
        public void Open(ObjectController objectAbstract)
        {
            GetComponent<Image>().sprite = objectAbstract.ObjectAbstract.ımage;
            gameObject.SetActive(true);
        }
        public void Open(ObjectAbstract objectAbstract)
        {
            GetComponent<Image>().sprite = objectAbstract.ımage;
            gameObject.SetActive(true);
        }
        void Update()
        {
        

            _rectTransform.position = Input.mousePosition;

        }
    }
}