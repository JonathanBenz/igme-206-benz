using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    [SerializeField] float wanderTime = 1f;
    [SerializeField] float StayInBoundsWeight = 3f;
    [SerializeField] float maxWanderAngle = 45f;
    [SerializeField] float angleDelta = 10f;

    float wanderAngle;

    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = physics.MaxSpeed;
        maxForce = physics.MaxForce;
    }
    public override void CalcSteeringForces()
    {
        Wander(angleDelta, wanderAngle, maxWanderAngle);
        StayInBounds(CalcFuturePosition(wanderTime), StayInBoundsWeight);
    }
}
