using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    private Vector3 position;
    private Vector3 velocity;
    private Vector2 spawnPos;

    Camera cam;
    float camHeight;
    float camWidth;

    public bool isRepawning;
    // Start is called before the first frame update
    void OnEnable()
    {
        Reset();
        isRepawning = false;
    }

    private void OnDisable()
    {
        transform.position = spawnPos;
        isRepawning = true;
    }

    private void Start()
    {
        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        Reset();
    }

    private void Reset()
    {
        spawnPos = new Vector2(Random.Range((camWidth / 2f) + 5f, (camWidth / 2f) + 20f), Random.Range((-camHeight / 2f) + 3f, (camHeight / 2f) - 3f));
        position = spawnPos;
        transform.position = position;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Update velocity and position
        velocity = speed * Vector3.left * Time.deltaTime;
        position += velocity * Time.deltaTime;
        transform.position = position;
    }
}
