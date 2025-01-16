using Script.ScriptableObject;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI.UpgradePanel
{
    public class ItemImage : MonoBehaviour
    {
        public RectTransform imageRectTransform;
        public Image image;
        public float buttonOrginalHeight;
        private void Awake()
        {
            
            imageRectTransform = this.image.GameObject().GetComponent<RectTransform>();
            buttonOrginalHeight = imageRectTransform.rect.height;
        }
    

        public void Open(ObjectAbstract inventorObjectable)
        {
            gameObject.SetActive(true);
            ChangeSprite(inventorObjectable);
        }
        public virtual void ImageChangeSize(int spriteHeight)
        {
            float newHeight = buttonOrginalHeight * spriteHeight;
            imageRectTransform.sizeDelta = new Vector2(imageRectTransform.sizeDelta.x, newHeight);
            float heightDifference = (newHeight - buttonOrginalHeight) / 2f;
            imageRectTransform.anchoredPosition = -new Vector2(imageRectTransform.anchoredPosition.x, imageRectTransform.anchoredPosition.y - heightDifference);
        }
        public virtual void ChangeSprite(ObjectAbstract inventorObjectAble)
        {


            ImageChangeSize(inventorObjectAble.weightInInventory);
            image.sprite = inventorObjectAble.image;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);


        }
    }
}
