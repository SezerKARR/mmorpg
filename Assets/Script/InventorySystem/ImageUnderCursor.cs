using System;
using Script.Inventory;
using Script.Inventory.Objects;
using Script.InventorySystem.Objects;
using Script.InventorySystem.Page;
using Script.ObjectInstances;
using Script.ScriptableObject;
using UnityEngine;
using UnityEngine.UI;

namespace Script.InventorySystem
{
    public class ImageUnderCursor : MonoBehaviour
    {
        public static Action OnCloseImageUnderCursor;
        private RectTransform _rectTransform;
        private void Awake()
        {
            OnCloseImageUnderCursor += Close;
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

        public void Close(ObjectInstance dummy,Vector3 dummyTransform)
        {
            this.gameObject.SetActive(false);
        }
        public void Close()
        {
            this.gameObject.SetActive(false);
        }
        public void Open(ObjectController objectAbstract)
        {
            GetComponent<Image>().sprite = objectAbstract.ObjectInstance.ımage;
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