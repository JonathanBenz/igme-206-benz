using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    Vector2 direction;
    bool isFiring;

    public Vector2 Direction { get { return direction; } }
    public bool IsFiring { get { return isFiring; } }

    /// <summary>
    /// Gets the player's input to determine the heading and direction of the vehicle.
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started) isFiring = true;
        else if (context.canceled) isFiring = false;
    }
}