using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public IState lastState;
    [SerializeField]
    public IState currentState;
    public float moveSpeed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        currentState = new IdleState();
        //currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}