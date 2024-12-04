using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private List<IInteractable> _interactablesInRange = new List<IInteractable>();
    
    private List<IPickedUpAble> _pickedUpAbles = new List<IPickedUpAble>();
    public int pickedCount;//silinecek
    private float minDistance=int.MaxValue;
    private IViewable selectedIWievable;
    private GameObject selectedGameObject;
    private int selectedSoHowMany;
    private void Awake()
    {
        InputPlayer.OnPickUpPressed += PickUp;
    }
    public void PickUp()
    {
        
        /*if(_interactablesInRange.Count > 0)
        {
            var interactable = _interactablesInRange[0];
            interactable.Interact(); 
            if(interactable.CanInteract())
            {
                _interactablesInRange.Remove(interactable);
            }
        }*/
        
        if (_pickedUpAbles.Count > 0)
        {
            
            print(_pickedUpAbles.Count);
            foreach (var pickedable in _pickedUpAbles)
            {
                if (Vector2.Distance(new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y),
                    new Vector2(pickedable.GetGameObject().transform.position.x, pickedable.GetGameObject().transform.position.y)) < minDistance)
                {
                    selectedGameObject = pickedable.GetGameObject();
                    selectedIWievable = pickedable.GetIWievAble();
                    selectedSoHowMany = pickedable.GetHowMany();
                }

                Debug.Log("i" );
            }
            
            if (!InventoryManager.Instance.add(selectedIWievable, selectedSoHowMany))
            {
                Debug.Log("yer yok");
            } 
                

            Destroy(selectedGameObject); 
            


        }
        else { Debug.Log("alýnabilecek hiç bir eþya yok"); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*var interactable = collision.GetComponent<IInteractable>();
        if(interactable != null && interactable.CanInteract())
        {
            _interactablesInRange.Add(interactable);
        }*/
        var interactable = collision.GetComponent<IPickedUpAble>();
        if (interactable != null)
        {
            _pickedUpAbles.Add(interactable);
            pickedCount++;
            print(_pickedUpAbles.Count);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var interactable = collision.GetComponent<IPickedUpAble>();
        if (_pickedUpAbles.Contains(interactable))
        {
            _pickedUpAbles.Remove(interactable);
            pickedCount--;
        }
    }
}
