using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject DeathBlob;
    public GameObject Player;
    Rigidbody2D rb;
    SpriteRenderer m_SpriteRenderer;
    public int Deaths = 0;
    public string Deathcounter;

    public float canRespawn = 0;

    GUIStyle style = new GUIStyle();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        style.alignment = TextAnchor.MiddleCenter; // Position the Text in the center of the Box
    }
    public void Die()
    {
        Instantiate(DeathBlob, transform.position, transform.rotation); // Spawns 10 death blobs
        Instantiate(DeathBlob, transform.position, transform.rotation);
        Instantiate(DeathBlob, transform.position, transform.rotation);
        Instantiate(DeathBlob, transform.position, transform.rotation);
        Instantiate(DeathBlob, transform.position, transform.rotation);
        Instantiate(DeathBlob, transform.position, transform.rotation);
        Instantiate(DeathBlob, transform.position, transform.rotation);
        Instantiate(DeathBlob, transform.position, transform.rotation);
        Instantiate(DeathBlob, transform.position, transform.rotation);
        Instantiate(DeathBlob, transform.position, transform.rotation);
        Deaths += 1;
    }
        
       void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("spikes"))
        {
            Die();
        }
    }
    void FixedUpdate()
    {
        Deathcounter = Deaths.ToString();

        if (canRespawn >= 10)
        {
            canRespawn = 0;
            transform.position = Player.GetComponent<PlayerCtrl>().Checkpoint;
            Player.GetComponent<PlayerColor>().changeColor = false;
            Player.GetComponent<PlayerColor>().currentColor = 0; // Removes all color
            rb.velocity = new Vector2(0f, 0f);
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width * 15 / 16, 0, Screen.width / 16, Screen.height / 18), Deathcounter, style); // Draws a box which contains the number of deaths
    }
}