using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed of the bullet.

    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward based on its local forward direction.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
