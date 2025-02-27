using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject greenBallPrefab;
    [SerializeField] private GameObject redBallPrefab;
    [SerializeField] private float spawnRate = 1f;

    void Start()
    {
        InvokeRepeating("SpawnBall", 1f, spawnRate);
    }

    void SpawnBall()
    {
        float randomX = Random.Range(-8f, 8f); // ������� ������
        Vector3 spawnPos = new Vector3(randomX, 7, 0);

        // �������� �������� ��� ������ (70% �������, 30% �������)
        if (Random.Range(0, 10) < 7)
            Instantiate(greenBallPrefab, spawnPos, Quaternion.identity);
        else
            Instantiate(redBallPrefab, spawnPos, Quaternion.identity);
    }
}