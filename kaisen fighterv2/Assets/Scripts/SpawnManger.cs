using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRange = 30f;
    private float startDelay = 2f;
    private float initialSpawnInterval = 5f; // Increase the initial spawn interval
    private float minSpawnInterval = 2f; // Increase the minimum spawn interval
    private float spawnIntervalDecreaseRate = 0.05f; // Decrease the rate at which spawn interval decreases

    void Start()
    {
        InvokeRepeating("SpawnAnimals", startDelay, initialSpawnInterval);
    }

    void Update()
    {
        // You can add other update logic here if needed
    }

    void SpawnAnimals()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));

        // Use a raycast to find the ground level at the spawn position
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(spawnPos.x, 100f, spawnPos.z), Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            spawnPos.y = hit.point.y;
        }

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);

        // Adjust the spawn interval for the next spawn
        initialSpawnInterval = Mathf.Max(initialSpawnInterval - spawnIntervalDecreaseRate, minSpawnInterval);
    }
}
