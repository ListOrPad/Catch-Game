using UnityEngine;

public class Sound : MonoBehaviour
{

    public static Sound Instance;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip pickUpSound;
    [SerializeField] private AudioClip blastSound;
    [SerializeField] private AudioClip hurtSound;

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
}
