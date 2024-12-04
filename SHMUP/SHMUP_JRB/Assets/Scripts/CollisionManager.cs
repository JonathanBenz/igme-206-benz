using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] SpriteInfo[] enemies;
    [SerializeField] SpriteInfo player;
    public List<SpriteInfo> projectiles;

    Modes currentMode = Modes.AABB;

    public enum Modes
    {
        AABB,
        Circle
    }

    private void Start()
    {
        projectiles = new List<SpriteInfo>();
    }
    // Update is called once per frame
    void Update()
    {
        if (currentMode == Modes.AABB)
        {
            foreach (SpriteInfo enemy in enemies)
            {
                if (AABBCollision(player, enemy) && enemy.GetComponent<AgentMovement>().isRepawning == false)
                {
                    StartCoroutine(player.GetComponent<PlayerRespawn>().Respawn());
                }
                foreach(SpriteInfo projectile in projectiles)
                {
                    if(AABBCollision(projectile, enemy) && enemy.GetComponent<AgentMovement>().isRepawning == false)
                    {
                        StartCoroutine(FindObjectOfType<AgentRespawn>().Respawn(enemy.GetComponent<AgentMovement>()));
                        if(projectile != null)
                        {
                            Destroy(projectile.gameObject);
                            projectiles.Remove(projectile);
                        }
                    }
                }
            }
        }
        else if (currentMode == Modes.Circle)
        {
            foreach (SpriteInfo collidable in enemies)
            {
                CircleCollision(player, collidable);
            }
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
        if (objA.minX < objB.maxX && objA.maxX > objB.minX && objA.minY < objB.maxY && objA.maxY > objB.minY)
        {
            return true;
        }
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
        if ((objA.radius + objB.radius) > Vector2.Distance(objA.transform.position, objB.transform.position))
        {
            return true;
        }
        return false;
    }
}