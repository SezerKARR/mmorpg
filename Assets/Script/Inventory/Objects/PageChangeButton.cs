using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Script.Inventory.Objects
{
    public class PageChangeButton : MonoBehaviour
    {
        public Color pressedColor;
        public Color normalColor;
        [FormerlySerializedAs("page")] public int pageIndex;

        public static Action<int> OnChangePageClicked;
        public void ChangeColorForPressed()
        {
            this.GameObject().GetComponent<Image>().color = pressedColor;
        }
        public void ChangeColorForNormal(int dummy)
        {
            this.GameObject().GetComponent<Image>().color = normalColor;
        }
        // Start is called before the first frame update
        void Awake()
        {
            if (pageIndex == 0)
            {
                ChangeColorForPressed();
            }
            this.GameObject().GetComponent<Button>().onClick.AddListener(OnButtonClick);
            OnChangePageClicked += ChangeColorForNormal;
        }
        public void OnButtonClick()
        {
            
            OnChangePageClicked?.Invoke(pageIndex);
            ChangeColorForPressed();
        }
        // Update is called once per frame
    
    }
}
