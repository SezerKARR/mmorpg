using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour
{
    Vector2 inputWalkVector;
    float inputShootFloat;
    bool inputPickUpFromGroundFloat;
    float inputClickFloat;
    private PlayerInput playerNewInput;
    // Start is called before the first frame update
    void Start()
    {
        playerNewInput = new PlayerInput();
        playerNewInput.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
