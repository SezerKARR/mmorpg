using System.Collections;
using System.Collections.Generic;
using Script.DroppedItem;
using Script.Inventory;
using Script.Inventory.Objects;
using Script.ObjectInstances;
using Script.Player;
using Script.ScriptableObject;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpDetector : MonoBehaviour
{

    private readonly List<IPickedUpAble> _pickedUpables = new List<IPickedUpAble>();
    public int pickedCount;
    private readonly float _minDistance = int.MaxValue;
    private IPickedUpAble _pickedUp;
    private void Awake()
    {
        InputPlayer.OnPickUpPressed += PickUp;
    }
    public void PickUp()
    {
        if (_pickedUpables.Count > 0)
        {

            foreach (IPickedUpAble pickedable in _pickedUpables)
            {
                if (Vector2.Distance(this.transform.position,pickedable.GetPosition()) < _minDistance)
                {
                    _pickedUp=pickedable;
                }

            }
            ObjectEvents.OnPickUp?.Invoke(_pickedUp);
            
        }
        else {  Debug.Log(_pickedUpables.Count+""+"al�nabilecek hi� bir e�ya yok"); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*var interactable = collision.GetComponent<IInteractable>();
        if(interactable != null && interactable.CanInteract())
        {
            _interactablesInRange.IsAdd(interactable);
        }*/
        var interactable = collision.GetComponent<IPickedUpAble>();
        if (interactable != null)
        {
            _pickedUpables.Add(interactable);
            pickedCount++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var interactable = collision.GetComponent<IPickedUpAble>();
        if (_pickedUpables.Contains(interactable))
        {
            _pickedUpables.Remove(interactable);
            pickedCount--;
        }
    }
}
