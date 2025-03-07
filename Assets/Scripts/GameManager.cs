using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
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
        Time.timeScale = 1;
        ResetGame(GameStarted);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        UI.EnableUIText();
        gamePanel.SetActive(true);
        scoreGameOverText.text = score.ToString();
    }

    private void ResetGame(bool gameStared)
    {
        if (gameStared)
        {
            // Destriy all green gems
            GameObject[] greenGems = GameObject.FindGameObjectsWithTag("GreenGem");
            foreach (GameObject gem in greenGems)
            {
                Destroy(gem);
            }

            // Destroy all red gems
            GameObject[] redGems = GameObject.FindGameObjectsWithTag("RedGem");
            foreach (GameObject gem in redGems)
            {
                Destroy(gem);
            }

            Debug.Log("All gems are destroyed, game started");
        }
    }
}