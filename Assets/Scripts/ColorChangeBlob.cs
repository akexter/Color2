using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeBlob : MonoBehaviour
{
    Rigidbody2D rb;
    float size;
    float alive = 0;
    public Color color;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        size = 0.0375f;
        Vector3 scale = new Vector3(size, size, 1f);
        transform.localScale = scale;
        rb.velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }
    void FixedUpdate()
    {
        alive += 1;

        if (alive >= 25)
        {
            Destroy(gameObject);
        }
    }
}