using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{

    public static Sound Instance;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip pickUpSound;
    [SerializeField] private AudioClip blastSound;
    [SerializeField] private AudioClip hurtSound;

    [Header("Sound Activation/Deactivation")]
    private bool soundOn = true;
    [SerializeField] Button soundButton;
    [SerializeField] Sprite soundImageOn;
    [SerializeField] Sprite soundImageOff;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayGemSound()
    {
        source.PlayOneShot(pickUpSound);
    }

    public void PlayBlastSound()
    {
        source.PlayOneShot(blastSound);
    }

    public void PlayHurtSound()
    {
        source.PlayOneShot(hurtSound);
    }

    public void ToggleSound()
    {
        if (soundOn)
        {
            source.gameObject.SetActive(false);
        }
        else
        {
            source.gameObject.SetActive(true);
        }
        soundOn = !soundOn;
        soundButton.image.sprite = soundOn ? soundImageOn : soundImageOff;
    }
}
