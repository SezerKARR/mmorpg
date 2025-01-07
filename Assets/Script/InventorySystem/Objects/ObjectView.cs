using System.Collections.Generic;
using Script.InventorySystem.inventory;
using Script.ObjectInstances;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Script.InventorySystem.Objects
{
    public abstract class ObjectView : MonoBehaviour ,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
    {
    
        protected ObjectController _objectController;
        protected RectTransform _imageRectTransform;
        public UnityAction onObjectPressed;
        protected float _imageWidth, _imageHeight;
        [FormerlySerializedAs("_image")] [SerializeField] protected Image image;
        [FormerlySerializedAs("_howManyText")] [SerializeField] protected TextMeshProUGUI howManyText;
        public UnityAction onRightClick;
        public UnityAction onEnter;
        public UnityAction onExit;
    
        protected virtual void Awake()
        {
            image=gameObject.GetComponent<Image>();
            howManyText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            _imageRectTransform = image.GetComponent<RectTransform>();
        
        }

    
        public virtual void SetObject(ObjectInstance objectInstance)
        {
            image.sprite = objectInstance.ımage;
            _imageWidth=InventoryManager.CellWeight;
            _imageHeight=InventoryManager.CellHeight;
            SetPosition(objectInstance.cellsInfo.cells);
        }
        public virtual void SetPosition(Vector2 size)
    
        {
            _imageWidth=size.x;
            _imageHeight=size.y;
            _imageRectTransform.anchorMin = new Vector2(0, 1); 
            _imageRectTransform.anchorMax = new Vector2(0, 1); 
            _imageRectTransform.anchoredPosition = new Vector3(_imageWidth/2,-_imageHeight/2,transform.position.z);
       
       
        }
        public void SetPosition(List<int2> cellInt2)
        {
        
            _imageRectTransform.anchorMin = new Vector2(0, 1); 
            _imageRectTransform.anchorMax = new Vector2(0, 1);  
        
            _imageRectTransform.anchoredPosition = new Vector3(cellInt2[0].x*_imageWidth+_imageWidth/2,-cellInt2[0].y*_imageHeight-_imageHeight/2,transform.position.z);
        
            //+new Vector3(cellInt2.x*_imageWidth+_imageWidth/2,cellInt2.y*_imageHeight+_imageHeight/2,transform.position.z);
        }
        public void SetHowManyText(int howMany)
        {
            howManyText.text = howMany.ToString();
        }
    
        public  void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                onObjectPressed?.Invoke();
            
            }
    
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                onRightClick?.Invoke();

            }


        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            onEnter?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onExit?.Invoke();
        }
    }
}
