using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform magicSpawnPoint;
    public GameObject magicPrefab;
    public GameObject magicBulletPrefab;
    public float magicSpeed = 10;
    public float bulletSpeed = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootMagic(magicPrefab, magicSpeed);
            ShootMagic(magicBulletPrefab, bulletSpeed);
        }
    }

    void ShootMagic(GameObject magicType, float speed)
    {
        // Set the Y-coordinate to lift the magic above the ground
        Vector3 magicSpawnPos = magicSpawnPoint.position;
        magicSpawnPos.y = (magicType == magicPrefab) ? 1.5f : 0.5f;

        // Instantiate magic at the modified spawn position
        var magic = Instantiate(magicType, magicSpawnPos, magicSpawnPoint.rotation);

        // Set the velocity of the magic using the spawn point's forward direction
        magic.GetComponent<Rigidbody>().velocity = magicSpawnPoint.forward * speed;

        // Attach Projectile script to the magic object
        Projectile projectileScript = magic.AddComponent<Projectile>();
        projectileScript.speed = speed;

        // Destroy magic after 2 seconds (adjust the time as needed)
        Destroy(magic, 2f);
    }
}

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Destroy the projectile after a certain time or distance
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check for collisions with other game objects (e.g., enemies)
        if (other.CompareTag("npc"))
        {
            // Increase the score when hitting an enemy
            ScoreManager.IncreaseScore(10);

            // Destroy the enemy
            Destroy(other.gameObject);

            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}