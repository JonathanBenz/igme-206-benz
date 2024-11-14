using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script applies physics to any GameObject it is attached to. 
/// </summary>
public class PhysicsObject : MonoBehaviour
{
    // Physics related fields
    [SerializeField] float mass = 1f;
    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 acceleration;
    private const float maxSpeed = 256f;

    // Friction related fields
    [Header("Friction")]
    [SerializeField] bool frictionEnabled = true;
    [SerializeField] float coeffOfFriction = 1f;

    // Gravity related fields
    [Header("Gravity")]
    [SerializeField] bool gravityEnabled = true;
    private const float gravity = -2f;

    // Screen edges related fields
    Camera cam;
    float height;
    float width;

    MouseTracker mouseTracker;

    private void Awake()
    {
        mouseTracker = GetComponent<MouseTracker>();
    }

    private void Start()
    {
        position = this.transform.position;
        direction = Vector3.zero;
        velocity = Vector3.zero;
        acceleration = Vector3.zero;

        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    private void Update()
    {
        // Apply all forces
        ApplyForce(mouseTracker.CursorPosition - this.transform.position);
        if (frictionEnabled)
        {
            ApplyFriction();
        }
        if(gravityEnabled)
        {
            ApplyGravity();
        }

        // Update velocity, position, and direction
        velocity += acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        position += velocity * Time.deltaTime;
        direction = velocity.normalized;

        transform.position = position;
        CheckForBounce();

        // Reset acceleration at the end of each frame
        acceleration = Vector3.zero;
    }

    /// <summary>
    /// Adjusts acceleration to account for an applied force.
    /// </summary>
    /// <param name="force"></param>
    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }
    /// <summary>
    /// Applies friction force which acts against the current velocity. 
    /// </summary>
    private void ApplyFriction()
    {
        Vector3 friction = -velocity;
        friction.Normalize();
        friction *= coeffOfFriction;
        ApplyForce(friction);
    }

    /// <summary>
    /// Applies gravity force.
    /// </summary>
    private void ApplyGravity()
    {
        Vector3 forceOfGravity = new Vector3(0f, gravity, 0f) * mass;
        ApplyForce(forceOfGravity);
    }

    /// <summary>
    /// If ball hits the edge of the screen, make it bounce!
    /// </summary>
    private void CheckForBounce()
    {
        if (transform.position.x > width / 2f)
        {
            position = new Vector3(width / 2f, position.y);
            velocity.x *= -1f;
        }
        else if (transform.position.x < -width / 2f)
        {
            position = new Vector3(-width / 2f, position.y);
            velocity.x *= -1f;
        }
        else if (transform.position.y > height / 2f)
        {
            position = new Vector3(position.x, height / 2f);
            velocity.y *= -1f;
        }
        else if (transform.position.y < -height / 2f)
        {
            position = new Vector3(position.x, -height / 2f);
            velocity.y *= -1f;
        }
    }
}
