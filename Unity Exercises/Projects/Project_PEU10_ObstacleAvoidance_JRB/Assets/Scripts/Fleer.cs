using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agent
{
    Vector3 targetPosition;

    private void Start()
    {
        targetPosition = FindObjectOfType<Seeker>().transform.position;
        maxSpeed = physics.MaxSpeed;
        maxForce = physics.MaxForce;
    }

    public override void CalcSteeringForces()
    {
        Flee(targetPosition);
    }
}
