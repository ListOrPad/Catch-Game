using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [field: SerializeField] public int Health { get; set; } = 3;

    

    private void Update()
    {
        // Проверяем все активные объекты
        foreach (var gem in Spawner.ActiveGems)
        {
            if (IsTouchingBottomBorder(gem) && gem.GetComponent<CircleCollider2D>().CompareTag("ChallengeGem"))
            {
                Hurt();
                Spawner.RemoveGem(gem);
                Destroy(gem);
                break;
            }
        }
    }

    private bool IsTouchingBottomBorder(GameObject gem)
    {
        // Получаем нижнюю границу экрана
        float bottomBorder = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        // Получаем нижнюю точку коллайдера объекта
        float objectBottom = gem.GetComponent<CircleCollider2D>().bounds.min.y;

        // Проверяем, коснулся ли объект нижней границы
        return objectBottom <= bottomBorder;
    }

    public void Hurt()
    {
        Debug.Log("Hurt!");

        DecreaseHealth(1);
        Debug.Log(Health);

        // Получаем ссылку на GameManager (если он есть на сцене)
        GameManager game = FindObjectOfType<GameManager>();
        if (game != null && Health <= 0)
        {
            game.GameOver();
        }
    }

    private void DecreaseHealth(int damage)
    {
        Sound.Instance.PlayHurtSound();
        Health -= damage;
    }
}