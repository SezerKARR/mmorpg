using System;
using System.Collections;
using System.Collections.Generic;
using ModestTree.Util;
using Script.Inventory;
using Script.Inventory.Objects;
using Script.UI.Tooltip;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ObjectView : MonoBehaviour ,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    
    protected ObjectController _objectController;
    protected RectTransform _imageRectTransform;
    public UnityAction OnObjectPressed;
    protected float _imageWidth, _imageHeight;
    [SerializeField] protected Image _image;
    [SerializeField] protected TextMeshProUGUI _howManyText;
    public UnityAction OnRightClick;
    public UnityAction OnEnter;
    public UnityAction OnExit;
    
    protected virtual void Awake()
    {
        _image=gameObject.GetComponent<Image>();
        _howManyText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        _imageRectTransform = _image.GetComponent<RectTransform>();
        
    }

    
    public virtual void SetObject(List<int2> position,Sprite sprite,int weight,float width,float height,int howMany)
    {
        Debug.Log("SetObject");
        //_howManyText.text = howMany.ToString();
        _image.sprite = sprite;
        _imageWidth=width;
        _imageHeight=height;
        SetPosition(position);
    }
    public virtual void SetPosition(Vector2 size)
    
    {
        _imageWidth=size.x;
        _imageHeight=size.y;
        _imageRectTransform.anchorMin = new Vector2(0, 1); // Sol alt
        _imageRectTransform.anchorMax = new Vector2(0, 1); // Sol alt
        //_imageRectTransform.pivot = new Vector2(0, 0); // Pivot noktasını sol alt olarak ayarla
       _imageRectTransform.anchoredPosition = new Vector3(_imageWidth/2,-_imageHeight/2,transform.position.z);
       
       
    }
    public void SetPosition(List<int2> cellInt2)
    {
        
        _imageRectTransform.anchorMin = new Vector2(0, 1);  // Sol üst köşe
        _imageRectTransform.anchorMax = new Vector2(0, 1);  // Sol üst köşe
        
        _imageRectTransform.anchoredPosition = new Vector3(cellInt2[0].x*_imageWidth+_imageWidth/2,-cellInt2[0].y*_imageHeight-_imageHeight/2,transform.position.z);
        
        //+new Vector3(cellInt2.x*_imageWidth+_imageWidth/2,cellInt2.y*_imageHeight+_imageHeight/2,transform.position.z);
    }
    public void SetHowManyText(int howMany)
    {
        _howManyText.text = howMany.ToString();
    }
    
    public  void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnObjectPressed?.Invoke();
            
        }
    
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick?.Invoke();

        }


    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        OnEnter?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnExit?.Invoke();
    }
}
