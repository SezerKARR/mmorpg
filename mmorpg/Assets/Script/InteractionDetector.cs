using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private List<IInteractable> _interactablesInRange = new List<IInteractable>();
    public void Interact()
    {
        if(_interactablesInRange.Count > 0)
        {
            var interactable = _interactablesInRange[0];
            interactable.Interact(); 
            if(interactable.CanInteract())
            {
                _interactablesInRange.Remove(interactable);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var interactable = collision.GetComponent<IInteractable>();
        if(interactable != null && interactable.CanInteract())
        {
            _interactablesInRange.Add(interactable);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var interactable=collision.GetComponent<IInteractable>();
        if (_interactablesInRange.Contains(interactable))
        {
            _interactablesInRange.Remove(interactable);
        }
    }
}
