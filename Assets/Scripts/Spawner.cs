using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject greenGemPrefab;
    [SerializeField] private GameObject redGemPrefab;
    [SerializeField] private GameObject goldenGemPrefab;
    [field:SerializeField] public float SpawnRate { get; set; } = 1.5f;
    private const float maxSpawnRate = 0.3f;
    private float spawnTimer = 0f;
    private Camera mainCamera;
    private float minX, maxX, spawnY;

    // List to store active objects
    public static List<GameObject> ActiveGems = new List<GameObject>();

    private void Start()
    {
        mainCamera = Camera.main;
        CalculateScreenBounds();
    }

    void Update()
    {
        //if window changed size
        if (Screen.width != lastScreenWidth || Screen.height != lastScreenHeight)
        {
            CalculateScreenBounds();
        }

        SpawnRate = Mathf.Max(maxSpawnRate, SpawnRate - Time.deltaTime * 0.01f);
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= SpawnRate)
        {
            SpawnBall();
            spawnTimer = 0f;
        }
        foreach (var gem in ActiveGems)
        {
            if (GameManager.IsTouchingBottomBorder(gem) && !gem.CompareTag("GoldenGem"))
            {
                RemoveGem(gem);
                break;
            }
        }
    }

    void SpawnBall()
    {
        float randomX = Random.Range(minX, maxX); // edges of the screen

        GameObject gem;
        // Randomly choose type of a gem (70% green, 10 % red, 20% yellow)
        if (Random.Range(0, 10) < 7)
            gem = Instantiate(greenGemPrefab, new Vector3(randomX, spawnY, 0), Quaternion.identity);
        else if (Random.Range(0, 10) == 7)
           gem = Instantiate(redGemPrefab, new Vector3(randomX, spawnY, 0), Quaternion.identity);
        else
           gem = Instantiate(goldenGemPrefab, new Vector3(randomX, spawnY, 0), Quaternion.identity);

        ActiveGems.Add(gem);
    }

    /// <summary>
    /// Method for deleting an object from the list
    /// </summary>
    public static void RemoveGem(GameObject gem)
    {
        //if gem exists in the list ActiveGems
        if (ActiveGems.Contains(gem))
        {
            ActiveGems.Remove(gem);
            Destroy(gem);
        }
    }

    private int lastScreenWidth;
    private int lastScreenHeight;

    void CalculateScreenBounds()
    {
        lastScreenWidth = Screen.width;
        lastScreenHeight = Screen.height;

        // Calculate borders of the screen in world coordinates
        Vector3 leftBorder = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightBorder = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0));

        minX = leftBorder.x + 1f; // +1f not to spawn too close to borders
        maxX = rightBorder.x - 1f;
        spawnY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1.1f, 0)).y; // 10% higher than the screen
    }

}