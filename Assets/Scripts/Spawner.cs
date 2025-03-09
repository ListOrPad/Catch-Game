using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject greenGemPrefab;
    [SerializeField] private GameObject redGemPrefab;
    [SerializeField] private float spawnRate = 1.5f;
    private const float maxSpawnRate = 0.3f;
    private float timer = 0f;

    void Update()
    {
        // Уменьшаем spawnRate
        spawnRate = Mathf.Max(maxSpawnRate, spawnRate - Time.deltaTime * 0.01f);

        // Обновляем таймер
        timer += Time.deltaTime;

        // Если таймер превысил spawnRate, спавним объект и сбрасываем таймер
        if (timer >= spawnRate)
        {
            SpawnBall();
            timer = 0f; // Сбрасываем таймер
        }
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