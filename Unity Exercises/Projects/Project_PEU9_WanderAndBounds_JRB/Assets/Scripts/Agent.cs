using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsObject))]
public abstract class Agent : MonoBehaviour
{
    protected float maxSpeed;
    protected float maxForce;

    protected PhysicsObject physics;
    protected Vector3 totalForce;

    public PhysicsObject Physics { get { return physics; } }

    private void Awake()
    {
        physics = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CalcSteeringForces();

        totalForce = Vector3.ClampMagnitude(totalForce, maxForce);
        physics.ApplyForce(totalForce);
        totalForce = Vector3.zero;
    }

    public abstract void CalcSteeringForces();

    protected void Seek(Vector3 targetPos, float weight = 1f)
    {
        Vector3 desiredVelocity = targetPos - this.transform.position;
        desiredVelocity = desiredVelocity.normalized * maxSpeed;
        Vector3 seekForce = desiredVelocity - physics.Velocity;

        totalForce += seekForce * weight;
    }
    protected void Flee(Vector3 targetPos)
    {
        Vector3 desiredVelocity = (this.transform.position - targetPos) + this.transform.position;
        desiredVelocity = desiredVelocity.normalized * maxSpeed;
        Vector3 fleeForce = desiredVelocity - physics.Velocity;

        totalForce += fleeForce;
    }

    protected void Wander(float angleDelta, float wanderAngle, float maxWanderAngle, float weight = 1f)
    {
        float maxWanderChange = angleDelta * Time.deltaTime;
        wanderAngle += Random.Range(-maxWanderChange, maxWanderChange);
        wanderAngle = Mathf.Clamp(wanderAngle, -maxWanderAngle, maxWanderAngle);

        Vector3 wanderTarget = Quaternion.Euler(0f, 0f, wanderAngle) * physics.Direction.normalized + physics.Position;
        Seek(wanderTarget, weight);
    }

    public Vector3 CalcFuturePosition(float time)
    {
        return physics.Velocity * time + transform.position;
    }

    protected void StayInBounds(Vector3 futurePos, float weight = 1f)
    {
        if (futurePos.x > physics.CameraWidth / 2f ||
            futurePos.x < -physics.CameraWidth / 2f ||
            futurePos.y > physics.CameraHeight / 2f ||
            futurePos.y < -physics.CameraHeight / 2f)
        {
            Seek(Vector3.zero, weight);
        }
    }
}
