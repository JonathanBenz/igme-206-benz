using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    float radius;

    public float Radius { get { return radius; } }
    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<SpriteRenderer>().bounds.extents.magnitude;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
