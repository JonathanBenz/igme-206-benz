using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsObject))]
public abstract class Agent : MonoBehaviour
{
    protected float maxSpeed;
    protected float maxForce;

    protected PhysicsObject physics;

    public PhysicsObject Physics { get { return physics; } }

    private void Awake()
    {
        physics = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CalcSteeringForces();
    }

    public abstract void CalcSteeringForces();

    protected Vector3 Seek(Vector3 targetPos)
    {
        Vector3 desiredVelocity = targetPos - this.transform.position;
        desiredVelocity = desiredVelocity.normalized * maxSpeed;
        Vector3 seekForce = desiredVelocity - physics.Velocity;

        seekForce = Vector3.ClampMagnitude(seekForce, maxForce);
        return seekForce;
    }
    protected Vector3 Flee(Vector3 targetPos)
    {
        Vector3 desiredVelocity = (this.transform.position - targetPos) + this.transform.position;
        desiredVelocity = desiredVelocity.normalized * maxSpeed;
        Vector3 fleeForce = desiredVelocity - physics.Velocity;

        fleeForce = Vector3.ClampMagnitude(fleeForce, maxForce);
        return fleeForce;
    }
}
