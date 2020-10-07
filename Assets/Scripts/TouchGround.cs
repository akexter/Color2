using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGround : MonoBehaviour
{
    public Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }
}
