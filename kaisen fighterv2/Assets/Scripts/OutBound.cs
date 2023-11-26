using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutBound : MonoBehaviour
{
    Animator animator;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public float zRange = 10.0f; 
    public float yRange = 10.0f;
    void Start()
    {

    }
    void Update()
    {
        // Ensure the player stays within the defined ranges
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
    }
}