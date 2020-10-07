using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    private Vector2 FirstPos; // Where the object starts
    public Vector2 SecPos; // The offset
    private Vector2 ThirdPos; // Where the object goes
    float x;
    float y;
    float speed;
    public float multiplier;

    void Start()
    {
        FirstPos = transform.position;
        ThirdPos = FirstPos + SecPos;
        GetComponent<Rigidbody2D>();
        x = SecPos.x;
        y = SecPos.y;
        speed = Mathf.Sqrt(x*x+y*y)/2; // Pythagoras Theorem to determine how fast the platform should be moving
    }

    void Update()
    {
            transform.position = Vector2.Lerp(FirstPos, ThirdPos, Mathf.PingPong(Time.time * multiplier / speed, 1f));
    }
    void OnDrawGizmosSelected() // Draws a line to show where the object is heading
    {
        Gizmos.color = UnityEngine.Color.black;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(SecPos.x, SecPos.y, 0));
    }
}