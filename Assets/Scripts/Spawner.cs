using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject greenGemPrefab;
    [SerializeField] private GameObject redGemPrefab;
    [SerializeField] private float spawnRate = 1f;

    void Start()
    {
        InvokeRepeating("SpawnBall", 1f, spawnRate);
    }

    void SpawnBall()
    {
        float randomX = Random.Range(-8f, 8f); // Границы экрана
        Vector3 spawnPos = new Vector3(randomX, 7, 0);

        // Случайно выбираем тип шарика (70% зеленых, 30% красных)
        if (Random.Range(0, 10) < 7)
            Instantiate(greenGemPrefab, spawnPos, Quaternion.identity);
        else
            Instantiate(redGemPrefab, spawnPos, Quaternion.identity);
    }

}