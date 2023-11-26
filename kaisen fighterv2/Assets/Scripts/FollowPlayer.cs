using System.Collections;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 3f;  // Adjust the speed of the NPC.
    public GameObject spherePrefab;  // Reference to the sphere prefab.

    private Transform player;  // Reference to the player's transform.

    void Start()
    {
        // Find the player using the tag "Player."
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the tag 'Player'.");
        }

        // Start the shooting coroutine.
        StartCoroutine(ShootSphereCoroutine());
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the NPC to the player.
            Vector3 direction = player.position - transform.position;

            // Normalize the direction vector to have a magnitude of 1.
            direction.Normalize();

            // Rotate the NPC towards the player.
            transform.rotation = Quaternion.LookRotation(direction);

            // Move the NPC towards the player using MoveTowards for smoother movement.
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    IEnumerator ShootSphereCoroutine()
    {
        while (true)
        {
            // Wait for 5 seconds before shooting.
            yield return new WaitForSeconds(5f);

            // Instantiate a sphere prefab at the NPC's position with a higher y-coordinate.
            Vector3 spawnPosition = transform.position + new Vector3(0f, 1f, 0f);
            Instantiate(spherePrefab, spawnPosition, transform.rotation);
        }
    }
}
