using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Spawner spawner;
    private int score = 0;
    public bool GameStarted { get; set; }
    private UIManager UI;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreGameOverText;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Button startButton;

    void Awake()
    {
        Instance = this;
        UI = GetComponent<UIManager>();
    }

    private void Start()
    {
        Time.timeScale = 0;
        startButton.onClick.AddListener(StartGame);
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    private void StartGame()
    {
        GameStarted = true;
        gamePanel.SetActive(false);
        scoreText.text = "Score: 0";
        Time.timeScale = 1;
        ResetGame(GameStarted);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        UI.EnableUIText();
        gamePanel.SetActive(true);
        scoreGameOverText.text = score.ToString();
        score = 0;
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

            Debug.Log("All gems are destroyed, health reset, game started");
        }
    }
    public static bool IsTouchingBottomBorder(GameObject gem)
    {
        // Получаем нижнюю границу экрана
        float bottomBorder = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        // Получаем нижнюю точку коллайдера объекта
        float objectBottom = gem.GetComponent<CircleCollider2D>().bounds.min.y;

        // Проверяем, коснулся ли объект нижней границы
        return objectBottom <= bottomBorder;
    }
}