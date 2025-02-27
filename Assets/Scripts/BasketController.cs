using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
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
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("RedGem"))
        {
            // Завершите игру или отнимите жизнь
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }
    }
}
