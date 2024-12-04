using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float shootCooldown = 1f;
    [SerializeField] float xOffset = 1f;
    float timer;
    InputController input;

    private void Awake()
    {
        input = GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(input.IsFiring && timer > shootCooldown)
        {
            Instantiate(projectilePrefab, new Vector2(transform.position.x + xOffset, transform.position.y), Quaternion.identity);
            timer = 0f;
        }
        timer += Time.deltaTime;
    }
}
