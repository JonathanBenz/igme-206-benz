using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    Fleer target;

    private void Start()
    {
        target = FindObjectOfType<Fleer>();
        maxSpeed = physics.MaxSpeed;
        maxForce = physics.MaxForce;
    }

    public override void CalcSteeringForces()
    {
        Seek(target.transform.position);
        if(CircleCollision(this.physics, target.Physics))
        {
            RandomlySpawn(target);
        }
    }

    /// <summary>
    /// Checks for Circle Collision between two game objects
    /// </summary>
    /// <param name="objA"> The SpriteInfo component of the first object we are checking. </param>
    /// <param name="objB"> The SpriteInfo component of the second object we are checking. </param>
    /// <returns> True if collision was detected, false otherwise. </returns>
    bool CircleCollision(PhysicsObject objA, PhysicsObject objB)
    {
        if ((objA.Radius + objB.Radius) > Vector2.Distance(objA.transform.position, objB.transform.position))
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Randomly spawns the fleer to a new location. 
    /// </summary>
    /// <param name="fleer"></param>
    void RandomlySpawn(Fleer fleer)
    {
        float boundsX = physics.CameraWidth;
        float boundsY = physics.CameraHeight;
        fleer.Physics.Position = new Vector3(Random.Range(-boundsX / 2f, boundsX / 2f), Random.Range(-boundsY / 2f, boundsY / 2f), 0f);
    }
}
