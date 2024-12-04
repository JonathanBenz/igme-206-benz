using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] float speed = 1000f;
    private Vector3 position;
    private Vector3 velocity;

    Camera cam;
    float camHeight;
    float camWidth;

    CollisionManager collisionManager;

    private void Awake()
    {
        collisionManager = FindObjectOfType<CollisionManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
        velocity = Vector3.zero;

        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        collisionManager.projectiles.Add(this.gameObject.GetComponent<SpriteInfo>());
    }

    // Update is called once per frame
    void Update()
    {
        velocity = speed * Vector2.right * Time.deltaTime;
        position += velocity * Time.deltaTime;
        transform.position = position;
        CheckForEdgeOfScreen();
    }

    private void CheckForEdgeOfScreen()
    {
        if (transform.position.x >= camWidth / 2f)
        {
            collisionManager.projectiles.Remove(this.gameObject.GetComponent<SpriteInfo>());
            Destroy(this.gameObject);
        }
    }
}
