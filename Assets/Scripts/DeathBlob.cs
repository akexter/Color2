using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBlob : MonoBehaviour
{
    Rigidbody2D rb;
    float size;
    public GameObject Player;
    SpriteRenderer m_SpriteRenderer;
    public Color color;
    float time;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        size = 0.0375f;
        Vector3 scale = new Vector3(size, size, 1f);
        transform.localScale = scale;
        Player = GameObject.Find("Player");
        rb.velocity = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        rb.gravityScale = Player.GetComponent<Rigidbody2D>().gravityScale;

        Player.GetComponent<Death>().canRespawn += 1;

        if (Player.GetComponent<PlayerColor>().changeColor == true)
        {
            color = Player.GetComponent<PlayerColor>().color;
            m_SpriteRenderer.color = color;
        }

        else
        {
            color = new Color(1f, 1f, 1f);
        }
    }

    void FixedUpdate()
    {
        time += 1;

        if (time > 500)
        {
            Destroy(gameObject);
        }
    }
}
