using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject greenGemPrefab;
    [SerializeField] private GameObject redGemPrefab;
    [SerializeField] private GameObject challengeGemPrefab;
    [field:SerializeField] public float SpawnRate { get; set; } = 1.5f;
    private const float maxSpawnRate = 0.3f;
    private float timer = 0f;

    // Список для хранения активных объектов
    public static List<GameObject> ActiveGems = new List<GameObject>();


    void Update()
    {
        // Уменьшаем spawnRate
        SpawnRate = Mathf.Max(maxSpawnRate, SpawnRate - Time.deltaTime * 0.01f);

        // Обновляем таймер
        timer += Time.deltaTime;

        // Если таймер превысил spawnRate, спавним объект и сбрасываем таймер
        if (timer >= SpawnRate)
        {
            SpawnBall();
            timer = 0f; // Сбрасываем таймер
        }
    }

    void SpawnBall()
    {
        float randomX = Random.Range(-8f, 8f); // Границы экрана
        Vector3 spawnPos = new Vector3(randomX, 7, 0);


        GameObject gem;
        // Randomly choose type of a gem (70% green, 10 % red, 20% yellow)
        if (Random.Range(0, 10) < 7)
            gem = Instantiate(greenGemPrefab, spawnPos, Quaternion.identity);
        else if (Random.Range(0, 10) == 7)
           gem = Instantiate(redGemPrefab, spawnPos, Quaternion.identity);
        else
           gem = Instantiate(challengeGemPrefab, spawnPos, Quaternion.identity);

        ActiveGems.Add(gem);
    }

    // Метод для удаления объекта из списка
    public static void RemoveGem(GameObject gem)
    {
        ActiveGems.Remove(gem);
    }

}