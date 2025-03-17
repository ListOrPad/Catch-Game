using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Spawner spawner;
    private int score = 0;
    public bool GameStarted { get; set; }
    private UIManager UI;
    private Localization localization;

    [SerializeField] private TextMeshProUGUI scoreGameOverText;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Button startButton;

    private void Update()
    {
        localization.ChangeScoreText(score);
    }

    void Awake()
    {
        Instance = this;
        UI = GetComponent<UIManager>();
    }

    private void Start()
    {
        Time.timeScale = 0;
        startButton.onClick.AddListener(StartGame);
        localization = FindObjectOfType<Localization>();
    }

    public void AddScore(int points)
    {
        score += points;
    }

    private void StartGame()
    {
        GameStarted = true;
        gamePanel.SetActive(false);

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

            HealthSystem.HealthChanged = true;

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