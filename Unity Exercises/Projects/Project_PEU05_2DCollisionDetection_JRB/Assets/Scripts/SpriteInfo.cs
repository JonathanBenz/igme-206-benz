using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteInfo : MonoBehaviour
{
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public float radius;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        minX = spriteRenderer.bounds.min.x;
        minY = spriteRenderer.bounds.min.y;
        maxX = spriteRenderer.bounds.max.x;
        maxY = spriteRenderer.bounds.max.y;
        radius = spriteRenderer.bounds.extents.magnitude;
    }
    public void TurnRed()
    {
        spriteRenderer.color = Color.red;
    }
    public void TurnWhite()
    {
        spriteRenderer.color = Color.white;
    }
}
