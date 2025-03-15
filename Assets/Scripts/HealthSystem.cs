using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [field: SerializeField] public static int Health { get; set; } = 3;

    

    private void Update()
    {
        // ��������� ��� �������� �������
        foreach (var gem in Spawner.ActiveGems)
        {
            if (GameManager.IsTouchingBottomBorder(gem) && gem.CompareTag("ChallengeGem"))
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

        // �������� ������ �� GameManager (���� �� ���� �� �����)
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