using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject Player;
    public LayerMask layerMask;
    public float distanceGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        distanceGround = GetComponent<Collider2D>().bounds.extents.y;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        rb.velocity = new Vector2(rb.velocity.x * 9 / 10, rb.velocity.y);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x * 49 / 50, rb.velocity.y);
    }
}