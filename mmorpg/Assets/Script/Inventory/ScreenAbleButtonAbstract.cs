using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ScreenAbleButtonAbstract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IScreenAble
{
    public IViewable scriptableObjectIWiewable;
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (this.scriptableObjectIWiewable != null)
        {
            Screen();
        }

    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        Hide();
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        



    }

    public void Screen()
    {
        TooltipManager.Instance.Screen(this.scriptableObjectIWiewable);
    }

    public void Hide()
    {
        TooltipManager.Instance.Hide();
    }
}
