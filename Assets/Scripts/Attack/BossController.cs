using UnityEngine;

public class BossController : MonoBehaviour
{
    public float hp = 100f;

    public void TakeDamage(float amount)
    {
        hp -= amount;
        Debug.Log("���� ü��: " + hp);

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("���� ���!");
        Destroy(gameObject);
    }
}
