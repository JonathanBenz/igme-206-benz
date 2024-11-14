using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script receives and tracks the cursor position in worldspace. 
/// </summary>
public class MouseTracker : MonoBehaviour
{
    private Vector3 cursorPosition;
    private Camera cam;

    public Vector3 CursorPosition { get { return cursorPosition; } }

    private void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePosition();
    }

    /// <summary>
    /// Receive the position of the mouse in world space (and ignoring the z component). 
    /// </summary>
    private void GetMousePosition()
    {
        cursorPosition = Input.mousePosition;
        cursorPosition = cam.ScreenToWorldPoint(cursorPosition);
        cursorPosition = new Vector3(cursorPosition.x, cursorPosition.y, 0f);
    }
}
