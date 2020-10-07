using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce; // How powerful the jump should be
	public float distanceGround; // Distance from player to ground detection
	public GameObject Player;
	public LayerMask layerMask; // What the raycast should collide with

    Rigidbody2D rb;

	void Start()
	{
        rb = GetComponent<Rigidbody2D>();
		distanceGround = GetComponent<Collider2D>().bounds.extents.y;
		Player = GameObject.Find("Player");
	}
	
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.gravityScale == 1)
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 0.1f, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);
                RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x - 0.1f, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);

                if (hit.distance <= distanceGround + 0.1f || hit3.distance <= distanceGround + 0.1f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(new Vector2(0f, jumpForce));
                }
            }

            else
            {
                RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x + 0.1f, transform.position.y), Vector2.up, Mathf.Infinity, layerMask);
                RaycastHit2D hit4 = Physics2D.Raycast(new Vector2(transform.position.x - 0.1f, transform.position.y), Vector2.up, Mathf.Infinity, layerMask);

                if (hit2.distance <= distanceGround + 0.1f || hit4.distance <= distanceGround + 0.15f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(new Vector2(0f, jumpForce));
                }
            }
        }
    }
}
