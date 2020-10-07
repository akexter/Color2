using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color color;
    public float colorType;
    SpriteRenderer m_SpriteRenderer;
    public GameObject bulletPrefab;
    private GameObject InstantiatedObject;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        if (colorType == 1)
        {
            color = new Color(1, 0, 0);
        }
        if (colorType == 2)
        {
            color = new Color(0, 0, 1);
        }
        if (colorType == 3)
        {
            color = new Color(0, 1, 0);
        }
        if (colorType == 4)
        {
            color = new Color(1, 0, 1);
        }
        if (colorType == 5)
        {
            color = new Color(1, 1, 0);
        }
        if (colorType == 6)
        {
            color = new Color(0, 1, 1);
        }

        m_SpriteRenderer.color = color;
    }
    void FixedUpdate()
    {
        InstantiatedObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
        InstantiatedObject.GetComponent<SpriteRenderer>().color = color;
    }
}
