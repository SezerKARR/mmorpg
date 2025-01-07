using Script.ObjectInstances;
using UnityEngine;

namespace Script.InventorySystem.Objects
{
    public class ItemView: ObjectView
    {
        private int _height=1;
        protected override void Awake()
        {
            
            base.Awake();
            Destroy(howManyText.gameObject);
        }

        public  void ImageChangeSize(int spriteHeight,int val=-1)
        {
            float newHeight = _imageHeight * spriteHeight;
            _imageRectTransform.sizeDelta = new Vector2(_imageWidth, newHeight);
            float heightDifference = (newHeight - _imageHeight) / 2f;
            _imageRectTransform.anchoredPosition = new Vector2(_imageRectTransform.anchoredPosition.x, _imageRectTransform.anchoredPosition.y+( val* heightDifference));
    
        }
        

        public override void SetPosition(Vector2 size)
        {
            
            base.SetPosition(size);
            ImageChangeSize(_height,1);
            
        }

        public override void SetObject(ObjectInstance objectInstance)
        {
            this._height = objectInstance.weightInInventory;
            base.SetObject(objectInstance);
            ImageChangeSize(_height);
        }

        
    }
}