using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float distanceGround;
    public float distanceWall;
    public float grounded;
    public Vector3 Checkpoint;

    float move;

    public bool changeColor = false;

    public LayerMask layerMask;

    public GameObject Player;

    Rigidbody2D rb;
    SpriteRenderer m_SpriteRenderer;

    UnityEngine.Color color;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        distanceGround = GetComponent<Collider2D>().bounds.extents.y;
        distanceWall = GetComponent<Collider2D>().bounds.extents.x;
        Player = GameObject.Find("Player");
        Checkpoint = new Vector3(-14.5f, -6.5f, 0);
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(speed * move * grounded * 4f, 0));

        if (rb.velocity.x > speed)
        {
            rb.velocity = new Vector2(rb.velocity.x * 9 / 10, rb.velocity.y); // prevents the player from going above a velocity equal to their speed
        }
        if (rb.velocity.x < -speed)
        {
            rb.velocity = new Vector2(rb.velocity.x * 9 / 10, rb.velocity.y);
        }

        WallJump();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, layerMask);

        if (hit.distance <= distanceGround + 0.1f)
        {
            grounded = 1;
        }
    }
    void WallJump()
    {

        if (Input.GetKeyDown(KeyCode.Space)) // Draws a raycast in 3 directions to check whether or not you can wall jump
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, layerMask);

            RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity, layerMask);

            RaycastHit2D hit1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.left, Mathf.Infinity, layerMask);

            RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.right, Mathf.Infinity, layerMask);

            RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.25f), Vector2.left, Mathf.Infinity, layerMask);

            RaycastHit2D hit4 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.25f), Vector2.right, Mathf.Infinity, layerMask);

            if (hit1.distance <= distanceWall + 0.1f | hit3.distance <= distanceWall + 0.1f && hit.distance >= distanceGround + 0.1f && hitup.distance >= distanceGround + 0.1f)
            {
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector2(700, jumpForce));
                grounded = 0.5f;
            }

            if (hit2.distance <= distanceWall + 0.1f | hit4.distance <= distanceWall + 0.1f && hit.distance >= distanceGround + 0.1f && hitup.distance >= distanceGround + 0.1f)
            {
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector2(-700, jumpForce));
                grounded = 0.5f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        grounded = 1;

        if (other.gameObject.CompareTag("platform"))
        {
            transform.parent = other.transform;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        transform.parent = null;
        DontDestroyOnLoad(transform.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("scenechanger"))
        {
            ChangeScene(other.GetComponent<Rainbow>().LevelToChange);
            transform.position = new Vector3(-14.5f, -6.5f, 0);
            Checkpoint = new Vector3(-14.5f, -6.5f, 0);
            m_SpriteRenderer.color = new Color(1f, 1f, 1f);
            Player.GetComponent<PlayerColor>().changeColor = false;
        }

        if (other.gameObject.CompareTag("checkpoint"))
        {
            Checkpoint = other.GetComponent<Transform>().position;
            Player.GetComponent<PlayerColor>().changeColor = false;
        }
        if (other.gameObject.CompareTag("trigger"))
        {
            other.GetComponent<Trigger>().Triggered = true;
        }
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}