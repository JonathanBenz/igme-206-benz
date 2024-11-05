using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] float speed;
    Camera cam;
    float height;
    float width;

    InputController input;

    private void Awake()
    {
        input = GetComponent<InputController>();
    }
    private void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object's current position by its velocity
        transform.position += (Vector3)(speed * input.Direction * Time.deltaTime);
        CameraEdgeWrapping();
    }

    /// <summary>
    /// If the car hits the edge of the camera, wrap to the other side. 
    /// </summary>
    private void CameraEdgeWrapping()
    {
        if (transform.position.x > width / 2f)
        {
            transform.position = new Vector3(-width / 2f, transform.position.y);
        }
        else if (transform.position.x < -width / 2f)
        {
            transform.position = new Vector3(width / 2f, transform.position.y);
        }
        else if (transform.position.y > height / 2f)
        {
            transform.position = new Vector3(transform.position.x, -height / 2f);
        }
        else if (transform.position.y < -height / 2f)
        {
            transform.position = new Vector3(transform.position.x, height / 2f);
        }
    }
}
