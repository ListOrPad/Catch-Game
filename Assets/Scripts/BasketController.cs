using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] GameManager game;

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
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("RedGem"))
        {
            // Завершите игру или отнимите жизнь
            Debug.Log("Game Over!");
            Sound.Instance.PlayBlastSound();
            game.GameOver();
            Destroy(other.gameObject);
        }
    }
}
