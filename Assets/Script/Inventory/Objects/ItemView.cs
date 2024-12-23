using System.Collections.Generic;
using Script.Inventory.Objects;
using Unity.Mathematics;
using UnityEngine;

namespace Script.Inventory
{
    public class ItemView: ObjectView
    {
        private int height=1;
        protected override void Awake()
        {
            
            base.Awake();
            Destroy(_howManyText.gameObject);
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
            ImageChangeSize(height,1);
            
        }

        public override void SetObject(List<int2> position,Sprite sprite,int weight,float width,float height,int howMany)
        {
            this.height = weight;
            base.SetObject(position,sprite,weight,width,height,howMany);
            ImageChangeSize(weight);
        }

        
    }
}