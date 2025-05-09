using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Spawner spawner;
    public int Score { get; set; } = 0;
    public bool GameStarted { get; set; }
    public bool IsGameOver { get; set; }

    private UIManager UI;

    [SerializeField] private TextMeshProUGUI scoreGameOverText;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Button startButton;

    private Leaderboard leaderboard;



    void Awake()
    {
        Instance = this;
        UI = GetComponent<UIManager>();
    }

    private void Start()
    {
        leaderboard = GetComponent<Leaderboard>();

        Time.timeScale = 0;
        startButton.onClick.AddListener(StartGame);
    }

    public void AddScore(int points)
    {
        Score += points;
        leaderboard.WriteRecord(Score);
    }

    private void StartGame()
    {
        IsGameOver = false;
        GameStarted = true;
        gamePanel.SetActive(false);

        Time.timeScale = 1;
        ResetGame(GameStarted);
    }

    public void GameOver()
    {
        IsGameOver = true;
        //Show Ad on game over
        YandexGame.FullscreenShow();

        
        Time.timeScale = 0;
        //to finally stop dropping crystals
        foreach (var rb in FindObjectsOfType<Rigidbody2D>())
        {
            rb.simulated = false;
        }
        UI.EnableUIText();
        gamePanel.SetActive(true);
        scoreGameOverText.text = Score.ToString();
        Score = 0;
    }

    private void ResetGame(bool gameStared)
    {
        if (gameStared)
        {
            spawner.SpawnRate = 1.5f;
            // Destriy all green gems
            GameObject[] greenGems = GameObject.FindGameObjectsWithTag("GreenGem");
            foreach (GameObject gem in greenGems)
            {
                Destroy(gem);
                Spawner.ActiveGems.Remove(gem);
            }

            // Destroy all red gems
            GameObject[] redGems = GameObject.FindGameObjectsWithTag("RedGem");
            foreach (GameObject gem in redGems)
            {
                Destroy(gem);
                Spawner.ActiveGems.Remove(gem);
            }
            
            GameObject[] ChallengeGems = GameObject.FindGameObjectsWithTag("ChallengeGem");
            foreach (GameObject gem in ChallengeGems)
            {
                Destroy(gem);
                Spawner.ActiveGems.Remove(gem);
            }

            HealthSystem.Health = 3; //reset health

            HealthSystem.HealthChanged = true;

            Debug.Log("All gems are destroyed, health reset, game started");
        }
    }
    public static bool IsTouchingBottomBorder(GameObject gem)
    {
        float bottomBorder = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        //Get lower point of the colider of an object
        float objectBottom = gem.GetComponent<CircleCollider2D>().bounds.min.y;

        //Check if object have touched bottom border
        return objectBottom <= bottomBorder;
    }
}