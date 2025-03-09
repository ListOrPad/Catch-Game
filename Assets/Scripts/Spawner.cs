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
        // ��������� spawnRate
        spawnRate = Mathf.Max(maxSpawnRate, spawnRate - Time.deltaTime * 0.01f);

        // ��������� ������
        timer += Time.deltaTime;

        // ���� ������ �������� spawnRate, ������� ������ � ���������� ������
        if (timer >= spawnRate)
        {
            SpawnBall();
            timer = 0f; // ���������� ������
        }
    }

    void SpawnBall()
    {
        float randomX = Random.Range(-8f, 8f); // ������� ������
        Vector3 spawnPos = new Vector3(randomX, 7, 0);

        // �������� �������� ��� ������ (70% �������, 30% �������)
        if (Random.Range(0, 10) < 7)
            Instantiate(greenGemPrefab, spawnPos, Quaternion.identity);
        else
            Instantiate(redGemPrefab, spawnPos, Quaternion.identity);

    }

}