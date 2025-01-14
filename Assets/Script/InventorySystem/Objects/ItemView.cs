using Script.ObjectInstances;
using Script.ScriptableObject;
using UnityEngine;

namespace Script.InventorySystem.Objects
{
    public class ItemView: ObjectView
    {
        protected override void Awake()
        {
            
            base.Awake();
            Destroy(howManyText.gameObject);
        }

        public  void ImageChangeSize(int spriteHeight,int val)
        {
            var imageHeight = this.GetComponent<RectTransform>().rect.height;
            var imageWidth = this.GetComponent<RectTransform>().rect.width;
            float newHeight = imageHeight * spriteHeight;
            _imageRectTransform.sizeDelta = new Vector2(imageWidth, newHeight);
            float heightDifference = (newHeight - imageHeight) / 2f;
            _imageRectTransform.anchoredPosition = new Vector2(_imageRectTransform.anchoredPosition.x, _imageRectTransform.anchoredPosition.y+( val* heightDifference));
    
        }
        

        public override void SetPosition(ObjectAbstract objectAbstract )
        {
            
            base.SetPosition(objectAbstract);
            ImageChangeSize(objectAbstract.weightInInventory,1);
            
        }

        public override void SetObject(ObjectInstance objectInstance)
        {
            base.SetObject(objectInstance);
            if (objectInstance.cellsInfo != null)
            {
                ImageChangeSize(objectInstance.weightInInventory,-1);
                return;
            }
            ImageChangeSize(objectInstance.weightInInventory,1);
        }

        public override void Reset()
        {
            base.Reset();
        }
        
    }
}