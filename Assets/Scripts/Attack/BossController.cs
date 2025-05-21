using UnityEngine;

public class BossController : MonoBehaviour
{
    public float hp = 100f;

    public void TakeDamage(float amount)
    {
        hp -= amount;
        Debug.Log("보스 체력: " + hp);

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("보스 사망!");
        Destroy(gameObject);
    }
}
