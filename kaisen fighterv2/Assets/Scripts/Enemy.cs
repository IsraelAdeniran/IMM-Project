using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int scoreValue = 0; // Score value to be added when the enemy is destroyed

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to a projectile
        if (other.CompareTag("Projectile"))
        {
            // Increase the score when the enemy is hit
            ScoreManager.IncreaseScore(scoreValue);

            // Destroy the enemy
            Destroy(gameObject);
        }
    }
}