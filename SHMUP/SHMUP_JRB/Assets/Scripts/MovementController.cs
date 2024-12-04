using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector3 position;
    private Vector3 velocity;

    Camera cam;
    float camHeight;
    float camWidth;

    InputController input;
    SpriteInfo spriteInfo;

    public Vector3 Position { get { return position; } set { position = value; } }
    public Vector3 Velocity { get { return velocity; } set { velocity = value; } }

    private void Awake()
    {
        input = GetComponent<InputController>();
        spriteInfo = GetComponent<SpriteInfo>();
    }
    private void Start()
    {
        position = this.transform.position;
        velocity = Vector3.zero;

        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        // Update velocity and position
        velocity = speed * input.Direction * Time.deltaTime;
        position += velocity * Time.deltaTime;
        transform.position = position;
        CheckForEdgeOfScreen();
    }

    /// <summary>
    /// If ball hits the edge of the screen, make it bounce!
    /// </summary>
    private void CheckForEdgeOfScreen()
    {
        if (transform.position.x >= (camWidth / 2f) - spriteInfo.halfOfX)
        {
            position = new Vector3((camWidth / 2f) - spriteInfo.halfOfX, position.y);
        }
        if (transform.position.x <= (-camWidth / 2f) + spriteInfo.halfOfX)
        {
            position = new Vector3((-camWidth / 2f) + spriteInfo.halfOfX, position.y);
        }
        if (transform.position.y >= (camHeight / 2f) - spriteInfo.halfOfY)
        {
            position = new Vector3(position.x, (camHeight / 2f) - spriteInfo.halfOfY);
        }
        if (transform.position.y <= (-camHeight / 2f) + spriteInfo.halfOfY)
        {
            position = new Vector3(position.x, (-camHeight / 2f) + spriteInfo.halfOfY);
        }
    }
}