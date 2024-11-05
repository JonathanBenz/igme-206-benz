using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    Vector2 lastFacingDirection;
    Vector2 direction;

    public Vector2 Direction { get { return direction; } }

    // Update is called once per frame
    void Update()
    {
        // Have the forward direction (which is up in 2D) face the direction
        transform.up = lastFacingDirection;
    }

    /// <summary>
    /// Gets the player's input to determine the heading and direction of the vehicle.
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();

        // This is to have the car face the last facing direction before there is no more input (otherwise it would default to facing the (0,0) direction whenever the player lets go of the keyboard)
        if (direction != Vector2.zero) 
            lastFacingDirection = direction;
    }
}
