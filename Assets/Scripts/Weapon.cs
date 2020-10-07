using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    void Update()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}