using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] SpriteInfo[] collidableObjects;
    [SerializeField] SpriteInfo player;
    [SerializeField] TextMeshProUGUI currentModeText;
    Modes currentMode = Modes.AABB;

    public enum Modes
    {
        AABB,
        Circle
    }

    // Update is called once per frame
    void Update()
    {
        if(currentMode == Modes.AABB)
        {
            foreach(SpriteInfo collidable in collidableObjects)
            {
                AABBCollision(player, collidable);
            }
            currentModeText.text = "Collision Mode: AABB";
        }
        else if(currentMode == Modes.Circle)
        {
            foreach (SpriteInfo collidable in collidableObjects)
            {
                CircleCollision(player, collidable);
            }
            currentModeText.text = "Collision Mode: Circle";
        }
    }

    /// <summary>
    /// If the player presses Left Click, switch collision detection modes. 
    /// </summary>
    /// <param name="context"></param>
    public void SwitchModes(InputAction.CallbackContext context)
    {
        if (currentMode == Modes.AABB)
        {
            currentMode = Modes.Circle;
        }
        else currentMode = Modes.AABB;
    }

    /// <summary>
    /// Checks for AABB collision between two game objects
    /// </summary>
    /// <param name="objA"> The SpriteInfo component of the first object we are checking. </param>
    /// <param name="objB"> The SpriteInfo component of the second object we are checking. </param>
    /// <returns> True if collision was detected, false otherwise. </returns>
    bool AABBCollision(SpriteInfo objA, SpriteInfo objB)
    {
        if(objA.minX < objB.maxX && objA.maxX > objB.minX && objA.minY < objB.maxY && objA.maxY > objB.minY)
        {
            objA.TurnRed();
            objB.TurnRed();
            return true;
        }
        objA.TurnWhite();
        objB.TurnWhite();
        return false;
    }

    /// <summary>
    /// Checks for Circle Collision between two game objects
    /// </summary>
    /// <param name="objA"> The SpriteInfo component of the first object we are checking. </param>
    /// <param name="objB"> The SpriteInfo component of the second object we are checking. </param>
    /// <returns> True if collision was detected, false otherwise. </returns>
    bool CircleCollision(SpriteInfo objA, SpriteInfo objB)
    {
        if((objA.radius + objB.radius) > Vector2.Distance(objA.transform.position, objB.transform.position))
        {
            objA.TurnRed();
            objB.TurnRed();
            return true;
        }
        objA.TurnWhite();
        objB.TurnWhite();
        return false;
    }
}
