using System.Collections;
using System.Collections.Generic;
using Script.Inventory;
using Script.Inventory.Objects;
using Script.Player;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpDetector : MonoBehaviour
{

    private readonly List<IPickedUpAble> _pickedUpables = new List<IPickedUpAble>();
    public int pickedCount;
    private readonly float _minDistance = int.MaxValue;
    private ObjectAbstract _selectedObjectAbstract;
    private GameObject _selectedGameObject;
    private int _selectedSoHowMany;
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
                if (Vector2.Distance(new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y),
                    new Vector2(pickedable.GetGameObject().transform.position.x, pickedable.GetGameObject().transform.position.y)) < _minDistance)
                {
                    _selectedGameObject = pickedable.GetGameObject();
                    _selectedObjectAbstract = pickedable.GetObject();
                    _selectedSoHowMany = pickedable.GetHowMany();
                }

            }
            ObjectEvents.OnPickUp?.Invoke(_selectedObjectAbstract,_selectedSoHowMany,_selectedGameObject);
            
        }
        else {  Debug.Log(_pickedUpables.Count+""+"al�nabilecek hi� bir e�ya yok"); }
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
