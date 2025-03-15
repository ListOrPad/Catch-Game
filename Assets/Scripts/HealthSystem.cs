using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [field: SerializeField] public int Health { get; set; } = 3;

    

    private void Update()
    {
        // ��������� ��� �������� �������
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
        // �������� ������ ������� ������
        float bottomBorder = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        // �������� ������ ����� ���������� �������
        float objectBottom = gem.GetComponent<CircleCollider2D>().bounds.min.y;

        // ���������, �������� �� ������ ������ �������
        return objectBottom <= bottomBorder;
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