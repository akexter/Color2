using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    public float size;
    public float jumpForce;
    public GameObject ColorChanger;
    public GameObject Player;
    bool changeColor;
    UnityEngine.Color color;
    SpriteRenderer m_SpriteRenderer;
    Rigidbody2D rb;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        size = Random.Range(0.09375f, 0.125f);
        Vector3 scale = new Vector3(size, size, 1f);
        transform.localScale = scale;
        rb.velocity = new Vector2 (Random.Range(-2, 2), Random.Range(-2, 2));
        ColorChanger = GameObject.Find("ColorChanger");
        Player = GameObject.Find("Player");
        color = Player.GetComponent<PlayerColor>().color;
        changeColor = Player.GetComponent<PlayerColor>().changeColor;
        rb.gravityScale = Player.GetComponent<Rigidbody2D>().gravityScale;

        if (changeColor == true)
        {
            m_SpriteRenderer.color = new Color(color.r, color.g, color.b);
        }

        else
        {
            m_SpriteRenderer.color = new Color(1f, 1f, 1f);
        }
    }

    void FixedUpdate()
    {   
        if (size > 0)
        {
            size -= 0.00625f;
            Vector3 scale = new Vector2(size, size);
            transform.localScale = scale;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}