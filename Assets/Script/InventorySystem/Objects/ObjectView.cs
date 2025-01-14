using System;
using System.Collections.Generic;
using Script.InventorySystem.inventory;
using Script.ObjectInstances;
using Script.ScriptableObject;
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
        private Vector2 _originalSizeDelta;

        protected virtual void Awake()
        {
            image=gameObject.GetComponent<Image>();
            howManyText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            _imageRectTransform = image.GetComponent<RectTransform>();
            _originalSizeDelta = _imageRectTransform.sizeDelta; 

        
        }

    
        public virtual void SetObject(ObjectInstance objectInstance)
        {
            image.sprite = objectInstance.ımage;
            if (objectInstance.cellsInfo != null)
            {
                
                _imageWidth=InventoryManager.CellWeight;
                _imageHeight=InventoryManager.CellHeight;
                SetPosition(objectInstance.cellsInfo.cells);
            }
            
        }
        public virtual void SetPosition(ObjectAbstract objectAbstract)
        {
            this.image.sprite = objectAbstract.ımage;
        }
        public void SetPosition(List<int2> cellInt2)
        {
            this._imageRectTransform.sizeDelta =new Vector2(InventoryManager.CellWeight,InventoryManager.CellHeight);
            _imageRectTransform.anchorMin = new Vector2(0, 1); 
            _imageRectTransform.anchorMax = new Vector2(0, 1);  
        
            _imageRectTransform.anchoredPosition = new Vector3(cellInt2[0].x*InventoryManager.CellWeight+InventoryManager.CellWeight/2,-cellInt2[0].y*InventoryManager.CellHeight-InventoryManager.CellHeight/ 2,transform.position.z);
        
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

        public virtual void Reset()
        {
            _imageRectTransform.sizeDelta = _originalSizeDelta;
            _imageRectTransform.anchoredPosition = Vector2.zero;
        }
    }
}
