using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] GameManager game;
    private HealthSystem healthSystem;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, transform.position.y, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GreenGem"))
        {
            GameManager.Instance.AddScore(10);
            Sound.Instance.PlayGemSound();
            Spawner.ActiveGems.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("RedGem"))
        {
            Debug.Log("Game Over!");
            Sound.Instance.PlayBlastSound();
            HealthSystem.Health = 0;
            HealthSystem.HealthChanged = true;
            game.GameOver();
            Spawner.ActiveGems.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("ChallengeGem"))
        {
            GameManager.Instance.AddScore(50);
            Sound.Instance.PlayGemSound();
            Spawner.ActiveGems.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
