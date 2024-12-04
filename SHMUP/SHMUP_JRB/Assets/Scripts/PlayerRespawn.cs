using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] float respawnTime = 1f;
    Vector2 spawnPos;
    MovementController movement;

    private void Awake()
    {
        movement = GetComponent<MovementController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = this.transform.position;
    }

    public IEnumerator Respawn()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<FireProjectile>().enabled = false;
        movement.Velocity = Vector3.zero;
        movement.Position = spawnPos;
        transform.position = spawnPos;
        movement.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.gameObject.GetComponent<FireProjectile>().enabled = true;
        movement.enabled = true;
    }
}
