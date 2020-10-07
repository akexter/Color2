using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public bool changeColor = false;
    public GameObject Player;
    SpriteRenderer m_SpriteRenderer;
    public Color color;
    public float currentColor = 0;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player");
        color = new Color(1f, 1f, 1f);

    }

    void Update()
    {
        if (changeColor == false)
        {
            Player.GetComponent<PlayerCtrl>().speed = 2.5f;
            Player.GetComponent<Jump>().jumpForce = 300f;
            Player.GetComponent<PlayerCtrl>().jumpForce = 300f;
            Player.GetComponent<Rigidbody2D>().gravityScale = 1;
            m_SpriteRenderer.color = new Color(1f, 1f, 1f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("colorchanger"))
        {

            if (other.GetComponent<ColorChange>().colorType > 0)
            {
                if (changeColor == false)
                {
                    color = other.GetComponent<ColorChange>().color;
                    m_SpriteRenderer.color = color;
                    changeColor = true;
                    currentColor = other.GetComponent<ColorChange>().colorType;

                    if (other.GetComponent<ColorChange>().colorType == 1)
                    {
                        Player.GetComponent<PlayerCtrl>().speed = 3f;
                    }

                    if (other.GetComponent<ColorChange>().colorType == 2)
                    {
                        Player.GetComponent<Jump>().jumpForce = 400f;
						Player.GetComponent<PlayerCtrl>().jumpForce = 400f;
                    }

                    if (other.GetComponent<ColorChange>().colorType == 3)
                    {
                        Player.GetComponent<Rigidbody2D>().gravityScale = -1;
                        Player.GetComponent<Jump>().jumpForce = -300f;
						Player.GetComponent<PlayerCtrl>().jumpForce = -300f;
                    }
                }

                if (changeColor == true)
                {
                    if (currentColor == 1 && other.GetComponent<ColorChange>().colorType == 2 || currentColor == 2 && other.GetComponent<ColorChange>().colorType == 1)
                    {
                        color = new Color(1f, 0f, 1f);
                        currentColor = 4;
                        m_SpriteRenderer.color = color;
                        Player.GetComponent<PlayerCtrl>().speed = 3f;
                        Player.GetComponent<Jump>().jumpForce = 400f;
						Player.GetComponent<PlayerCtrl>().jumpForce = 400f;
                    }

                    if (currentColor == 1 && other.GetComponent<ColorChange>().colorType == 3 || currentColor == 3 && other.GetComponent<ColorChange>().colorType == 1)
                    {
                        color = new Color(1f, 1f, 0f);
                        currentColor = 5;
                        m_SpriteRenderer.color = color;
                        Player.GetComponent<PlayerCtrl>().speed = 3f;
                        Player.GetComponent<Rigidbody2D>().gravityScale = -1;
                    }

                    if (currentColor == 2 && other.GetComponent<ColorChange>().colorType == 3 || currentColor == 3 && other.GetComponent<ColorChange>().colorType == 2)
                    {
                        color = new Color(0f, 1f, 0f);
                        currentColor = 6;
                        m_SpriteRenderer.color = color;
                        Player.GetComponent<Jump>().jumpForce = -400f;
						Player.GetComponent<PlayerCtrl>().jumpForce = -400f;
                        Player.GetComponent<Rigidbody2D>().gravityScale = -1;
                    }
                }

                if (currentColor > 3)
                {
                    Player.GetComponent<Death>().Die();
                }
            }
        }
    }
}