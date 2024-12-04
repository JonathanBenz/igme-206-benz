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
    public float halfOfX;
    public float halfOfY;
    public float radius;

    SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        GetBounds();
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GetBounds();
    }

    void Update()
    {
        GetBounds();
    }

    void GetBounds()
    {
        minX = spriteRenderer.bounds.min.x;
        minY = spriteRenderer.bounds.min.y;
        maxX = spriteRenderer.bounds.max.x;
        maxY = spriteRenderer.bounds.max.y;
        halfOfX = (maxX - minX) / 2f;
        halfOfY = (maxY - minY) / 2f;
        radius = spriteRenderer.bounds.extents.magnitude;
    }
}