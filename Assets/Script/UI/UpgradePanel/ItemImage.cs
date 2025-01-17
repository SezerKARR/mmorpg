using Script.InventorySystem.Objects;
using Script.ObjectInstances;
using Script.ScriptableObject;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI.UpgradePanel
{
    public class ItemImage : MonoBehaviour
    {
        public RectTransform imageRectTransform;
        public Image itemController;
        public GameObject[] backGround;
        private float _startHeight=0;

        public void Open(ObjectAbstract objectAbstract)
        {
            if(_startHeight==0)_startHeight=itemController.rectTransform.sizeDelta.y;
            for (int i = 0; i < backGround.Length; i++)
            {
                if(i<=objectAbstract.weightInInventory-1)backGround[i].SetActive(true);
                else
                {
                    backGround[i].SetActive(false);
                }
                
            }
            itemController.gameObject.SetActive(true);
            itemController.sprite = objectAbstract.image;
            itemController.rectTransform.sizeDelta = new Vector2(itemController.rectTransform.sizeDelta.x, _startHeight*objectAbstract.weightInInventory);
            float a = _startHeight / 2*(objectAbstract.weightInInventory - 1);
            itemController.rectTransform.localPosition = new Vector3(0,a, 0);
            gameObject.SetActive(true);

        }
      
    }
}
