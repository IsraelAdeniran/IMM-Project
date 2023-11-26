using System.Collections;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float turnSpeed = 50.0f;
    private float horizontalInput;
    private float forwardInput;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Rigidbody playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
        playerRb.angularDrag = 5f;
    }

    void Update()
    {
        // Get movement input from arrow keys or WASD
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotate the vehicle left or right
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        // Check for movement keys
        bool isWalking = forwardInput > 0;
        bool isWalkingBackward = forwardInput < 0;

        // Set Animator parameters
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isWalkingBackward", isWalkingBackward);
    }
}
