using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI yourScoreText;
    [SerializeField] private Image[] HPhearts;

    private void Update()
    {
        if(HealthSystem.HealthChanged)
            EnableHearts();
    }

    private void Start()
    {
        gameOverScoreText.enabled = false;
        yourScoreText.enabled = false;
    }

    public void EnableUIText()
    {
        gameOverScoreText.enabled = true;
        yourScoreText.enabled = true;
    }

    private void EnableHearts()
    {
        if (HealthSystem.Health == 3)
        {
            foreach (var heart in HPhearts)
            {
                heart.enabled = true;
            }
        }
        else if (HealthSystem.Health == 2)
        {
            HPhearts[0].enabled = false;
        }
        else if (HealthSystem.Health == 1)
        {
            HPhearts[1].enabled = false;
        }
        else
        {
            foreach (var heart in HPhearts)
            {
                heart.enabled = false;
            }
        }
        HealthSystem.HealthChanged = false;
    }
}
