using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static int scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the score to zero at the start of the game
        scoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the score display in the UI
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
    }

    // Call this method to increase the score
    public static void IncreaseScore(int amount)
    {
        scoreCount += amount;
    }
}
