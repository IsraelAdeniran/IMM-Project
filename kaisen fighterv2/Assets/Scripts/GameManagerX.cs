using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Player player; // Reference to the Player script

    public List<GameObject> targetPrefabs;

    public Button restartButton;
    public Button menuButton;

    private int score;
    private float spawnRate = 1.5f;
    private bool isGameActive = true;

    private float spaceBetweenSquares = 2.5f;
    private float minValueX = -3.75f;
    private float minValueY = -3.75f;

    // Start the game, reset score, and adjust spawnRate based on difficulty button clicked
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false); // Hide game over text at the start
        restartButton.gameObject.SetActive(false); // Hide restart button at the start
        menuButton.gameObject.SetActive(false); // Hide menu button at the start
    }

    // While game is active spawn a random target
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);

            if (isGameActive)
            {
                Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
            }
        }
    }

    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;
    }

    // Generates a random square index from 0 to 3, which determines which square the target will appear in
    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // Update score with value from target clicked
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("Score Updated: " + score);
    }

    // Stop game and bring up game over text
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        Time.timeScale = 0f; // Pause the game
        menuButton.gameObject.SetActive(true); // Show menu button
    }

    // Go back to the menu
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with the actual name of your menu scene
    }

    // Update is called once per frame
    private void Update()
    {
        if (isGameActive)
        {
            // Check if player's health is zero
            if (player.Health <= 0)
            {
                // Call GameOver method if health is zero
                GameOver();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Display pause menu (in this case, just log to console)
                Debug.Log("Pause Menu");
            }
        }
    }
}
