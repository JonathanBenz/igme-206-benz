using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    [SerializeField] float wanderTime = 1f;
    [SerializeField] float StayInBoundsWeight = 3f;
    [SerializeField] float maxWanderAngle = 45f;
    [SerializeField] float angleDelta = 10f;

    [Header("Obstacle Avoidance Parameter")]
    [SerializeField] float unitRadius = 5f;

    float wanderAngle;

    Obstacle[] obstacles;

    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = physics.MaxSpeed;
        maxForce = physics.MaxForce;
        obstacles = FindObjectsOfType<Obstacle>();
    }
    public override void CalcSteeringForces()
    {
        Wander(angleDelta, wanderAngle, maxWanderAngle);
        StayInBounds(CalcFuturePosition(wanderTime), StayInBoundsWeight);
        AvoidObstacle(obstacles, unitRadius);
    }

    private void OnDrawGizmos()
    {
        // Forward Vector
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 2f);

        // Right Vector
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * 2f);

        // Unit Radius
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, unitRadius);
    }
}
