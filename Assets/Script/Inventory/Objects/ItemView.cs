using Script.Inventory.Objects;
using Unity.Mathematics;
using UnityEngine;

namespace Script.Inventory
{
    public class ItemView: ObjectView
    {
        public  void ImageChangeSize(int spriteHeight)
        {
            float newHeight = _imageHeight * spriteHeight;
            _imageRectTransform.sizeDelta = new Vector2(_imageWidth, newHeight);
            float heightDifference = (newHeight - _imageHeight) / 2f;
            _imageRectTransform.anchoredPosition = new Vector2(_imageRectTransform.anchoredPosition.x, _imageRectTransform.anchoredPosition.y - heightDifference);
    
        }
        public override void SetObject(int2 position,Sprite sprite,int weight,float width,float height,int howMany)
        {
            base.SetObject(position,sprite,weight,width,height,howMany);
            ImageChangeSize(weight);
        }

        
    }
}