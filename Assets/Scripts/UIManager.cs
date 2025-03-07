using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI yourScoreText;

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
}
