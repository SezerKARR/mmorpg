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
            UIManager.OnUpgradePanelNeed += Close;
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.position = Input.mousePosition;
            if(GetComponent<Image>().sprite==null )gameObject.SetActive(false);
        }

    
        public void Close(IInventorObjectable dummy)
        {
            this.gameObject.SetActive(false);
        }
        public void Close()
        {
            this.gameObject.SetActive(false);
        }
        public void Open(ObjectAbstract objectAbstract)
        {
            GetComponent<Image>().sprite = objectAbstract.Image;
            gameObject.SetActive(true);
        }
        void Update()
        {
        

            _rectTransform.position = Input.mousePosition;

        }
    }
}