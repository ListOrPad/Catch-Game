using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using YG;

public class Localization : MonoBehaviour
{
    [SerializeField] private Button ruLanguageButton;
    [SerializeField] private Button enLanguageButton;
    [Space(15)]
    [SerializeField] private TextMeshProUGUI scoreText;

    public string CurrentLang { get; private set; }
    public bool LangChanged { get; set; }

    private void Start()
    {
        CurrentLang = YandexGame.lang;
        UpdateLanguageButton();

        if (YandexGame.lang == "en")
            scoreText.text = "Current Score: " + 0;
        else
            scoreText.text = "Текущий Счет: " + 0;
    }

    public void ChangeScoreText(int score)
    { 
        if (LangChanged)
        {
            if (YandexGame.lang == "en")
                scoreText.text = "Current Score: " + score;
            else
                scoreText.text = "Текущий Счет: " + score;
        }
    }

    private void UpdateLanguageButton()
    {
        if (CurrentLang == "en")
        {
            enLanguageButton.gameObject.SetActive(true);
            ruLanguageButton.gameObject.SetActive(false);
        }
        else
        {
            ruLanguageButton.gameObject.SetActive(true);
            enLanguageButton.gameObject.SetActive(false);
        }
    }

    //on language button click
    public void ChangeLanguageButton()
    {
        if (CurrentLang != YandexGame.lang)
        {
            CurrentLang = YandexGame.lang;
            UpdateLanguageButton();
            LangChanged = true;
        }
    }
}