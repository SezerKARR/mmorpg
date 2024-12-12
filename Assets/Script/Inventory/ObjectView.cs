using System;
using System.Collections;
using System.Collections.Generic;
using ModestTree.Util;
using Script.Inventory;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class ObjectView : MonoBehaviour
{
    [SerializeField] protected Button _button;
    protected ObjectController _objectController;
    protected RectTransform _imageRectTransform;
    public UnityAction OnItemPressed;
    protected float _imageWidth, _imageHeight;
    [SerializeField] protected Image _image;
    [SerializeField] protected TextMeshProUGUI _howManyText;
    private void Awake()
    {
        _button.onClick.AddListener(OnButtonClick);
        _imageRectTransform = GetComponent<RectTransform>();
        
    }

    public virtual void SetObject(int2 position,IInventorObjectable objectToPlace,float width,float height,int howMany)
    {
        //_howManyText.text = howMany.ToString();
        _image.sprite = objectToPlace.GetSprite();
        _imageWidth=width;
        _imageHeight=height;
        SetPosition(position);
    }
    public void SetPosition(int2 cellInt2)
    {
        Debug.Log(cellInt2.ToString());
        _imageRectTransform.anchorMin = new Vector2(0, 1);  // Sol üst köşe
        _imageRectTransform.anchorMax = new Vector2(0, 1);  // Sol üst köşe
        
        _imageRectTransform.anchoredPosition = new Vector3(cellInt2.x*_imageWidth+_imageWidth/2,-cellInt2.y*_imageHeight-_imageHeight/2,transform.position.z);
        
        //+new Vector3(cellInt2.x*_imageWidth+_imageWidth/2,cellInt2.y*_imageHeight+_imageHeight/2,transform.position.z);
    }
    public void SetHowManyText(int howMany)
    {
        _howManyText.text = howMany.ToString();
    }
    private void OnButtonClick() => OnItemPressed?.Invoke();
}
