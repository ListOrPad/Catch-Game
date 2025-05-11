using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [field: SerializeField] public static int Health { get; set; } = 3;
    public static bool HealthChanged { get; set; }

    

    private void Update()
    {
        // Check every active object
        foreach (var gem in Spawner.ActiveGems)
        {
            if (GameManager.IsTouchingBottomBorder(gem) && gem.CompareTag("GoldenGem"))
            {
                Hurt();
                Spawner.RemoveGem(gem);
                break;
            }
        }
    }

    

    public void Hurt()
    {
        Debug.Log("Hurt!");

        DecreaseHealth(1);
        Debug.Log(Health);

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
        HealthChanged = true;
    }
}