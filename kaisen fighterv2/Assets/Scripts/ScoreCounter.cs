using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Assuming the player collects points when entering a trigger
        if (other.CompareTag("Player"))
        {
            // Increase the score by 10 (you can change the amount as needed)
            ScoreManager.IncreaseScore(10);
        }
    }
}